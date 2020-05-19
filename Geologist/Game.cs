using Geologist.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Geologist
{
    /// <summary>
    /// Класс с логикой игры
    /// </summary>
    static class Game
    {
        #region Fields
        static public Image background = Image.FromFile("Images\\mine.jpg");
        static Hero hero;
        static Crystal[] crystals = new Crystal[15];
        static Rock[] rocks = new Rock[20];
        //static List<BaseObject> objsList = new List<BaseObject>(); //спсиок всех объектов для Draw и Update
        static public BufferedGraphics Buffer { get; private set; }
        static BufferedGraphicsContext context;
        static Timer timer = new Timer();
        static public Random Random { get; } = new Random();
        #endregion


        #region ClassLifeCycles
        static Game()
        {

        }
        #endregion


        #region Properties
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        static public int Width { get; private set; }
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        static public int Height { get; private set; }
        #endregion


        #region Methods

        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
            Width = form.ClientSize.Width;  // Запоминаем размеры формы
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом для того, чтобы рисовать в буфере
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
            Load();
        }

        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            hero.MoveStop();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            hero.Move(e);
        }

        //static private void GetSizeForm()
        //{
        //    Width = form.ClientSize.Width;  // Запоминаем размеры формы
        //    Height = form.ClientSize.Height;
        //}

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        /// <summary>
        /// Инициализация объектов
        /// </summary>
        static public void Load()
        {
            for (int i = 0; i < rocks.Length; i++)
                rocks[i] = new Rock();
            for (int i = 0; i < crystals.Length; i++)
                crystals[i] = new Crystal();
            hero = new Hero();
        }


        /// <summary>
        /// Перерисовака объектов
        /// </summary>
        static public void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, new Rectangle(0, 0, Width, Height)); //Как сделать авто изменение размеров фона с размером окна?
            foreach (Crystal crys in crystals) crys.Draw();
            foreach (Rock rock in rocks) rock.Draw();
            hero.Draw();

            Buffer.Render();
        }

        static public void Update()
        {
            foreach (Crystal crys in crystals) crys.Update();
            foreach (Rock rock in rocks) rock.Update();
            hero.Update();
        }
        #endregion

    }
}
