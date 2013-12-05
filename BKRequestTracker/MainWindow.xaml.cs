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
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_request_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_request_001sViewSource")));
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_request_catagory_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_request_catagory_001sViewSource")));
            System.Windows.Data.CollectionViewSource dataClasses1DataContexttbl_instructions_001sViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dataClasses1DataContexttbl_instructions_001sViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // dataClasses1DataContextViewSource.Source = [generic data source]
            dataClasses1DataContexttbl_request_001sViewSource.Source = DB1.tbl_request_001s;
            dataClasses1DataContexttbl_request_catagory_001sViewSource.Source = DB1.tbl_request_catagory_001s;
            dataClasses1DataContexttbl_instructions_001sViewSource.Source = DB1.tbl_instructions_001s;

            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
            adjust_catagorydescription();
            adjust_counts();
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
             
            var query = from c in DB1.tbl_instructions_001s where c.column_name == sFieldName as string select c;
            
         //   return query.ToList<DB1.tbl_instructions_001s>();
        }

        private void badd_Click(object sender, RoutedEventArgs e)
        {
            adjust_counts();
        }

        private void bdelete_Click(object sender, RoutedEventArgs e)
        {
            adjust_counts(); 
        }

        private void bsave_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView request_view = (this.FindResource("dataClasses1DataContexttbl_request_001sViewSource") as CollectionViewSource).View;
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
            var req_cat = from rc in DB1.tbl_request_catagory_001s join r in DB1.tbl_request_001s on rc.catagory_id equals r.request_catagory where rc.catagory_id == r.request_catagory select rc;
            this.cb_catagory_description.DataContext = req_cat;
            var cbcd = this.FindName("cb_catagory_description") as ComboBox;
        }
    }

}
