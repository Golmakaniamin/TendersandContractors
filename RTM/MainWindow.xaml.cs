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
using System.Threading;
using RTM.Classes;
using System.Diagnostics;

namespace RTM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public DateTime Date { set; get; }
        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(1065);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(1065);
            LoginPage.changePage += new ChangePage(x_changePage);
        }

        void x_changePage()
        {
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoBack)
            {
                MainFrame.NavigationService.GoBack();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            this.NavBar.ItemsList = MainFrame.BackStack.Cast<JournalEntry>().Select(p => p).Reverse().ToList();
        }

        void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedIndex == -1)
                return;
            if (ErrorHandler.PromptUserForPermision("آیا مایل هستید از این صفحه خارج شوید؟") == MessageBoxResult.No)
            {
                (sender as ListBox).SelectedIndex = -1;
                return;
            }

            int i = (sender as ListBox).Items.Count - (sender as ListBox).SelectedIndex;
            for (; i > 0 && (sender as ListBox).SelectedIndex != -1; i--)
                MainFrame.NavigationService.GoBack();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavBar.listBox.SelectionChanged += new SelectionChangedEventHandler(listBox_SelectionChanged);

        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                HelpBtn_Click();
            }
        }
        private void HelpBtn_Click()
        {
            try
            {
                Process.Start(@"HelpFile\Help.chm");
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("فایل راهنما یافت نشد");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            HelpBtn_Click();
        }
    }
}
