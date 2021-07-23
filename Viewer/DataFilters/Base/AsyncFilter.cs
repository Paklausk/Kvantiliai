using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class AsyncFilter : IDisposable
    {
        class FilterTask
        {
            public LinkedList<IFilterHandle> FiltersChain { get; }
            public IEnumerable<CompanyData> Data { get; }
            public bool Cancelled { get; private set; } = false;
            public FilterTask(Dictionary<Type, IFilterHandle> filtersChain, IEnumerable<CompanyData> data)
            {
                FiltersChain = new LinkedList<IFilterHandle>(filtersChain.Values);
                Data = data;
            }
            public IEnumerable<CompanyData> Filter()
            {
                var filteredData = Data;
                foreach (var filter in FiltersChain)
                    if (!Cancelled)
                    {
                        filteredData = filter.Handle(filteredData);
                    }
                return filteredData;
            }
            public void Cancel()
            {
                Cancelled = true;
            }
        }
        bool _run = true;
        Thread _thread;
        ManualResetEvent _sleeper = new ManualResetEvent(false);
        FilterTask _task;
        Dictionary<Type, IFilterHandle> _filtersChain = new Dictionary<Type, IFilterHandle>();

        public event Action<IEnumerable<CompanyData>> OnFilteringFinished;
        public AsyncFilter()
        {
            _thread = new Thread(Run);
            _thread.Start();
        }
        public void SetFilterHandle(IFilterHandle filter)
        {
            _filtersChain[filter.GetType()] = filter;
        }
        public void RemoveFilterHandle<T>() where T : IFilterHandle
        {
            _filtersChain.Remove(typeof(T));
        }
        public void StartTask(IEnumerable<CompanyData> data)
        {
            CancelTask();
            _task = new FilterTask(_filtersChain, data);
            _sleeper.Set();
        }
        void CancelTask()
        {
            _task?.Cancel();
        }
        void Run()
        {
            while (_run)
            {
                if (_task != null)
                {
                    var task = _task;
                    var filteredData = task.Filter();
                    if (!task.Cancelled)
                        OnFilteringFinished?.Invoke(filteredData);
                }
                if (_run)
                    _sleeper.Reset();
                _sleeper.WaitOne();
            }
        }
        public void Dispose()
        {
            _run = false;
            _sleeper.Set();
            _thread.Join();
        }
    }
}
