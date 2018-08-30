using System;
namespace ExtAppraisalApp.Utilities
{
    public interface WorkerDelegateInterface
    {
        void UpdateDatas(bool show);

        void performNavigate(int index);

        void ShowDoneIcon(int index);

        void ShowPartialDoneIcon(int index);
    }
}
