using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppraisalApp.Models;
using CoreGraphics;
using ExtAppraisalApp;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace AppraisalApp
{
    public partial class AppraisalLogViewController : UIViewController
    {
        partial void BtnCancel_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("LoginViewController");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;

        }

        partial void BtnAddNew_Activated(UIBarButtonItem sender)
        {
            // Navigate DecodeView
            var storyboard = UIStoryboard.FromName("Main", null);
            DecodeViewController decodeViewController = (DecodeViewController)storyboard.InstantiateViewController("DecodeViewController");
            UINavigationController uINavigationController = new UINavigationController(decodeViewController);
            uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
            this.NavigationController.PresentViewController(uINavigationController, true, null);

        }

        List<AppraisalLogEntity> apploglist = new List<AppraisalLogEntity>();

        partial void Segment_Changed(UISegmentedControl sender)
        {
            string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
            if (segmentID == "0")
            {
                var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                AppraisalTableView.EstimatedRowHeight = 40f;
                AppraisalTableView.ReloadData();
            }
            else
            {
                var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                AppraisalTableView.EstimatedRowHeight = 40f;
                AppraisalTableView.ReloadData();
            }
        }


        public AppraisalLogViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            VinSearch.Text = VinSearch.Text.ToUpper();
            VinSearch.TextChanged += (sender, e) =>  
            {  
                if(VinSearch.Text.Length > 0)
                {
                    var VinSearchEntity = apploglist.FindAll((AppraisalLogEntity obj) => obj.VIN.Contains(VinSearch.Text.Trim()));
                    AppraisalTableView.Source = new ApprasialLogTVS(VinSearchEntity);
                    AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                    AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                    AppraisalTableView.EstimatedRowHeight = 40f;
                    AppraisalTableView.ReloadData();  
                }//this is the method that is called when the user searches  
                else
                {
                    string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
                    if (segmentID == "0")
                    {
                        var Appcompleted = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                        AppraisalTableView.Source = new ApprasialLogTVS(Appcompleted);
                        AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                        AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                        AppraisalTableView.EstimatedRowHeight = 40f;
                        AppraisalTableView.ReloadData();
                    }
                    else
                    {
                        var appPending = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                        AppraisalTableView.Source = new ApprasialLogTVS(appPending);
                        AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                        AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                        AppraisalTableView.EstimatedRowHeight = 40f;
                        AppraisalTableView.ReloadData();
                    }
                }
               
            };  
            AppraisalTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            apploglist=ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);


            var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
            AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
               
            AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
            AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
            AppraisalTableView.EstimatedRowHeight = 40f;
            AppraisalTableView.ReloadData();
        }

    }
}