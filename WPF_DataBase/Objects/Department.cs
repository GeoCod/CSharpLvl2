using System.ComponentModel;

namespace WPF_DataBase.Objects
{
    class Department: INotifyPropertyChanged
    {
        int _id;
        string _nameDepartment;

        #region Свойства
        public int ID
        {
            get { return _id; }
            set 
            { 
                _id = value; 
                OnPropertyChanged("ID");
            }
        }

        public string NameDepartment
        {
            get { return _nameDepartment; }
            set
            {
                if (_nameDepartment == value)
                    return;
                _nameDepartment = value;
                OnPropertyChanged("NameDepartment");
            }
        }

        #endregion

        public Department()
        {
            ID = 0;         //TODO генератор уникальных чисел
            NameDepartment = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Отслеживание изменений свойств</summary>
        /// <param name="propertyName">Изменившееся свойство</param>
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}