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

namespace RTM.Regulations
{
    /// <summary>
    /// Interaction logic for RegulationsMainMenu.xaml
    /// </summary>
    public partial class RegulationsMainMenu : Page
    {
        public RegulationsMainMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPageWithMode(this,new RTM.Regulations.RegulationsPage1(),NavigationMethod.NewMode,SubSystem.Regulation,false);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RegulationsSearch());
        }
    }
}
