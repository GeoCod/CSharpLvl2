using System.Windows.Forms;

namespace Geologist
{
    class Program
    {
        static void Main()
        {
            Form form = new Form();
            form.Width = 1024;
            form.Height = 768;
            //form.KeyDown += Form_KeyDown;     // Похоже обработку нажатий нужно делать в объектах...

            form.Show();
            Game.Init(form);
            Game.Draw();
            Application.Run(form);
        }

        ///// <summary>
        ///// ОБработка нажатий клавиш
        ///// </summary>
        //private static void Form_KeyDown(object sender, KeyEventArgs e)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
