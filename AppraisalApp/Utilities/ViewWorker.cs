using System;
namespace ExtAppraisalApp.Utilities
{
    public class ViewWorker
    {
        WeakReference<WorkerDelegateInterface> _workerDelegate;

        public WorkerDelegateInterface WorkerDelegate
        {
            get
            {
                WorkerDelegateInterface workerDelegate;
                return _workerDelegate.TryGetTarget(out workerDelegate) ? workerDelegate : null;
            }
            set
            {
                _workerDelegate = new WeakReference<WorkerDelegateInterface>(value);
            }
        }

            public void UpdateUI(bool show)
            {
                Console.WriteLine("Updating UI .. ");

                if (_workerDelegate != null)
                    WorkerDelegate?.UpdateDatas(show);

            }

        public void PerformNavigation(int indexPath)
        {
            if (_workerDelegate != null)
                WorkerDelegate?.performNavigate(indexPath);
        }

        public void ShowDoneImg(int index)
        {
            if (_workerDelegate != null)
                WorkerDelegate?.ShowDoneIcon(index);
        }

        public void ShowPartialDoneImg(int index){
            if (_workerDelegate != null)
                WorkerDelegate?.ShowPartialDoneIcon(index);
        }
    }
}
