using Employe.Objects;
using System;
using System.Windows.Forms;

namespace Employe
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tbx1.Text = null;

            int countOfWorkers = 20;
            tbx1.Text = "Список сотрудников:\n";

            ArrayWorker arr = new ArrayWorker();    //почему-то не инициализиреут массив 
            arr.Init(countOfWorkers);
            tbx1.Text += arr.Print();

            tbx1.Text = "\nСортировка по зарплате:";
            arr.Sort();
            foreach (EmployeBase employe in arr)
            {
                tbx1.Text += arr.Print();
            }
        }

        private Random Random { get; } = new Random();



    }
}
