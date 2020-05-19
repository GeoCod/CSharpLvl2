using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WPF_DataBase.Objects;

namespace WPF_DataBase
{
    /// <summary>Логика взаимодействия для WindowDepartment.xaml</summary>
    public partial class WindowDepartment : Window
    {
        private ObservableCollection<Department> departments = new ObservableCollection<Department>();
        private BindingList<Department> _departmentsList;

        public WindowDepartment()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // тестовый набор данных
            _departmentsList = new BindingList<Department>
            {
                new Department(){ ID = 1, NameDepartment = "Автоматизации" },
                new Department(){ ID = 2, NameDepartment = "Систематизация" },
                new Department(){ ID = 3, NameDepartment = "Прокастинации" },
                new Department(){ ID = 4, NameDepartment = "Виртуализации" },
                new Department(){ ID = 5, NameDepartment = "Глобализации" },
                new Department(){ ID = 6, NameDepartment = "Прокламации" }
            };
            dgDepartment.ItemsSource = _departmentsList;
            _departmentsList.ListChanged += _departmentsList_ListChanged;
        }

        private void _departmentsList_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case (ListChangedType.ItemAdded):
                    //TODO если не введено название департамента, то удаляем запись
                    break;
                case (ListChangedType.ItemDeleted):

                    break;
                case (ListChangedType.ItemChanged):

                    break;
            //if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted ||
            //   e.ListChangedType == ListChangedType.ItemChanged)
            //{
            //}
            }
        }
    }
}
