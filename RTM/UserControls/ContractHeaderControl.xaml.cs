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


namespace RTM
{
	/// <summary>
	/// Interaction logic for ContractHeaderControl.xaml
	/// </summary>
    /// 

    
	public partial class ContractHeaderControl : UserControl
	{
        private Contract cr;
        public Contract CurrentContract
        {
            set
            {
                cr = value;
                this.DataContext = CurrentContract;
            }
            get
            {
                return cr;
            }
        }
		public ContractHeaderControl()
		{
			this.InitializeComponent();
		}
	}
}