using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqPlaygroundUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SourceData = LinqPlayground.Queries.GetPeopleWithFirstName("Eric", 5);
            lblNumberOfRecords.Content = SourceData.Count();
        }



        public IEnumerable<object> SourceData
        {
            get { return (IEnumerable<object>)GetValue(SourceDataProperty); }
            set { SetValue(SourceDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceDataProperty =
            DependencyProperty.Register("SourceData", typeof(IEnumerable<object>), typeof(MainWindow), new PropertyMetadata(new List<object>(), OnSourceDataPropertyChanged));

        private static void OnSourceDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindow)d).dataGrid.ItemsSource = (IEnumerable<object>)e.NewValue;
        }

        public IEnumerable<object> ExtensionMethodsSourceData
        {
            get { return (IEnumerable<object>)GetValue(ExtensionMethodsSourceDataProperty); }
            set { SetValue(ExtensionMethodsSourceDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtensionMethodsSourceDataProperty =
            DependencyProperty.Register("ExtensionMethodsSourceData", typeof(IEnumerable<object>), typeof(MainWindow), new PropertyMetadata(new List<object>(), OnExtensionMethodsSourceDataPropertyChanged));

        private static void OnExtensionMethodsSourceDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindow)d).dgIExtensionMethods.ItemsSource = (IEnumerable<object>)e.NewValue;
        }

        private void executeAllNamesCount_Click(object sender, RoutedEventArgs e)
        {
            SourceData = new List<object>();
            lblNumberOfRecords.Content = LinqPlayground.Queries.GetNumPeople();
        }

        private void executeEricNameCount_Click(object sender, RoutedEventArgs e)
        {
            SourceData = new List<object>();
            lblNumberOfRecords.Content = LinqPlayground.Queries.GetNumPeopleWithFirstName("Eric");
        }

        private void executeAlyssaNamesCount_Click(object sender, RoutedEventArgs e)
        {
            SourceData = new List<object>();
            lblNumberOfRecords.Content = LinqPlayground.Queries.GetNumPeopleWithFirstName("Alyssa");
        }

        private void executeGetErics_Click(object sender, RoutedEventArgs e)
        {
            SourceData = LinqPlayground.Queries.GetPeopleWithFirstName("Eric");
            lblNumberOfRecords.Content = SourceData.Count(); 
        }

        private void executeGetAlyssas_Click(object sender, RoutedEventArgs e)
        {
            SourceData = LinqPlayground.Queries.GetPeopleWithFirstName("Alyssa");
            lblNumberOfRecords.Content = SourceData.Count(); 
        }

        private void executeGetName_Click(object sender, RoutedEventArgs e)
        {
            int? numRecordsToGet = null;
            int numRecords = 0;
            if (!string.IsNullOrEmpty(tbNumRecords.Text) && 
                !string.IsNullOrWhiteSpace(tbNumRecords.Text) &&
                int.TryParse(tbNumRecords.Text, out numRecords))
            {
                numRecordsToGet = numRecords;
            }
            SourceData = LinqPlayground.Queries.GetPeopleWithFirstName(tbFirstName.Text, numRecordsToGet);
            lblNumberOfRecords.Content = SourceData.Count(); 
        }

        private void executeGetFirstNameCounts_Click(object sender, RoutedEventArgs e)
        {
            SourceData = LinqPlayground.Queries.GetFirstNamesAndCount();
            lblNumberOfRecords.Content = SourceData.Count(); 
        }

        private void executeGetPeopleAndPay_Click(object sender, RoutedEventArgs e)
        {
            SourceData = LinqPlayground.Queries.GetNamesAndTotalPay();
            lblNumberOfRecords.Content = SourceData.Count();
        }

        private void executeGetFullNameCounts_Click(object sender, RoutedEventArgs e)
        {
            SourceData = LinqPlayground.Queries.GetDuplicateNames();
            lblNumberOfRecords.Content = SourceData.Count();
        }

        private void btnExecuteGetEmployeesByBirthMonth_Click(object sender, RoutedEventArgs e)
        {
            int month = 1;
            int.TryParse(tbBirthMonthInt.Text, out month);
            ExtensionMethodsSourceData = LinqPlayground.ExtensionMethods.GetEmployeesByMonth(month);
        }

        private void btnGroupBySumQuery_Click(object sender, RoutedEventArgs e)
        {
            ExtensionMethodsSourceData = LinqPlayground.ExtensionMethods.ExecuteGroupBySumQuery();
        }
    }
}
