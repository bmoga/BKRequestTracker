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
using System.ComponentModel;

namespace BKRequestTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataClasses1DataContext DB1 = new DataClasses1DataContext();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WireInLINQ();
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            var req_cat = from rc in DB1.tbl_request_catagory_001s select rc;
            foreach (var c in req_cat)
            {
                this.cb_catagory_description.Items.Add(c.catagory_description);
            }
            adjust_catagorydescription();
            adjust_counts();

        }

        private void WireInLINQ()
        {
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_request_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_request_001sViewSource")));
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_request_catagory_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_request_catagory_001sViewSource")));
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_instructions_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_instructions_001sViewSource")));
            dataClasses1DataContexttbl_request_001sViewSource.Source = null;
            dataClasses1DataContexttbl_request_catagory_001sViewSource.Source = null;
            dataClasses1DataContexttbl_instructions_001sViewSource.Source = null;
            dataClasses1DataContexttbl_request_001sViewSource.Source = DB1.tbl_request_001s;
            dataClasses1DataContexttbl_request_catagory_001sViewSource.Source = DB1.tbl_request_catagory_001s;
            dataClasses1DataContexttbl_instructions_001sViewSource.Source = DB1.tbl_instructions_001s;
        }

        private void btn_first_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToFirst();
            adjust_catagorydescription();
            adjust_counts();
        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToLast();
            adjust_catagorydescription();
            adjust_counts();
        }

        private void btn_prior_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToPrevious();
            if (request_view.IsCurrentBeforeFirst)
            {
                request_view.MoveCurrentToFirst();
            }
            adjust_catagorydescription();
            adjust_counts();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToNext();
            if (request_view.IsCurrentAfterLast)
            {
                request_view.MoveCurrentToLast();
            }
            var req_cat = from rc in DB1.tbl_request_catagory_001s join r in DB1.tbl_request_001s on rc.catagory_id equals r.request_catagory select rc;
            adjust_catagorydescription();
            adjust_counts();
        }

        private void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            string sFieldName = "";
            // would have been nice to get the db field name from the control
            if (sender is TextBox)
            {
                TextBox tmpCtrl = sender as TextBox;
                if (tmpCtrl.Name == "tb_request_description")
                {
                    sFieldName = "request_description";
                }
                if (tmpCtrl.Name == "tb_request_date")
                {
                    sFieldName = "request_date";
                }
                if (tmpCtrl.Name == "tb_request_user")
                {
                    sFieldName = "request_user";
                }
            }
            else if (sender is ComboBox)
            {
                ComboBox tmpCtrl = sender as ComboBox;
                if (tmpCtrl.Name == "cb_catagory_description")
                {
                    sFieldName = "catagory_description";
                }
            }
            else if (sender is DatePicker)
            {
                DatePicker tmpCtrl = sender as DatePicker;
                if (tmpCtrl.Name == "dp_date_needed_by")
                {
                    sFieldName = "date_needed_by";
                }
            }

            ICollectionView instructions_view = (this.FindResource("dataClasses1DataContexttbl_instructions_001sViewSource") as CollectionViewSource).View;
             
            Label lbins = this.FindName("lbinstructions") as Label;
            var query = from c in DB1.tbl_instructions_001s where c.column_name == sFieldName as string select c;
            foreach (var c in query)
            {
                lbins.Content = c.instruction_description;
            }
        }

        private void badd_Click(object sender, RoutedEventArgs e)
        {
            this.tb_request_date.IsEnabled = true;
            this.tb_request_user.IsEnabled = true;
            this.bcancel.IsEnabled = true;
            this.badd.IsEnabled = false;
            this.bdelete.IsEnabled = false;
            this.bsave.IsEnabled = true;  // turn true for testing but need to validate all fields have data b4 save
            this.request_idLabel.Visibility = System.Windows.Visibility.Hidden;
            this.lbNew.Visibility = System.Windows.Visibility.Visible;

            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToLast();
            request_view.MoveCurrentToNext();
            this.cb_catagory_description.SelectedIndex = 0;
            this.tb_request_date.Text = System.DateTime.Now.ToString("s");

            adjust_counts();
        }

        private void bdelete_Click(object sender, RoutedEventArgs e)
        {
            this.tb_request_date.IsEnabled = false;
            this.tb_request_user.IsEnabled = false;
            this.bcancel.IsEnabled = false;
            this.badd.IsEnabled = true;
            this.bdelete.IsEnabled = true;
            this.bsave.IsEnabled = false;
            this.request_idLabel.Visibility = System.Windows.Visibility.Visible;
            this.lbNew.Visibility = System.Windows.Visibility.Hidden;

            var deleterequest = from details in DB1.tbl_request_001s where details.request_id.ToString() == this.request_idLabel.Content.ToString() select details;

            foreach (var detail in deleterequest)
            {
                DB1.tbl_request_001s.DeleteOnSubmit(detail);
            }

            DB1.SubmitChanges();
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToFirst();
            adjust_counts(); 
        }

        private void bsave_Click(object sender, RoutedEventArgs e)
        {
            this.tb_request_date.IsEnabled = false;
            this.tb_request_user.IsEnabled = false;
            this.bcancel.IsEnabled = false;
            this.badd.IsEnabled = true;
            this.bdelete.IsEnabled = true;
            this.bsave.IsEnabled = false;
            this.request_idLabel.Visibility = System.Windows.Visibility.Visible;
            this.lbNew.Visibility = System.Windows.Visibility.Hidden;

            int iReqID = 0;
            var req_cat = from rc in DB1.tbl_request_catagory_001s where rc.catagory_description.ToString() == this.cb_catagory_description.Text.ToString() select rc;
            foreach (var c in req_cat)
            {
                iReqID = c.catagory_id;
            }


            var newRequest = new tbl_request_001
            {
                request_date = Convert.ToDateTime(this.tb_request_date.Text),
                request_user = this.tb_request_user.Text,
                request_description = this.tb_request_description.Text,
                request_catagory = iReqID,
                date_needed_by = Convert.ToDateTime(this.dp_date_needed_by.Text)
            };
            DB1.tbl_request_001s.InsertOnSubmit(newRequest);
            DB1.SubmitChanges();
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToFirst();
            adjust_counts();
        }

        private void bcancel_Click(object sender, RoutedEventArgs e)
        {
            this.tb_request_date.IsEnabled = false;
            this.tb_request_user.IsEnabled = false;
            this.bcancel.IsEnabled = false;
            this.badd.IsEnabled = true;
            this.bdelete.IsEnabled = true;
            this.bsave.IsEnabled = false;
            this.request_idLabel.Visibility = System.Windows.Visibility.Visible;
            this.lbNew.Visibility = System.Windows.Visibility.Hidden;

            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            request_view.MoveCurrentToFirst();

            adjust_counts();
        }

        private void adjust_counts()
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            Label lbpos = new Label();
            Label lbmc = new Label();
            lbpos = this.FindName("lbposition") as Label;
            lbmc = this.FindName("lbmaxcount") as Label;
            lbpos.Content = (request_view.CurrentPosition + 1).ToString();
            lbmc.Content = DB1.tbl_request_001s.Count();
        }

        private void adjust_catagorydescription()
        {
            string iReqID = "";
            var req_req = from rc in DB1.tbl_request_001s where rc.request_id.ToString() == this.request_idLabel.Content.ToString() select rc;
            foreach (var c in req_req)
            {
                iReqID = c.request_catagory.ToString();
            }
            var req_cat = from rc in DB1.tbl_request_catagory_001s where rc.catagory_id.ToString() == iReqID select rc;
            foreach (var c in req_cat)
            {
                this.cb_catagory_description.SelectedItem = c.catagory_description;
            }
        }

    }

}
