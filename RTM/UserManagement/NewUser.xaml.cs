using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RTM.Classes;

namespace RTM.UserManagement
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        private byte[] UserImage = null;
        private User PageUser { set; get; }
        private AccessRight UserAccessRight { set; get; }
        bool Profile = false;
        public NewUser()
        {
            InitializeComponent();
            EditBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            PageUser = new User();
        }

        public NewUser(RTM.User user, RTM.AccessRight userAccess)
        {
            InitializeComponent();
            PageUser = user;
            UserAccessRight = userAccess;
            //OrgTxt.SelectedIndex =
            SaveBtn.IsEnabled = false;


        }
        public NewUser(RTM.User user, RTM.AccessRight userAccess,bool boolean)
        {
            Profile = boolean;
            InitializeComponent();
            PageUser = user;
            UserAccessRight = userAccess;
            FNameTxt.IsEnabled = false;
            LNameTxt.IsEnabled = false;
            OrgTxt.IsEnabled = false;
            PositionTxt.IsEnabled = false;
            UserNameTxt.IsEnabled = false;
            SocialTxt.IsEnabled = false;
            ContractsSubTick.IsEnabled = false;
            RegulationsSubTick.IsEnabled = false;
            TenderingSubTick.IsEnabled = false;
            TenderingArchiveSubTick.IsEnabled = false;
            UserManageRightTick.IsEnabled = false;
            consultCommittee.IsEnabled = false;
            techCommittee.IsEnabled = false;
            TenderingComite.IsEnabled = false;
           
            SaveBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
            rectangle1.Visibility = Visibility.Visible;
            DisableAllTiks(this.layoutRoot);

        }
        public void DisableAllTiks(DependencyObject destination)
        {
            int counter = VisualTreeHelper.GetChildrenCount(destination );
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(destination, i);
                if (child is CheckBox)
                {
                    (child as CheckBox).IsEnabled = false;
                }
                else
                {
                    DisableAllTiks(child);
                }

            }
        }
        private void TenderingSubTick_Checked(object sender, RoutedEventArgs e)
        {
            Read1Tick.IsEnabled = true;
            Write1Tick.IsEnabled = true;
            Delete1Tick.IsEnabled = true;
            Permanent1Tick.IsEnabled = true;
            Log1Tick.IsEnabled = true;
        }

        private void TenderingSubTick_Unchecked(object sender, RoutedEventArgs e)
        {
            Read1Tick.IsChecked = false;
            Write1Tick.IsChecked = false;
            Delete1Tick.IsChecked = false;
            Permanent1Tick.IsChecked = false;
            Log1Tick.IsChecked = false;
            Read1Tick.IsEnabled = false;
            Write1Tick.IsEnabled = false;
            Delete1Tick.IsEnabled = false;
            Permanent1Tick.IsEnabled = false;
            Log1Tick.IsEnabled = false;
        }

        private void TenderingArchiveSubTick_Checked(object sender, RoutedEventArgs e)
        {
            Read2Tick.IsEnabled = true;
            Write2Tick.IsEnabled = true;
            Delete2Tick.IsEnabled = true;
            Permanent2Tick.IsEnabled = true;
            Log2Tick.IsEnabled = true;
        }

        private void TenderingArchiveSubTick_Unchecked(object sender, RoutedEventArgs e)
        {
            Read2Tick.IsChecked = false;
            Write2Tick.IsChecked = false;
            Delete2Tick.IsChecked = false;
            Permanent2Tick.IsChecked = false;
            Log2Tick.IsChecked = false;
            Read2Tick.IsEnabled = false;
            Write2Tick.IsEnabled = false;
            Delete2Tick.IsEnabled = false;
            Permanent2Tick.IsEnabled = false;
            Log2Tick.IsEnabled = false;
        }

        private void ContractsSubTick_Checked(object sender, RoutedEventArgs e)
        {
            PaymentManageCheck.IsEnabled = true;
            ContractManage.IsEnabled = true;
            Log3Tick.IsEnabled = true;
            ManagingContractAccessTick.IsEnabled = true;
            Read3Tick.IsEnabled = true;
        }

        private void ContractsSubTick_Unchecked(object sender, RoutedEventArgs e)
        {
            PaymentManageCheck.IsChecked = false;
            ContractManage.IsChecked = false;
            Log3Tick.IsChecked = false;
            PaymentManageCheck.IsEnabled = false;
            ContractManage.IsEnabled = false;
            Log3Tick.IsEnabled = false;
            Read3Tick.IsEnabled = false;
            ManagingContractAccessTick.IsEnabled = false;
        }

        private void RegulationsSubTick_Checked(object sender, RoutedEventArgs e)
        {
            Read4Tick.IsEnabled = true;
            Write4Tick.IsEnabled = true;
            Delete4Tick.IsEnabled = true;
            Permanent4Tick.IsEnabled = true;
            Log4Tick.IsEnabled = true;
        }

        private void RegulationsSubTick_Unchecked(object sender, RoutedEventArgs e)
        {
            Read4Tick.IsChecked = false;
            Write4Tick.IsChecked = false;
            Delete4Tick.IsChecked = false;
            Permanent4Tick.IsChecked = false;
            Log4Tick.IsChecked = false;
            Read4Tick.IsEnabled = false;
            Write4Tick.IsEnabled = false;
            Delete4Tick.IsEnabled = false;
            Permanent4Tick.IsEnabled = false;
            Log4Tick.IsEnabled = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Profile)
            NavigationHandler.ForceAccessRights(this, SubSystem.UserManagement);

            var organs = DataManagement.RetrieveOrganizationChart();
            foreach (var item in organs)
            {
                var temp = new ComboBoxItem();
                temp.Content = item.Title;
                temp.Tag = item.ChartNodeId;
                OrgTxt.Items.Add(temp);
            }

            var positions = DataManagement.RetrievePositions();
            foreach (var item in positions)
            {
                var temp = new ComboBoxItem();
                temp.Content = item.PositionTitle;
                temp.Tag = item.PositionId;
                PositionTxt.Items.Add(temp);
            }
            if (PageUser.UserId != 0)
            {
                AddUserData();
            }
            if (Profile)
                return;
            if (Read1Tick.IsChecked==true || Write1Tick.IsChecked==true || Delete1Tick.IsChecked==true || Permanent1Tick.IsChecked==true || Log1Tick.IsChecked==true )
                TenderingSubTick.IsChecked=true;
            if (Read2Tick.IsChecked == true || Write2Tick.IsChecked == true || Delete2Tick.IsChecked == true || Permanent2Tick.IsChecked == true || Log2Tick.IsChecked == true)
                TenderingArchiveSubTick.IsChecked = true;
            if ( PaymentManageCheck.IsChecked==true || ContractManage.IsChecked==true || ManagingContractAccessTick.IsChecked==true|| Read3Tick.IsChecked==true || Log3Tick.IsChecked==true)
                ContractsSubTick.IsChecked = true;
            if (Read4Tick.IsChecked == true || Write4Tick.IsChecked == true || Delete4Tick.IsChecked == true || Permanent4Tick.IsChecked == true || Log4Tick.IsChecked == true)
                RegulationsSubTick.IsChecked = true;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FNameTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (LNameTxt.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (SocialTxt.Text.Length != 10) { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (UserNameTxt.Text == "") { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (passwordBox1.Password == "") { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (passwordBox2.Password == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (FNameTxt.Text == "" || LNameTxt.Text == "" || SocialTxt.Text == "" || UserNameTxt.Text == "" || passwordBox1.Password == "" || passwordBox2.Password == "")
            {
                ErrorHandler.ShowErrorMessage("خطا در ورود اطلاعات");
                return;
            }
            if (passwordBox1.Password != passwordBox2.Password)
            {
                ErrorHandler.ShowErrorMessage("عدم تطابق رمزهای عبور");
                return;
            }
            if (SocialTxt.Text.Length != 10)
            {
                ErrorHandler.ShowErrorMessage("شماره شناسنامه باید 10 رقمی باشد");
                return;
            }
            CreateUser();
        }

        private void CreateUser()
        {
            int accessId = DataManagement.CreateAccessRight(Read3Tick.IsChecked, true, true,
                true, Read1Tick.IsChecked, Write1Tick.IsChecked, Delete1Tick.IsChecked, Permanent1Tick.IsChecked,
                Read2Tick.IsChecked, Write2Tick.IsChecked, Delete2Tick.IsChecked, Read4Tick.IsChecked, Write4Tick.IsChecked, Delete4Tick.IsChecked, Permanent4Tick.IsChecked, Log3Tick.IsChecked,
                Log4Tick.IsChecked, Log1Tick.IsChecked, Log2Tick.IsChecked, UserManageRightTick.IsChecked, Permanent2Tick.IsChecked, Write3Tick.IsChecked);
            int positionId = Int32.Parse(((ComboBoxItem)(PositionTxt.SelectedItem)).Tag.ToString());
            int organId = Int32.Parse(((ComboBoxItem)(OrgTxt.SelectedItem)).Tag.ToString());
            var res = DataManagement.CreateUser(UserNameTxt.Text, passwordBox1.Password, UserImage, FNameTxt.Text, LNameTxt.Text,
            SocialTxt.Text, TelTxt.Text, StatusTxt.Text, positionId, organId, accessId, techCommittee.IsChecked, consultCommittee.IsChecked,TenderingComite.IsChecked,ContractManage.IsChecked,PaymentManageCheck.IsChecked,ManagingContractAccessTick.IsChecked);
            if (!res)
                return;
            MessageBox.Show("ثبت با موفقیت انجام شد لطفا به صفحه قبل برگردید");
            SaveBtn.IsEnabled = false;
        }

        private void EditUser()
        {
            int accessId = DataManagement.EditAccessRight(Read3Tick.IsChecked, true, true, true, Read1Tick.IsChecked, Write1Tick.IsChecked, Delete1Tick.IsChecked, Permanent1Tick.IsChecked,
                Read2Tick.IsChecked, Write2Tick.IsChecked, Delete2Tick.IsChecked, Read4Tick.IsChecked, Write4Tick.IsChecked, Delete4Tick.IsChecked, Permanent4Tick.IsChecked, Log3Tick.IsChecked,
                Log4Tick.IsChecked, Log1Tick.IsChecked, Log2Tick.IsChecked, UserManageRightTick.IsChecked,  Permanent2Tick.IsChecked,Write3Tick.IsChecked, UserAccessRight.AccessId);
            int positionId = Int32.Parse(((ComboBoxItem)(PositionTxt.SelectedItem)).Tag.ToString());
            int organId = Int32.Parse(((ComboBoxItem)(OrgTxt.SelectedItem)).Tag.ToString());
            DataManagement.EditUser(UserNameTxt.Text, passwordBox1.Password, UserImage, FNameTxt.Text, LNameTxt.Text,
            SocialTxt.Text, TelTxt.Text, StatusTxt.Text, positionId, organId, accessId, PageUser.UserId, techCommittee.IsChecked, consultCommittee.IsChecked, TenderingComite.IsChecked, ContractManage.IsChecked, PaymentManageCheck.IsChecked,ManagingContractAccessTick.IsChecked);
            MessageBox.Show("ویرایش با موفقیت انجام شد لطفا به صفحه قبل برگردید");
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileLoc = OpenFileHandler.GetFileLocation("عکس");
            if (fileLoc != "")
            {
                UserImage = OpenFileHandler.GetFileFromLocation(fileLoc);
            }
            try
            {
            	image.Source = OpenFileHandler.RetrieveImage(UserImage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("عکس داده شده صحیح نبود");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FNameTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (LNameTxt.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (SocialTxt.Text.Length != 10) { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (UserNameTxt.Text == "") { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (passwordBox1.Password == "") { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (passwordBox2.Password == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (FNameTxt.Text == "" || LNameTxt.Text == "" || SocialTxt.Text == "" || UserNameTxt.Text == "" || passwordBox1.Password == "" || passwordBox2.Password == "")
            {
                ErrorHandler.ShowErrorMessage("خطا در ورود اطلاعات");
                return;
            }
            if (passwordBox1.Password != passwordBox2.Password)
            {
                ErrorHandler.ShowErrorMessage("عدم تطابق رمزهای عبور");
                return;
            }
            if (SocialTxt.Text.Length!=10)
            {
                ErrorHandler.ShowErrorMessage("کد ملی باید 10 رقمی باشد");
                return;
            }
            EditUser();
        }

        private void AddUserData()
        {
            FNameTxt.Text = PageUser.Name;
            LNameTxt.Text = PageUser.Family;
            SocialTxt.Text = PageUser.SocialNumber;
            TelTxt.Text = PageUser.PhoneNumber;
            foreach (var item in OrgTxt.Items)
            {
                var x = item as ComboBoxItem;
                if ((int)x.Tag == PageUser.OrganizationPosition)
                {
                    OrgTxt.SelectedIndex = OrgTxt.Items.IndexOf(x);
                    break;
                }
            }
            foreach (var item in PositionTxt.Items)
            {
                var x = item as ComboBoxItem;
                if ((int)x.Tag == PageUser.PositionId)
                {
                    PositionTxt.SelectedIndex = PositionTxt.Items.IndexOf(x);
                    break;
                }
            }
            UserNameTxt.IsEnabled = false;
            UserNameTxt.Text = PageUser.Username;
            StatusTxt.Text = PageUser.Status;
            Read1Tick.IsChecked = UserAccessRight.TenderingRead;
            Read2Tick.IsChecked = UserAccessRight.TenderingArchiveRead;
            Read3Tick.IsChecked = UserAccessRight.ContractRead;
            Read4Tick.IsChecked = UserAccessRight.RegulationRead;
            Write1Tick.IsChecked = UserAccessRight.TenderingWrite;
            Write2Tick.IsChecked = UserAccessRight.TenderingArchiveWrite;
            Write3Tick.IsChecked = UserAccessRight.ContractWrite;
            Write4Tick.IsChecked = UserAccessRight.RegulationWrite;
            Delete1Tick.IsChecked = UserAccessRight.TenderingDelete;
            Delete2Tick.IsChecked = UserAccessRight.TenderingArchiveDelete;
            Delete3Tick.IsChecked = true;
            Delete4Tick.IsChecked = UserAccessRight.RegulationDelete;
            Permanent1Tick.IsChecked = UserAccessRight.TenderingPermanentWrite;
            Permanent2Tick.IsChecked = UserAccessRight.TenderingArchivePermanentWrite;
            Permanent3Tick.IsChecked = true;
            Permanent4Tick.IsChecked = UserAccessRight.RegulationPermanentWrite;
            Log1Tick.IsChecked = UserAccessRight.TenderingLog;
            Log2Tick.IsChecked = UserAccessRight.TenderingArchiveLog;
            Log3Tick.IsChecked = UserAccessRight.ContractLog;
            Log4Tick.IsChecked = UserAccessRight.RegulationLog;
            TenderingComite.IsChecked = PageUser.TenderingCommittee;
            PaymentManageCheck.IsChecked = PageUser.PaymentDraftCommittee;
            ContractManage.IsChecked = PageUser.ManagingPaymentDraft;
            UserManageRightTick.IsChecked = UserAccessRight.CreatingUser;
            passwordBox1.Password = passwordBox2.Password = PageUser.Password;
            consultCommittee.IsChecked = PageUser.ConsultantCommittee;
            techCommittee.IsChecked = PageUser.TechnicalCommittee;
            ManagingContractAccessTick.IsChecked = PageUser.ManagingContractAccess;
            if (PageUser.Picture != null)
            {
                image.Source = OpenFileHandler.RetrieveUserImage(PageUser);
            }
            UserImage = PageUser.Picture;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("این کاربر پاک شود ؟", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    DataManagement.DeleteUser(PageUser.UserId);
                    NavigationService.GoBack();
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage("در حال حاضر امکان اجرای این عملیات وجود ندارد");
                }
            }
        }

        private void SocialTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void SocialTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (UniqueConstraints.ValidSocialSecurityNumber(SocialTxt.Text, PageUser) == false)
            {
                ErrorHandler.ShowErrorMessage(Errors.InvalidNumber);
                SocialTxt.Text = "";
            }
        }

        private void SocialTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x) && x != ',')
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void ContractManage_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}
