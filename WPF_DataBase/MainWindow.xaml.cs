using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WPF_DataBase.Objects;

namespace WPF_DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employe> employes = new ObservableCollection<Employe>();
        private BindingList<Employe> _employesList; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _employesList = new BindingList<Employe>()
            {
                new Employe(){ ID = 1, FirstName = "Вася", LastName = "Иванов" },
                new Employe(){ ID = 2, FirstName = "Петя", LastName = "Петров" },
                new Employe(){ ID = 3, FirstName = "Коля", LastName = "Сидоров" }
            };

            dgDate.ItemsSource = _employesList;
            _employesList.ListChanged += _employesList_ListChanged;
        }

        private void _employesList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || 
               e.ListChangedType == ListChangedType.ItemDeleted || 
               e.ListChangedType == ListChangedType.ItemChanged)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowDepartment windowDepartment = new WindowDepartment();
            windowDepartment.Owner = this;
            windowDepartment.Show();
        }
    }
}
