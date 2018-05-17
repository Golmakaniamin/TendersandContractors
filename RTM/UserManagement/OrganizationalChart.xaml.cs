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
using System.Threading.Tasks;

namespace RTM.UserManagement
{
    /// <summary>
    /// Interaction logic for OrganizationalChart.xaml
    /// </summary>
    public partial class OrganizationalChart : Page
    {
        private RTM.OrganizationalChart root = new RTM.OrganizationalChart();
        List<RTM.OrganizationalChart> organs = new List<RTM.OrganizationalChart>();

        public OrganizationalChart()
        {
            InitializeComponent();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            var entity = new RTMEntities();
            var busy = new BusyIndicator();
            this.LayOutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    var organizationchart = entity.OrganizationalCharts;
                    organs = organizationchart.Select(s => s).ToList();
                    root = organs.Where(s => s.ParentNodeId == null).First();
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage("ارتباط با پایگاه داده امکان پذیر نبود");
                    Page_Loaded(sender, e);
                }
            }).ContinueWith(delegate
            { 
                RefreshTreeView();
                this.LayOutRoot.Children.Remove(busy);
                //string text = "";
                //foreach (var item in organs)
                //{
                //    string temp = "";
                //    var t = item;
                //    while (t.OrganizationalChart2!=null)
                //    {
                //        temp += "\t";
                //        t = t.OrganizationalChart2;
                //    }
                //    text += temp + item.Title+"\n";
                //}
            }, TaskScheduler.FromCurrentSynchronizationContext());



        }

        private void RefreshTreeView()
        {
            
            organs = DataManagement.RetrieveOrganizationChart();
            if (organs == null)
                return;
            root = organs.Where(s => s.ParentNodeId == null).First();
            treeView.Items.Clear();
            var t = new TreeViewItem();
            t.Header = root.Title;
            t.Tag = root.ChartNodeId;
            treeView.Items.Add(t);
            PopulateTreeView(t, root, organs);
            //
            // mishe ye kari kard ke item taghir karde expand beshe 
            //
        }

        private void PopulateTreeView(TreeViewItem Node, RTM.OrganizationalChart newChild, List<RTM.OrganizationalChart> entity)
        {
            var t = new TreeViewItem();
            t.Header = newChild.Title;
            t.Tag = newChild.ChartNodeId;
            if (newChild != root)
            {
                Node.Items.Add(t);
            }
            else
            {
                t = Node;
            }
            var children = from nodes in entity
                           where nodes.ParentNodeId == newChild.ChartNodeId
                           select nodes;
            foreach (var node in children)
            {
                PopulateTreeView(t, node, entity);
            }
        }

        private void AddNodeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(treeView.SelectedValue.ToString()) || string.IsNullOrEmpty(OrganTxt.Text.Trim()))
            {
                return;
            }
            var newOrgan = new RTM.OrganizationalChart();
            var entity = new RTMEntities();
            string selectedNode = ((TreeViewItem)(treeView.SelectedItem)).Header.ToString();
            int nodeId = 0;
            if (((TreeViewItem)(treeView.SelectedItem)).Tag == null)
            {
                return;
            }
            if (!Int32.TryParse(((TreeViewItem)(treeView.SelectedItem)).Tag.ToString(), out nodeId))
            {
                return;
            }
            newOrgan.Title = OrganTxt.Text;
            newOrgan.ParentNodeId = nodeId;
            try
            {
                entity.OrganizationalCharts.AddObject(newOrgan);
                entity.SaveChanges();
                ErrorHandler.NotifyUser(Errors.Saved);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر امکان دسترسی به سرور وجود ندارد");
                return;
            }
            RefreshTreeView();
        }

        private void EditNodeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int nodeId;
                if (!Int32.TryParse(((TreeViewItem)(treeView.SelectedItem)).Tag.ToString(), out nodeId))
                    return;
                var entity = new RTMEntities();
                RTM.OrganizationalChart changeItem = entity.OrganizationalCharts.Where(s => s.ChartNodeId == nodeId).First();
                changeItem.Title = OrganTxt.Text;
                entity.SaveChanges();
                ErrorHandler.NotifyUser(Errors.Saved);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر امکان دسترسی به سرور وجود ندارد");
            }
            RefreshTreeView();
        }

        private void DeleteNodeBtn_Click(object sender, RoutedEventArgs e)
        {
            int nodeId;
            if (!Int32.TryParse(((TreeViewItem)(treeView.SelectedItem)).Tag.ToString(), out nodeId))
                return;
            if (organs.Where(s => s.ParentNodeId == nodeId).Count() > 0)
            {
                ErrorHandler.ShowErrorMessage("تنها امکان حذف برگ ها وجود دارد");
                return;
            }

            var entity = new RTMEntities();
            try
            {
                RTM.OrganizationalChart delete = entity.OrganizationalCharts.Where(s => s.ChartNodeId == nodeId).First();
                entity.OrganizationalCharts.DeleteObject(delete);
                entity.SaveChanges();
                ErrorHandler.NotifyUser(Errors.Deleted);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر امکان دسترسی به سرور وجود ندارد");
                return;
            }

            RefreshTreeView();
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                OrganTxt.Text = ((TreeViewItem)(treeView.SelectedItem)).Header.ToString();
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

    }
}
