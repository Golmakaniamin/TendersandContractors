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

namespace RTM
{
    /// <summary>
    /// Interaction logic for BaseInfo.xaml
    /// </summary>
    public partial class BaseInfo : Page
    {
        private List<EvalStandard>  TechStandardList = new List<EvalStandard>();
        private List<Position> PositionList = new List<Position>();
        private List<ContractorDocument> ContractorDocList = new List<ContractorDocument>();
        private List<IssuingReference> IssuingReferenceList = new List<IssuingReference>();
        private List<TenderingTitle> TenderingTitleList = new List<TenderingTitle>();
        private List<ContractType> ContractTypeList = new List<ContractType>();
        private List<ContractDocument> ContractDocList = new List<ContractDocument>();
        public BaseInfo()
        {
            InitializeComponent();
        }

        private void TypeCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeCom.SelectedIndex)
            {
                case 0:
                    LoadPositions();
                    break;
                case 1:
                    LoadStandards(true);
                    break;
                case 2:
                    LoadStandards(false);
                    break;
                case 3:
                    LoadContractorDocs();
                    break;
                case 4:
                    LoadIssuingReference();
                    break;
                case 5:
                    LoadTenderingTitle();
                    break;
                case 6:
                    LoadContractTypes();
                    break;
                //case 7:
                //    LoadContractDocs();
                //    break;
            }
        }

        private void LoadContractDocs()
        {
            ContractDocList = DataManagement.RetrieveContractDoc();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "نوع سند قرارداد",
                Binding = new Binding("Title")
            });
            //Grid.Columns.Add(new DataGridTextColumn()
            //{
            //    Header = "ایندکس",  
            //    Binding = new Binding("DocumentIndex")
            //});
            Grid.ItemsSource = ContractDocList;
        }

        private void LoadContractTypes()
        {
            ContractTypeList = DataManagement.RetrieveContractType();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "نوع قرارداد",
                Binding = new Binding("ContractType1")
            });
            Grid.ItemsSource = ContractTypeList;
        }

        private void LoadTenderingTitle()
        {
            TenderingTitleList = DataManagement.RetrieveTenderingTitle();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "کد موضوع مناقصه",
                Binding = new Binding("Title")
            });
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "کد سیستمی",
                Binding = new Binding("Code")
            });
            Grid.ItemsSource = TenderingTitleList;
        }

        private void LoadContractorDocs()
        {
            ContractorDocList = DataManagement.RetrieveContractorDocuments();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "عنوان سند",
                Binding = new Binding("Title")
            });
            Grid.ItemsSource = ContractorDocList;
        }

        private void LoadStandards(bool iscontractor)
        {

            if (iscontractor)
            {
                TechStandardList = DataManagement.RetrieveEvalStandards(true, false);
            }
            else
            {
                TechStandardList = DataManagement.RetrieveEvalStandards(false, true);
            }

            Grid.Columns.Clear();

            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "عنوان",
                Binding = new Binding("Title")
            });
            Grid.ItemsSource = TechStandardList;
        }

        private void LoadPositions()
        {
            PositionList = DataManagement.RetrievePositions();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "عنوان نقش",
                Binding = new Binding("PositionTitle")
            });
            Grid.ItemsSource = PositionList;

        }
        private void LoadIssuingReference()
        {
            IssuingReferenceList = DataManagement.RetrieveIssuingReferences();
            Grid.Columns.Clear();
            Grid.Columns.Add(new DataGridTextColumn()
            {
                Header = "عنوان مرجع",
                Binding = new Binding("Title")
            });
            Grid.ItemsSource = IssuingReferenceList;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var busy = new BusyIndicator();
            //root.Children.Add(busy);
            switch (TypeCom.SelectedIndex)
            {
                case 0:
                    DataManagement.UpdatePositions(PositionList);
                    LoadPositions();
                    break;
                case 1:
                    DataManagement.UpdateStandards(TechStandardList, true, false);
                    LoadStandards(true);
                    break;
                case 2:
                    DataManagement.UpdateStandards(TechStandardList, false, true);
                    LoadStandards(false);
                    break;
                case 3:
                    DataManagement.UpdateContractorDocs(ContractorDocList);
                    LoadContractorDocs();
                    break;
                case 4:
                    DataManagement.UpdateIssuingReferences(IssuingReferenceList);
                    LoadIssuingReference();
                    break;
                case 5:
                    DataManagement.UpdateTenderingTitle(TenderingTitleList);
                    LoadTenderingTitle();
                    break;
                case 6:
                    DataManagement.UpdateContractType(ContractTypeList);
                    LoadContractTypes();
                    break;
                //case 7:
                //    DataManagement.UpdateContractDoc(ContractDocList);
                //    LoadContractDocs();
                //    break;
            }
        }

        

    }
}
