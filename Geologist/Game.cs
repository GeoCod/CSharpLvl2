﻿using System;
using System.Windows.Forms;
using System.Drawing;
using Geologist.Objects;

namespace Geologist
{
    /// <summary>
    /// Класс с логикой игры
    /// </summary>
    static class Game
    {
        #region Fields
        static public Random Random { get; } = new Random();
        static public Image background = Image.FromFile("Images\\mine.jpg");
        static BaseObject[] objs = new BaseObject[50];
        static Timer timer = new Timer();

        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }
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

        static public void Load()
        {
            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new BaseObject(new Point(i * 3, i * 3), new Point(i, i), new Size(20, 20));
            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Crystal(new Point(i * 3, i * 3), new Point(i, i), new Size(20, 20));
        }


        static public void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, new Rectangle(0, 0, Width, Height)); //Как сделать авто изменение размеров фона с размером окна
            foreach (BaseObject obj in objs)
                obj.Draw();
            Buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }
        #endregion

    }
}
