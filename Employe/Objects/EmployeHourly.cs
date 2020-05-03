using System;

namespace Employe.Objects
{
    class EmployeHourly : EmployeBase
    {
        // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        // Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 

        public EmployeHourly(string _firstName, string _lastName) : base(_firstName, _lastName)
        {
        }

        public override void GetSalary(double hourlyRate)
        {
            this.Salary = Convert.ToDecimal(20.8 * 8 * hourlyRate);
        }
    }
}
