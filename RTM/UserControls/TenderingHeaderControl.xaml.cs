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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RTM.Classes;

namespace RTM
{
	/// <summary>
	/// Interaction logic for TenderingHeaderControl.xaml
	/// </summary>
	public partial class TenderingHeaderControl : UserControl
	{
        private ContractorRequest cr;
        public ContractorRequest CurrentRequest
        {
            set
            {
                cr = value;
                this.DataContext = CurrentRequest;
                TenderingNumberTxt.Content = DataManagement.RetrieveContractorRequestTendering(CurrentRequest).TenderingNumber;
            }
            get
            {
                return cr;
            }
        }
		public TenderingHeaderControl()
		{
			this.InitializeComponent();
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
	}
}