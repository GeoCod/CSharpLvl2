using Geologist.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Geologist
{
    /// <summary>
    /// Класс с логикой игры
    /// </summary>
    static class Game
    {
        #region Fields
        static public Image background = Image.FromFile("Images\\mine.jpg");
        static BaseObject hero = new BaseObject();
        static BaseObject[] objs = new BaseObject[30];
        static BufferedGraphicsContext context;
        static List<BaseObject> objsList = new List<BaseObject>(); //спсиок всех объектов для Draw и Update
        
        static public BufferedGraphics Buffer { get; private set; }
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
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            Load();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        // Пока плохо разобрался как учитывать размер изображения объекта что бы он не появлялся на краю формы
        static public void Load()
        {
            // и несколько разных объектов кристаллы и порода
            //for (int i = 0; i < objs.Length / 2; i++)
            //    objs[i] = new BaseObject(new Point(i * 3, i * 3), new Point(i, i), new Size(20, 20));
            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Crystal(new Point(Random.Next(Width, Width*2), Random.Next(Height)-15), new Point(Random.Next(5, 20)), new Size(15, 15));
            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new Rock(new Point(Random.Next(Width, Width * 2), Random.Next(Height)-15), new Point(Random.Next(5, 35)), new Size(15, 15));
                //objs[i] = new Rock(new Point(0, Random.Next(Height)-15), new Point(Random.Next(5, 35), Random.Next(Height)), new Size(15, 15));
            
            //Позже сделать реагирование на нажатие клавиш и анимацию
            hero = new Hero(new Point(5, 50), new Point(0, -10), new Size(80, 100));
        }


        static public void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, new Rectangle(0, 0, Width, Height)); //Как сделать авто изменение размеров фона с размером окна?
            foreach (BaseObject obj in objs)
                obj.Draw();
            hero.Draw();

            Buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
            hero.Update();
        }
        #endregion

    }
}
