// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ExtAppraisalApp
{
    [Register ("MasterViewController")]
    partial class MasterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AfterMarketDoneImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConditionsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView FactoryOptionsDoneImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HistoryDoneImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView InfoDoneImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem MasterViewCloseBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PhotosDoneImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ReconditionsDoneImg { get; set; }

        [Action ("MasterViewCloseBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MasterViewCloseBtn_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (AfterMarketDoneImg != null) {
                AfterMarketDoneImg.Dispose ();
                AfterMarketDoneImg = null;
            }

            if (ConditionsLabel != null) {
                ConditionsLabel.Dispose ();
                ConditionsLabel = null;
            }

            if (FactoryOptionsDoneImg != null) {
                FactoryOptionsDoneImg.Dispose ();
                FactoryOptionsDoneImg = null;
            }

            if (HistoryDoneImg != null) {
                HistoryDoneImg.Dispose ();
                HistoryDoneImg = null;
            }

            if (InfoDoneImg != null) {
                InfoDoneImg.Dispose ();
                InfoDoneImg = null;
            }

            if (MasterViewCloseBtn != null) {
                MasterViewCloseBtn.Dispose ();
                MasterViewCloseBtn = null;
            }

            if (PhotosDoneImg != null) {
                PhotosDoneImg.Dispose ();
                PhotosDoneImg = null;
            }

            if (ReconditionsDoneImg != null) {
                ReconditionsDoneImg.Dispose ();
                ReconditionsDoneImg = null;
            }
        }
    }
}