using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
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

namespace SelectDataGridView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<Employee> employees;
        //private ICollectionView collectionView;
        public MainWindow()
        {
            InitializeComponent();

            //employees = Employee.FakeMany(10).ToList(); 
            //collectionView = CollectionViewSource.GetDefaultView(employees);
            //DataGrid1.ItemsSource = collectionView;
            //collectionView.Filter = (item) =>
            //{
            //    var employee = item as Employee;
            //    return employee.FirstName.Contains(tbxFliter.Text)|| employee.LastName.Contains(tbxFliter.Text);
            //};
            this.DataContext = new ViewModel(Employee.FakeMany(10));
        }


        //private void tbxFliter_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    collectionView.Refresh();
        //}

        //private void btnAddNew_Click(object sender, RoutedEventArgs e)
        //{
        //    employees.Add(Employee.FakeOne());
        //    collectionView.Refresh();
        //}
    }
    public partial class ViewModel : ObservableObject
    {
        List<Employee> employees;

        [ObservableProperty]
        ICollectionView collectionView;

        [ObservableProperty]
        string fliterString;

        partial void OnFliterStringChanged(string value)=> CollectionView.Refresh();
        
           
        
        public ViewModel(IEnumerable<Employee> employees)
        {
            this.employees = new List<Employee>(employees);
            CollectionView = CollectionViewSource.GetDefaultView(employees);
            CollectionView.Filter = (item) =>
            {
                if (string.IsNullOrEmpty(FliterString))
                    return true;
                var employee = item as Employee;
                return employee.FirstName.Contains(FliterString) || employee.LastName.Contains(FliterString);
            };
        }


    }
}