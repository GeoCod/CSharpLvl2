using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Employe.Objects
{
    // Васильченко Артем

    // 1. Построить три  класса(базовый и  2  потомка),  описывающих работников  с почасовой  оплатой (один из  потомков)  
    // и фиксированной оплатой(второй потомок):
    // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
    // Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 
    // для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
    // b.Создать на базе абстрактного класса массив сотрудников и заполнить его;
    // c. * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort();
    // d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

    abstract public class EmployeBase : IComparable
    {
        // поля
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        private decimal salaryMonthly;

        protected decimal Salary
        {
            get { return salaryMonthly; }
            set
            {
                if (value < 0) throw new ArgumentException("Не может быть отрицательной зарплаты!");
                salaryMonthly = value;
            }
        }

        // конструктор
        public EmployeBase(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            salaryMonthly = Salary;
        }

        //Методы
        public override string ToString()
        {
            return $"{FirstName} {LastName}, зарплата {salaryMonthly:C} руб.";
        }

        public abstract void GetSalary(double slaryRate);

        public int CompareTo(object obj)
        {
            //return salaryMonthly.CompareTo(obj);
            if (Salary < ((EmployeBase)obj).Salary) return 1;
            if (Salary > ((EmployeBase)obj).Salary) return -1;
            return 0;
        }
    }
}
