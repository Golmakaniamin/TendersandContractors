using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using RTM.Classes;
using RTM.UserManagement;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RTM
{
    public delegate void ChangePage();
    public class UserPackage
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
	public partial class LoginPage
	{
        private BusyIndicator busy = new BusyIndicator();
        public static event ChangePage changePage;
        BackgroundWorker bw = new BackgroundWorker();
        
		public LoginPage()
		{
			this.InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            UserName.Focus();
			// Insert code required on object creation below this point.
		}

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LayoutRoot.Children.Remove(busy);
            changePage();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var user = e.Argument as UserPackage;

            RTM.User users = new RTM.User();
            try
            {
                var entity = new RTMEntities();
                users = DataManagement.AuthenticateUser(user.UserName, user.Password);
                if (users != null)
                {
                    UserData.CurrentUser = users;
                    UserData.CurrentPoistion = entity.Positions.Where(s => s.PositionId == UserData.CurrentUser.PositionId).First();
                    UserData.CurrentAccessRight = entity.AccessRights.Where(s => s.AccessId == UserData.CurrentUser.AccessId).First();
                    UserData.OrganizationalPosition = entity.OrganizationalCharts.Where(s => s.ChartNodeId == UserData.CurrentUser.OrganizationPosition).First();
                    entity.Users.Where(s => s.UserId == UserData.CurrentUser.UserId).FirstOrDefault().LastLogin = DateTime.Now;
                    entity.SaveChanges();
                    NavigationHandler.NavigateToPageThreadSafe(this, "UserManagement/StartPage.xaml", false);
                }
                else
                {
                    ErrorHandler.ShowErrorMessage("نام کاربری یا کلمه عبور اشتباه است");
                    Password.Dispatcher.BeginInvoke((Action)delegate
                    {
                        Password.Password = "";
                    }, System.Windows.Threading.DispatcherPriority.Normal);
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("ارتباط با سرور امکان پذیر نیست" + ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.LayoutRoot.Children.Add(busy);
                string username = UserName.Text;
                string password = Password.Password;
                bw.RunWorkerAsync(new UserPackage { UserName = username, Password = Password.Password });
                //Task.Factory.StartNew(delegate
                //{
                //    var entity = new RTMEntities();
                //    List<User> users = new List<User>();
                //    users = entity.AuthenticateUser(username, password).ToList();
                //    if (users.Count > 0)
                //    {
                //        UserData.CurrentUser = users[0];
                //        UserData.CurrentPoistion = entity.Positions.Where(s => s.PositionId == UserData.CurrentUser.PositionId).First();
                //        UserData.CurrentAccessRight = entity.AccessRights.Where(s => s.AccessId == UserData.CurrentUser.AccessId).First();
                //        UserData.OrganizationalPosition = entity.OrganizationalCharts.Where(s => s.ChartNodeId == UserData.CurrentUser.OrganizationPosition).First();
                //        NavigationHandler.NavigateToPageThreadSafe(this, "UserManagement/StartPage.xaml", false);

                //    }
                //    else
                //    {
                //        MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است");
                //    }
                //}, TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (System.Exception ex)
            {
                this.LayoutRoot.Children.Remove(busy);
                ErrorHandler.ShowErrorMessage("ارتباط با سرور امکان پذیر نیست");
            }
        }

        private void LayoutRoot_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                button_Click(sender, e);
        }
	}
}