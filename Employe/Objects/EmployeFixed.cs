using System;

namespace Employe.Objects
{
    class EmployeFixed : EmployeBase
    {
        // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        // для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
        private Random Random;// { get; } = new Random();

        public EmployeFixed()
        {
            SalaryMonthly = 80000;
        }
        
        public EmployeFixed(int min, int max)
        {
            int rnd = Random.Next(min, max);
            SalaryMonthly = (rnd - rnd % 1000m) * 1000m;
        }
        public override decimal GetSalary()
        {
            return SalaryMonthly;
        }
    }
}
