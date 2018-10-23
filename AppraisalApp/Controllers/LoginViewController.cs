// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppraisalApp.Models;
using CoreAnimation;
using CoreGraphics;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using UIKit;

namespace ExtAppraisalApp
{

    public partial class LoginViewController : UIViewController, WorkerDelegateInterface
    {


        private UIPickerView pickerView;

        private UIToolbar toolbar;

        public static StoreLocatorModel storeLocatorModel;

        private string zipCode;

        public NetworkStatus remoteHostStatus, internetStatus, localWifiStatus;

        private nfloat scroll_amount = 0.0f;    // amount to scroll 
        private nfloat bottom = 0.0f;           // bottom point
        private nfloat offset = 10.0f;          // extra offset
        private bool moveViewUp = false;           // which direction are we moving

        private bool IsEmail = false;

        Dictionary<string, string> storeNamesID = new Dictionary<string, string>();

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        private bool keyboardPushedUp;

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        void updateInternetStatus()
        {
            try
            {
                remoteHostStatus = Reachability.RemoteHostStatus();
                internetStatus = Reachability.InternetConnectionStatus();
                localWifiStatus = Reachability.LocalWifiConnectionStatus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception In LoginViewController: updateInternetStatus: " + ex.Message);
            }
        }

        public override void ViewDidLoad()
        {

            updateInternetStatus();
            Reachability.ReachabilityChanged += (object sender, EventArgs e) => {
                updateInternetStatus();
            };

            // hide keyboard on touch outside area
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(g);



            InitialContainer.Hidden = false;
            GuestContainer.Hidden = true;
            DealerContainer.Hidden = true;

            EmailRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_filled.png"), UIControlState.Normal);
            PhoneRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_empty.png"), UIControlState.Normal);

            EmailPhone.Placeholder = "Email";
            IsEmail = true;

            LastNameTxt.Text = Regex.Replace(LastNameTxt.Text, @"[^a-zA-Z]+", "");
            LastNameTxt.ShouldChangeCharacters = (UITextField txt, NSRange range, string oopsTxt) =>
            {
                var newLength = txt.Text.Length + oopsTxt.Length - range.Length;
                return newLength <= 50;

            };



            txtZip.ShouldChangeCharacters = (textField, range, replacementString) => {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 5;
            };


            DealerCodeTxt.ShouldChangeCharacters = (textField, range, replacementString) => {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 6;
            };

            if (UserInterfaceIdiomIsPhone)
            {
                Console.WriteLine("width :: " + this.View.Bounds.Width + " Height :: " + this.View.Bounds.Height);
                // iphone 8 plus :: width :: 414 Height :: 736
                // iphone 7 width :: 375 Height :: 667

                //if (this.View.Bounds.Width == 375)
                //{
                //    boxImg.Frame = new CGRect(0, 0, 500, 500);
                //}
                //else
                //{
                //    boxImg.Frame = new CGRect(0, 0, 550, 550);
                //}

                //if (this.View.Bounds.Height == 667)
                //{
                //    boxImg.Center = new CGPoint(this.View.Bounds.Width / 2, this.View.Bounds.Height / 1.5);
                //    ComponentView.Center = new CGPoint(this.View.Bounds.Width / 2, this.View.Bounds.Height / 1.5);
                //}
                //else
                //{
                //    boxImg.Center = new CGPoint(this.View.Bounds.Width / 2, this.View.Bounds.Height / 2);
                //    ComponentView.Center = new CGPoint(this.View.Bounds.Width / 2, this.View.Bounds.Height / 2.2);
                //}

                if (this.View.Bounds.Width == 375)
                {
                    NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, keyboardWillHide);
                    NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, keyboardWillShow);
                }


            }
            else
            {
                if (InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || InterfaceOrientation == UIInterfaceOrientation.LandscapeRight)
                {
                    NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, keyboardWillHide);
                    NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, keyboardWillShow);
                }
            }

            AppDelegate.appDelegate.IsZipCodeValid = false;

            storeLocatorModel = new StoreLocatorModel();

            AppDelegate.appDelegate.IsInfoSaved = false;
            AppDelegate.appDelegate.IsFactorySaved = false;
            AppDelegate.appDelegate.IsAftermarketSaved = false;
            AppDelegate.appDelegate.IsHistorySaved = false;
            AppDelegate.appDelegate.IsReconditionsSaved = false;
            AppDelegate.appDelegate.IsPhotosSaved = false;
            AppDelegate.appDelegate.IsAllDataSaved = false;

            LastNameTxt.ShouldReturn = (tf) =>
            {
                LastNameTxt.ReturnKeyType = UIReturnKeyType.Next;
                EmailPhone.BecomeFirstResponder();
                return true;
            };
            EmailPhone.ShouldReturn = (tf) =>
            {
                EmailPhone.ReturnKeyType = UIReturnKeyType.Next;
                txtZip.BecomeFirstResponder();
                return true;
            };

            txtZip.ShouldReturn = (tf) =>
            {
                txtZip.EndEditing(true);
                txtZip.ReturnKeyType = UIReturnKeyType.Go;
                GoClick();
                return true;
            };

            DealerCodeTxt.ShouldReturn = (tf) =>
            {
                DealerCodeTxt.EndEditing(true);
                DealerCodeTxt.ReturnKeyType = UIReturnKeyType.Go;
                DealerClicked();
                return true;
            };

        }





        partial void GetStartBtn_TouchUpInside(UIButton sender)
        {
            if (string.IsNullOrEmpty(LastNameTxt.Text))
            {
                Utility.ShowAlert("CarCash", "Please Enter the LastName.!!", "OK");
            }
            else if (string.IsNullOrEmpty(EmailPhone.Text))
            {
                Utility.ShowAlert("CarCash", "Please Enter Email or Phone.!!", "OK");
            }
            else
            {
                AppDelegate.appDelegate.GuestLastName = LastNameTxt.Text;

                if (IsEmail)
                {
                    AppDelegate.appDelegate.GuestEmail = EmailPhone.Text;
                    AppDelegate.appDelegate.GuestPhone = "";
                }
                else
                {
                    AppDelegate.appDelegate.GuestEmail = "";
                    AppDelegate.appDelegate.GuestPhone = EmailPhone.Text;
                }
            }
            if (txtZip.Placeholder != "ZIP CODE" && string.IsNullOrEmpty(txtZip.Text))
            {
                Utility.ShowAlert("CarCash", "Please select store.!!", "OK");

            }
            else
            {
                GoClick();
            }


        }

        partial void DealerGetStartBtn_TouchUpInside(UIButton sender)
        {
            DealerClicked();
        }

        private async void DealerClicked()
        {

            if (string.IsNullOrEmpty(DealerCodeTxt.Text))
            {

                Utility.ShowAlert("CarCash", "Please Enter the DealerCode.!!", "OK");

            }
            else if ((DealerCodeTxt.Text.Length != 6))
            {

                Utility.ShowAlert("CarCash", "Your Dealer code (" + DealerCodeTxt.Text + ") is Incorrect", "OK");
            }
            else
            {

                Utility.ShowLoadingIndicator(this.View, "", true);

                string code = null;
                code = await GetStoreID(DealerCodeTxt.Text);


                Utility.HideLoadingIndicator(this.View);

                if (null != code)
                {
                    AppDelegate.appDelegate.storeId = Convert.ToInt16(code);
                    List<AppraisalLogEntity> appraisalLogs = new List<AppraisalLogEntity>();


                    Utility.ShowLoadingIndicator(this.View, "", true);

                    appraisalLogs = await CallDealerAppraisalLogService();

                    Utility.HideLoadingIndicator(this.View);

                    if (appraisalLogs.Count > 0)
                    {
                        AppDelegate.appDelegate.AppraisalsLogs = appraisalLogs;
                        AppDelegate.appDelegate.CustomerLogin = false;
                        AppDelegate.appDelegate.DealerLogin = true;
                        var storyboard = UIStoryboard.FromName("Main", null);
                        var splitViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
                        var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
                        appDelegate.Window.RootViewController = splitViewController;
                    }
                    else
                    {
                        this.PerformSegue("decodeSegue", this);
                    }

                    SaveDealerLogin();
                }

            }
        }

        Task<string> GetStoreID(string dealercode)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                string code = null;
                code = ServiceFactory.getWebServiceHandle().ValidateZipDealer(Convert.ToInt32(dealercode));
                return code;
            });
        }

        partial void GuestEmailTxtChanged(UITextField sender)
        {
            Debug.WriteLine("Email text changed");
        }

        partial void LastNameTxtChanged(UITextField sender)
        {
            LastNameTxt.Text = Regex.Replace(LastNameTxt.Text, @"[^a-zA-Z]+", "");
            LastNameTxt.ShouldChangeCharacters = (UITextField txt, NSRange range, string oopsTxt) =>
            {
                var newLength = txt.Text.Length + oopsTxt.Length - range.Length;
                return newLength <= 50;

            };
        }


        public async void GoClick()
        {
            try
            {
                if (!AppDelegate.appDelegate.IsZipCodeValid)
                {
                    string zip = txtZip.Text;

                    if (zip == "")
                    {
                        Utility.ShowAlert("CarCash", "A ZIP/Dealer is required.!!", "OK");

                    }
                    else if (zip.Length != 5)
                    {
                        Utility.ShowAlert("CarCash", "Your ZIP code (" + zip + ") is Incorrect", "OK");

                    }
                    else if (!Regex.Match(EmailPhone.Text, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$").Success && IsEmail)
                    {

                        Utility.ShowAlert("CarCash", "Your Email (" + EmailPhone.Text + ") is Incorrect", "OK");
                    }
                    else
                    {
                        zipCode = txtZip.Text;

                        if (!Reachability.InternetConnectionStatus().Equals(NetworkStatus.NotReachable))
                        {

                            Utility.ShowLoadingIndicator(this.View, "", true);
                            CallWebservice();

                        }
                        else
                        {

                            Utility.ShowAlert("CarCash", "You are disconnected from internet. Please connect and try again", "OK");
                        }

                    }
                }
                else
                {
                    AppDelegate.appDelegate.IsZipCodeValid = false;
                    // this.PerformSegue("decodeSegue", this);
                    removeAll(pickerView);

                    List<CustomerAppraisalLogEntity> customerAppraisalLogs = new List<CustomerAppraisalLogEntity>();

                    Utility.ShowLoadingIndicator(this.View, "", true);

                    customerAppraisalLogs = await CallGuestAppraisalLogService(AppDelegate.appDelegate.GuestLastName, AppDelegate.appDelegate.GuestEmail, AppDelegate.appDelegate.GuestPhone);

                    Utility.HideLoadingIndicator(this.View);

                    if (customerAppraisalLogs.Count > 0)
                    {
                        AppDelegate.appDelegate.CustomerAppraisalLogs = customerAppraisalLogs;
                        AppDelegate.appDelegate.CustomerLogin = true;
                        AppDelegate.appDelegate.DealerLogin = false;
                        var storyboard = UIStoryboard.FromName("Main", null);
                        var splitViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
                        AppDelegate.appDelegate.Window.RootViewController = splitViewController;

                    }
                    else
                    {
                        AppDelegate.appDelegate.CustomerLogin = true;
                        this.PerformSegue("decodeSegue", this);
                    }

                    SaveCustomerLogin();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
        }

        Task<List<CustomerAppraisalLogEntity>> CallGuestAppraisalLogService(string lastname, string email, string phone)
        {

            return Task<List<CustomerAppraisalLogEntity>>.Factory.StartNew(() =>
            {
                List<CustomerAppraisalLogEntity> customerAppraisalLogs = new List<CustomerAppraisalLogEntity>();
                customerAppraisalLogs = ServiceFactory.getWebServiceHandle().FetchCustomerAppraisalLogs(lastname, email, phone);

                return customerAppraisalLogs;


            });
        }

        Task<List<AppraisalLogEntity>> CallDealerAppraisalLogService()
        {
            return Task<List<AppraisalLogEntity>>.Factory.StartNew(() =>
            {
                List<AppraisalLogEntity> dealerAppraisalLogs = new List<AppraisalLogEntity>();
                dealerAppraisalLogs = ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);

                return dealerAppraisalLogs;


            });
        }

        Task CallWebservice()
        {
            return Task.Factory.StartNew(() =>
            {
                ServiceCall();
            });
        }

        private async void ServiceCall()
        {
            string code = null;
            code = ServiceFactory.getWebServiceHandle().ValidateZipDealer(Convert.ToInt32(zipCode));

            if (code == null)
            {
                short storeid = ServiceFactory.getWebServiceHandle().SearchNearestStores(zipCode);
                if (storeid > 0)
                {

                    AppDelegate.appDelegate.IsZipCodeValid = true;

                    if (AppDelegate.appDelegate.IsZipCodeValid)
                    {
                        AppDelegate.appDelegate.storeId = storeid;
                        AppDelegate.appDelegate.IsZipCodeValid = false;

                        List<CustomerAppraisalLogEntity> customerAppraisalLogs = new List<CustomerAppraisalLogEntity>();

                        //Utility.ShowLoadingIndicator(this.View, "", true);

                        customerAppraisalLogs = await CallGuestAppraisalLogService(AppDelegate.appDelegate.GuestLastName, AppDelegate.appDelegate.GuestEmail, AppDelegate.appDelegate.GuestPhone);

                        InvokeOnMainThread(() =>
                        {
                            Utility.HideLoadingIndicator(this.View);
                            if (customerAppraisalLogs.Count > 0)
                            {
                                AppDelegate.appDelegate.CustomerAppraisalLogs = customerAppraisalLogs;
                                AppDelegate.appDelegate.CustomerLogin = true;
                                AppDelegate.appDelegate.DealerLogin = false;
                                var storyboard = UIStoryboard.FromName("Main", null);
                                var splitViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
                                AppDelegate.appDelegate.Window.RootViewController = splitViewController;

                            }
                            else
                            {
                                AppDelegate.appDelegate.CustomerLogin = true;
                                this.PerformSegue("decodeSegue", this);
                            }
                        });



                        SaveCustomerLogin();
                       
                    }
                }
                else
                {
                    InvokeOnMainThread(() =>
                    {
                        Utility.HideLoadingIndicator(this.View);
                        Utility.ShowAlert("Appraisal App", "No Nearest Stores Found!!", "OK");
                    });

                }
            }
            else if (null != code)
            {
                AppDelegate.appDelegate.storeId = Convert.ToInt16(code);
                InvokeOnMainThread(() =>
                {
                    var storyboard = UIStoryboard.FromName("Main", null);
                    var splitViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
                    var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
                    appDelegate.Window.RootViewController = splitViewController;

                });

            }
            else
            {
                InvokeOnMainThread(() =>
                {
                    Utility.ShowAlert("ZIP/Dealer", "Please Enter valid ZIP/Dealer Code", "OK");
                });
            }
        }

        private void SaveCustomerLogin()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.CreateTable<CustomerValue>();

            var record = new CustomerValue { CustomerLogin = true, CustomerLastName = AppDelegate.appDelegate.GuestLastName, CustomerEmail = AppDelegate.appDelegate.GuestEmail, CustomerPhone = AppDelegate.appDelegate.GuestPhone, StoreId = AppDelegate.appDelegate.storeId };
            using (var db = new SQLite.SQLiteConnection(DbPath))
            {
                var existingRecord = (db.Table<CustomerValue>().Where(c => c.CustomerLastName == record.CustomerLastName)).SingleOrDefault();
                if (existingRecord != null)
                {
                    existingRecord.CustomerLogin = record.CustomerLogin;
                    existingRecord.CustomerLastName = record.CustomerLastName;
                    existingRecord.CustomerEmail = record.CustomerEmail;
                    existingRecord.CustomerPhone = record.CustomerPhone;
                    existingRecord.StoreId = record.StoreId;
                    db.Update(existingRecord);
                }
                else
                {
                    db.Insert(record);
                }

            }
        }

        private void SaveDealerLogin()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.CreateTable<DealerValue>();

            var record = new DealerValue { DealerLogin = true, StoreId = AppDelegate.appDelegate.storeId };
            using (var db = new SQLite.SQLiteConnection(DbPath))
            {
                var existingRecord = (db.Table<DealerValue>().Where(c => c.DealerLogin == record.DealerLogin)).SingleOrDefault();
                if (existingRecord != null)
                {
                    existingRecord.DealerLogin = record.DealerLogin;
                    existingRecord.StoreId = record.StoreId;
                    db.Update(existingRecord);
                }
                else
                {
                    db.Insert(record);
                }

            }
        }

        public void removeAll(UIPickerView picker)
        {
            toolbar.SetItems(new UIBarButtonItem[0], false);
            this.toolbar.RemoveFromSuperview();
            picker.Layer.Opacity = 0f;
            picker.Layer.Bounds = new RectangleF(0, 0, 0, 0);
            picker.RemoveFromSuperview();
            txtZip.InputView = null;
            txtZip.ReloadInputViews();
            storeNamesID.Clear();
            storeLocatorModel.Items.Clear();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "decodeSegue")
            {
                var controller = (DecodeViewController)((UINavigationController)segue.DestinationViewController).TopViewController;

                controller.SetDetailItem(this);
            }
        }

        private void SetPicker(object sender, EventArgs e)
        {
            UITextField field = (UITextField)sender;
            if (field.Text != "")
                pickerView.Select(storeLocatorModel.Items.IndexOf(field.Text), 0, true);
        }

        private void keyboardWillHide(NSNotification notification)
        {
            try
            {
                keyboardPushedUp = false;
                //CGPoint point = scrollview.ContentOffset;
                //point.Y = point.Y - 90;
                //scrollview.SetContentOffset(point, true);

                if (moveViewUp) { ScrollTheView(false); }
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Null exception :: " + ex.Message);
            }
            catch (Exception ex1)
            {
                Debug.WriteLine("Exception occurred :: " + ex1.Message);
            }
        }

        private void keyboardWillShow(NSNotification notification)
        {
            try
            {
                if (!keyboardPushedUp)
                {
                    //CGPoint point = scrollview.ContentOffset;
                    //point.Y = point.Y + 90;
                    //scrollview.SetContentOffset(point, true);
                    keyboardPushedUp = true;


                    // get the keyboard size
                    RectangleF r = (System.Drawing.RectangleF)UIKeyboard.BoundsFromNotification(notification);

                    //// Find what opened the keyboard
                    //foreach (UIView view in this.View.Subviews)
                    //{
                    //    if (view.IsFirstResponder)
                    //        activeview = view;
                    //}

                    // Bottom of the controller = initial position + height + offset      
                    //bottom = (LastNameTxt.Frame.Y + LastNameTxt.Frame.Height + offset);

                    //// Calculate how far we need to scroll
                    //scroll_amount = (r.Height - (View.Frame.Size.Height - bottom));

                    if (UserInterfaceIdiomIsPhone)
                    {
                        scroll_amount = 50;
                    }
                    else
                    {
                        scroll_amount = 80;
                    }

                    // Perform the scrolling
                    if (scroll_amount > 0)
                    {
                        moveViewUp = true;
                        ScrollTheView(moveViewUp);
                    }
                    else
                    {
                        moveViewUp = false;
                    }
                }


            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Null exception :: " + ex.Message);
            }
            catch (Exception ex1)
            {
                Debug.WriteLine("Exception occurred :: " + ex1.Message);
            }
        }

        private void ScrollTheView(bool move)
        {

            // scroll the view up or down
            UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
            UIView.SetAnimationDuration(0.5);

            RectangleF frame = (System.Drawing.RectangleF)View.Frame;

            if (move)
            {
                frame.Y -= (float)scroll_amount;
            }
            else
            {
                frame.Y += (float)scroll_amount;
                scroll_amount = 0;
            }

            View.Frame = frame;
            UIView.CommitAnimations();
        }


        // Inner Class : StatusChange Model : Pickerview
        public class StoreLocatorModel : UIPickerViewModel
        {
            public event EventHandler<EventArgs> ValueChanged;

            /// <summary>
            /// The items to show up in the picker
            /// </summary>
            public List<string> Items { get; private set; }

            /// <summary>
            /// The current selected item
            /// </summary>
            public string SelectedItem
            {
                get { return Items[selectedIndex]; }
            }

            int selectedIndex = 0;

            public StoreLocatorModel()
            {
                Items = new List<string>();
            }

            /// <summary>
            /// Called by the picker to determine how many rows are in a given spinner item
            /// </summary>
            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return Items.Count;
            }

            /// <summary>
            /// called by the picker to get the text for a particular row in a particular
            /// spinner item
            /// </summary>
            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return Items[(int)row];
            }

            /// <summary>
            /// called by the picker to get the number of spinner items
            /// </summary>
            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            /// <summary>
            /// called when a row is selected in the spinner
            /// </summary>
            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                selectedIndex = (int)row;
                if (ValueChanged != null)
                {
                    ValueChanged(this, new EventArgs());
                }
            }

        }


        public void AnimateFlipHorizontally(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var m34 = (nfloat)(-1 * 0.001);

            var minTransform = CATransform3D.Identity;
            minTransform.m34 = m34;
            minTransform = minTransform.Rotate((nfloat)((isIn ? 1 : -1) * Math.PI * 0.5), (nfloat)0.0f, (nfloat)1.0f, (nfloat)0.0f);
            var maxTransform = CATransform3D.Identity;
            maxTransform.m34 = m34;

            view.Layer.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, (nfloat)0.5f);
                    view.Layer.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public void UpdateDatas(bool show)
        {
            txtZip.Text = "";
            txtZip.Placeholder = "ZIP/DEALER CODE";
            txtZip.EndEditing(true);
            this.View.EndEditing(true);
            GetStartBtn.SetTitle("Get Started", UIControlState.Normal);
            AppDelegate.appDelegate.IsZipCodeValid = false;
            if (null != toolbar)
            {
                toolbar.RemoveFromSuperview();
            }
            if (null != pickerView)
            {
                pickerView.RemoveFromSuperview();
            }

        }

        public static void SlideVerticaly(UIView view, bool isIn, bool fromTop, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation(0, (fromTop ? -1 : 1) * view.Bounds.Height);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }
        public static void SlideHorizontaly(UIView view, bool isIn, bool fromLeft, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation((fromLeft ? -1 : 1) * view.Bounds.Width, 0);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        partial void PhoneRadioBtn_TouchUpInside(UIButton sender)
        {
            PhoneRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_filled.png"), UIControlState.Normal);
            EmailRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_empty.png"), UIControlState.Normal);
            EmailPhone.Placeholder = "Phone";
            EmailPhone.KeyboardType = UIKeyboardType.PhonePad;
            EmailPhone.Text = "";
            IsEmail = false;

            EmailPhone.ShouldChangeCharacters = (textField, range, replacementString) => {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 10;
            };
        }

        partial void EmailRadioBtn_TouchUpInside(UIButton sender)
        {
            EmailRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_filled.png"), UIControlState.Normal);
            PhoneRadioBtn.SetBackgroundImage(UIImage.FromBundle("circular_empty.png"), UIControlState.Normal);
            EmailPhone.Placeholder = "Email";
            EmailPhone.KeyboardType = UIKeyboardType.EmailAddress;
            EmailPhone.Text = "";
            IsEmail = true;

            EmailPhone.ShouldChangeCharacters = (textField, range, replacementString) => {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 100;
            };


        }

        partial void DealerBtn_TouchUpInside(UIButton sender)
        {
            Debug.WriteLine("Dealer Selected");
            InitialContainer.Hidden = true;
            GuestContainer.Hidden = true;
            DealerContainer.Hidden = false;

            SlideVerticaly(DealerContainer, true, false, 0.5, null);
        }

        partial void GuestBtn_TouchUpInside(UIButton sender)
        {
            Debug.WriteLine("Guest Selected");

            InitialContainer.Hidden = true;
            GuestContainer.Hidden = false;
            DealerContainer.Hidden = true;

            SlideVerticaly(GuestContainer, true, false, 0.5, null);
        }

        public void performNavigate(int index)
        {
            System.Diagnostics.Debug.WriteLine("perform Navigate");
        }

        public void ShowDoneIcon(int index)
        {
            System.Diagnostics.Debug.WriteLine("perform Navigate");
        }

        public void ShowPartialDoneIcon(int index)
        {
            System.Diagnostics.Debug.WriteLine("perform Navigate");
        }
    }

}
