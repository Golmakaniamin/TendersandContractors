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

namespace RTM.Contracts
{
    /// <summary>
    /// Interaction logic for NewPaymentTransfer.xaml
    /// </summary>
    public partial class NewPaymentTransfer : Page
    {
        public Contract CurrentContract;
        public PaymentDraft CurrentDraft { set; get; }
        private List<PaymentDraftTranscript> Transcripts = new List<PaymentDraftTranscript>();
        private string Paymankar;
        private string Moshaver;
        private string VahedNezarat;
        private string VahedNezaratAlieh;
        public NewPaymentTransfer(Contract x)
        {
            CurrentContract = x;
            CurrentDraft = new PaymentDraft();
            InitializeComponent();
        }
        public NewPaymentTransfer(PaymentDraft d)
        {
            CurrentDraft = d;
            InitializeComponent();
            object sender = new object();
            RoutedEventArgs e = new RoutedEventArgs();
            CalcBtn_Click(sender, e);
        }


        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            decimal ContractFee;
            decimal prehavalefee;

            if (CurrentDraft.PaymentDraftId == 0)
            {
                CurrentDraft.ContractId = CurrentContract.Contractid;
            }
            int ContractTypeId = DataManagement.RetrieveContractTypeId(CurrentDraft);
            ContractFee = (Int64)DataManagement.RetrieveContractBudget(CurrentDraft);
            prehavalefee = DataManagement.RetrieveSumPreHavale(ContractTypeId, CurrentDraft);
            prehavalefee += Convert.ToDecimal(t1.Text);

            if (Convert.ToInt64(prehavalefee) > Convert.ToInt64(ContractFee))
            {
                ErrorHandler.ShowErrorMessage("مبلغ كاركرد حواله از سقف مبلغ قرارداد بالاتر ميباشد");
                return;
            }
            if (Validate())
                return;
            CalcBtn_Click(sender, e);
            try
            {
                 if (CurrentDraft.PaymentDraftId == 0)
                {
                    CurrentDraft.ContractId = CurrentContract.Contractid;
                    DataManagement.CreatePaymentDraft(CurrentDraft);
                }
                else
                {
                    CurrentDraft.PermanentRecord = false;
                    DataManagement.UpdatePaymentDrafts(CurrentDraft);
                }
                DataManagement.UpdatePaymentDraftTranscripts(Transcripts, CurrentDraft);
                Transcripts = DataManagement.RetrievePaymentDraftTranscripts(CurrentDraft);
                TranscriptGrid.ItemsSource = Transcripts;
                TranscriptGrid.Items.Refresh();
                ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
            }
            catch
            {
                ErrorHandler.NotifyUser("ثبت با مشکل مواجه شد");

            }
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            var temp = DataManagement.RetrievePaymentDraftTranscripts(CurrentDraft);

            Transcripts = temp;
            //Added By Naseri 920630
            Paymankar = DataManagement.RetrieveContractInformation(CurrentContract);
            Moshaver = DataManagement.RetrieveContractInformationMoshaver(CurrentContract);
            VahedNezarat = DataManagement.RetrieveContractInformationVahedNezarat(CurrentContract);
            VahedNezaratAlieh = DataManagement.RetrieveContractInformationVahedNezaratAlieh(CurrentContract);
            //Added By Naseri 920630
            if (CurrentDraft.PaymentDraftId == 0)
            {
                if (VahedNezaratAlieh != string.Empty && VahedNezaratAlieh != null)
                {
                    Transcripts.Add(new PaymentDraftTranscript()
                    {
                        Location = VahedNezaratAlieh,
                        FullAttachment = true,
                        AttachmentCount = true
                    });
                }
                if (VahedNezarat != string.Empty && VahedNezarat != null)
                {
                    Transcripts.Add(new PaymentDraftTranscript()
                    {
                        Location = VahedNezarat,
                        FullAttachment = true,
                        AttachmentCount = true
                    });
                }
                Transcripts.Add(new PaymentDraftTranscript()
                {
                    Location = "اداره پیمان و رسیدگی",
                    FullAttachment = true,
                    AttachmentCount = true
                });
                Transcripts.Add(new PaymentDraftTranscript()
                {
                    Location = "اداره برنامه ريزي و بودجه",
                    FullAttachment = true,
                    AttachmentCount = true
                });


                //Added By Naseri 920630
                if (Paymankar != string.Empty && Paymankar != null)
                {
                    Transcripts.Add(new PaymentDraftTranscript()
                    {
                        Location = Paymankar,
                        FullAttachment = true,
                        AttachmentCount = true
                    });
                }
                if (Moshaver != string.Empty && Moshaver != null)
                {
                    Transcripts.Add(new PaymentDraftTranscript()
                    {
                        Location = Moshaver,
                        FullAttachment = true,
                        AttachmentCount = true
                    });
                }
                Transcripts.Add(new PaymentDraftTranscript()
                {
                    Location = "بایگانی اداره کل",
                    FullAttachment = true,
                    AttachmentCount = true
                });

                //Added By Naseri 920630
            }
            TranscriptGrid.ItemsSource = Transcripts;
            Type1Com.ItemsSource = new List<string>() { "", "صورت وضعیت", "پیش پرداخت", "علی الحساب", "تعدیل", "ما به التفاوت مصالح", "ما به التفاوت قير" };
            Type2Com.ItemsSource = new List<string>() { "", "قطعی", "موقت", "قسط", "نظارت کارگاهی", "نظارت عاليه" };
            Type1Com.DataContext = Type2Com.DataContext = CurrentDraft;

        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (d1.Text.Trim() == "") d1.Text = "0";
                //                l1.Content = (((double)CurrentDraft.CurrentSituationDraft - (double)(CurrentDraft.PerviousSituationDraft)) * ((double)CurrentDraft.EmployerInsurancePercentage / 100)).ToString("N0");
                l1.Content = (int)(((double)CurrentDraft.CurrentSituationDraft - (double)(CurrentDraft.PerviousSituationDraft)) * ((double)CurrentDraft.EmployerInsurancePercentage / 100));
                CurrentDraft.PayableAmount = (decimal)((double)CurrentDraft.CurrentSituationDraft - (double)(CurrentDraft.PerviousSituationDraft));
                CurrentDraft.PayableAmount = (decimal)((double)CurrentDraft.PayableAmount + Convert.ToInt32(l1.Content.ToString()));

                if (d2.Text.Trim() == "") d2.Text = "0";
                l2.Content = ((double.Parse(d2.Text) / 100) * (double)CurrentDraft.PayableAmount).ToString("N0");
                if (d4.Text.Trim() == "") d4.Text = "0";
                l4.Content = ((double.Parse(d4.Text) / 100) * (double)CurrentDraft.PayableAmount).ToString("N0");
                if (d5.Text.Trim() == "") d5.Text = "0";
                l5.Content = ((double.Parse(d5.Text) / 100) * (double)CurrentDraft.PayableAmount).ToString("N0");
                if (d6.Text.Trim() == "") d6.Text = "0";
                l6.Content = ((double.Parse(d6.Text) / 100) * (double)CurrentDraft.PayableAmount).ToString("N0");
            }
            catch (Exception esfd)
            {
                ErrorHandler.ShowErrorMessage(esfd.Message);
            }
        }

        private void d4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void NumberTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // فعلا غيرفعال شد
            //if (!UniqueConstraints.ValidPaymentDraft(NumberTxt.Text, CurrentDraft))
            //{
            //    ErrorHandler.ShowErrorMessage(Errors.InvalidNumber);
            //    CurrentDraft.PaymentDraftNumber = "";
            //}
        }

        public bool Validate()
        {
            if (t1.Text.Trim() == "")
            {
                ErrorHandler.NotifyUser("کارکرد فعلی وارد نشده");
                return true;
            }
            if (t2.Text.Trim() == "")
            {
                ErrorHandler.NotifyUser("کارکرد قبلی وارد نشده");
                return true;
            }

            if (ReqDateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("تاریخ صدور وارد نشده است");
                return true;
            }

            //if (NumberTxt.Text == "")
            //{
            //    ErrorHandler.NotifyUser("شماره حواله وارد نشده است");
            //    return true;
            //}
            return false;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TranscriptGrid.SelectedIndex == -1)
            {
                MessageBox.Show(Errors.NotSelected);
                return;
            }
            try
            {
                Transcripts.Remove(TranscriptGrid.SelectedItem as PaymentDraftTranscript);
                TranscriptGrid.Items.Refresh();
            }
            catch (System.Exception ex)
            {

            }
        }
        private void ShowDetailInfo()
        {

        }

        private void Type1Com_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    Type1Com.Text = string.Empty;
                    break;
            }
        }
        
        private void Type2Com_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    Type2Com.Text = string.Empty;
                    break;
            }
        }
    }
}
