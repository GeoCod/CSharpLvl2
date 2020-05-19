using System.ComponentModel;

namespace WPF_DataBase.Objects
{
    class Employe: INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _department;

        #region Свойства
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                if (_lastName == value)
                    return;
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Department
        {
            get { return _department; }
            set 
            {
                if (_department == value)
                    return;
                _department = value;
                OnPropertyChanged("Department");
            }
        }

        #endregion

        public Employe()
        {
            ID = 0;         //TODO генератор уникальных чисел
            FirstName = "";
            LastName = "";
            Department = "Автоматизации";   //TODO получиать данные из Department, но как?
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
