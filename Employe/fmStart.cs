using Employe.Objects;
using System;
using System.Windows.Forms;

namespace Employe
{
    public partial class fmStart : Form
    {
        public fmStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tbx1.Text = null;

            int countOfWorkers = 20;
            tbx1.Text = "Список сотрудников:\r\n";

            ArrayWorker arr = new ArrayWorker();    //почему-то не инициализиреут массив 
            arr.Init(countOfWorkers);
            tbx1.Text += arr.Print();

            tbx1.Text = "\nСортировка по зарплате:";
            arr.Sort();
            foreach (EmployeBase employe in arr)
            {
                tbx1.Text += arr.Print();
            }

            //tbx1.Text += "Еще одна строка\r\n";
        }

        private Random Random { get; } = new Random();



    }
}
