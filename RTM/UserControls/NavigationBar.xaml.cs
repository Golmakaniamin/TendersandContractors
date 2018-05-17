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

namespace RTM.UserControls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public List<JournalEntry> itemsList = new List<JournalEntry>();
        public List<JournalEntry> ItemsList
        {
            set
            {
                itemsList = value;
                this.listBox.ItemsSource = itemsList;
            }
            get
            {
                return itemsList;
            }
        }
      
        public NavigationBar()
        {
            InitializeComponent();
        }
    }
}
