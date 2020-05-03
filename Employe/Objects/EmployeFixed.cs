using System;

namespace Employe.Objects
{
    class EmployeFixed : EmployeBase
    {
        // a.Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        // для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
        public EmployeFixed(string _firstName, string _lastName) : base(_firstName, _lastName)
        {
        }
        
        //public EmployeFixed(int min, int max)
        //{
        //    int rnd = Random.Next(min, max);
        //    salaryMonthly = (rnd - rnd % 1000m) * 1000m;
        //}
        public override void GetSalary(double fixedSalary)
        {
            this.Salary = Convert.ToDecimal(fixedSalary);
        }
    }
}
