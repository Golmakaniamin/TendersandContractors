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
using System.Threading.Tasks;
using RTM.Classes;
using System.Threading;

namespace RTM.UserManagement
{
    /// <summary>
    /// Interaction logic for FindUser.xaml
    /// </summary>
    public partial class FindUser : Page
    {
        public FindUser()
        {
            InitializeComponent();
        }

        private void TypeCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                FNameTxt.Text = "";
                LNameTxt.Text = "";
                PositionTxt.Text = "";
                OrgCom.Text = "";
        }
     
        private void TypeCom_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            FNameTxt.Text = "";
            LNameTxt.Text = "";
            PositionTxt.Text = "";
            PositionTxt.SelectedIndex = -1;
            OrgCom.SelectedIndex = -1;
            FNameTxt.Focus();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var entity = new RTMEntities();
            var name = (FNameTxt.Text.Trim()=="")?null :FNameTxt.Text;
            var family = (LNameTxt.Text.Trim() == "") ? null : LNameTxt.Text;
            var organ = (OrgCom.Text.Trim() == "") ? null : OrgCom.Text;
            var position = (PositionTxt.Text.Trim() == "") ? null : PositionTxt.Text;
            List<User> results =new List<User>();
            var loader = new BusyIndicator();
            this.layoutRoot.Children.Add(loader);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    results = DataManagement.SearchUsers(name, family, position,organ);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("تماس با سرور با مشکل مواجه شد");
                }
            }).ContinueWith(delegate
            {
                if (results.Count > 0)
                {
                    Grid.ItemsSource = results;
                }
                else
                {
                    Grid.ItemsSource = null;
                }
                this.layoutRoot.Children.Remove(loader);

            }, TaskScheduler.FromCurrentSynchronizationContext());

                
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var orgs = DataManagement.RetrieveOrganizationChart();
            OrgCom.Items.Clear();
            if (orgs.Count > 0)
            {
                foreach (var item in orgs)
                {
                    OrgCom.Items.Add(item.Title);
                }
            }
            var positions = DataManagement.RetrievePositions();
            foreach (var item in positions)
            {
                var temp = new ComboBoxItem();
                temp.Content = item.PositionTitle;
                temp.Tag = item.PositionId;
                PositionTxt.Items.Add(temp);
            }
            FNameTxt.Text = "";
            LNameTxt.Text = "";
            PositionTxt.Text = "";
            OrgCom.SelectedIndex = -1;
            PositionTxt.SelectedIndex = -1;
            FNameTxt.Focus();
            Grid.ItemsSource = null;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = Grid.SelectedItem as User;
            if (selectedUser == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSelected);
                return;
            }
            AccessRight accessRights = new AccessRight();
            //ThreadStart ts = new ThreadStart(delegate{
            //    accessRights = DataManagement.RetrieveAccessRight(selectedUser.AccessId);
            //    if (accessRights != null)
            //    {
            //        NavigationHandler.NavigateToPageThreadSafe(this, new NewUser(selectedUser, accessRights));
            //    }
            //});
            //Thread t = new Thread(ts);
            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();
            accessRights = DataManagement.RetrieveAccessRight(selectedUser.AccessId);
            if(accessRights!=null)
                NavigationHandler.NavigateToPageThreadSafe(this, new NewUser(selectedUser, accessRights));
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this,new Report.GenralRep.User_Viewer(Grid.ItemsSource.Cast<User>().ToList())); 
        }
    }
}
