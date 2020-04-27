using System;

namespace Employe.Objects
{
    class EmployeHourly : EmployeBase
    {

        // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        // Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 
        private Random Random { get; } = new Random();
        decimal hourlyRate;

        public override decimal GetSalary()
        {
            hourlyRate = Random.Next(150, 5000);
            return SalaryMonthly = 20.8M * 8M * hourlyRate;
        }
    }
}
