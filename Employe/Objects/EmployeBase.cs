using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Employe.Objects
{
    // Васильченко Артем

    // 1. Построить три  класса(базовый и  2  потомка),  описывающих работников  с почасовой  оплатой(один из  потомков)  
    // и фиксированной оплатой(второй потомок):
    // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
    // Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 
    // для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
    // b.Создать на базе абстрактного класса массив сотрудников и заполнить его;
    // c. * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort();
    // d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

    abstract public class EmployeBase : IComparable
    {
        //string firstName;
        //string lastName;
        //decimal salary;

        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected decimal SalaryMonthly { get; set; }


        public int CompareTo(object obj)
        {
            return SalaryMonthly.CompareTo(obj);
        }

        public abstract decimal GetSalary();
    }


    public class Emploees
    {
        List<EmployeBase> list;
        int index;

        public void Next()
        {
            if (list.Count > index + 1) index++;
        }

        public void Prev()
        {
            if (list.Count > 0) index--;
        }

        public void Add(EmployeBase emploee)
        {
            list.Add(emploee);
            index = list.Count - 1; //пеерпригиваем в конец списка
        }

        public Emploees()
        {
            list = new List<EmployeBase>();
            index--;
        }

        public EmployeBase CurrentEmployee
        {
            get
            {
                try
                {
                    return list[index];
                }
                catch
                {
                    return null;
                }
            }
        }

        public void Save (string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EmployeBase>));
            //создаем файловы поток
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // в этот поток записываем сериализованные данные
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
            index = 0;
        }

        public void Load(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EmployeBase>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            List<EmployeBase> list = (List<EmployeBase>)xmlFormat.Deserialize(fStream);
            fStream.Close();
            index = 0;
        }



    }
}
