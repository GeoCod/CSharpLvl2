using Geologist.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Geologist
{
    /// <summary>
    /// Класс с логикой игры
    /// </summary>
    class Game : Exception
    {
        #region Fields
        static public Image background = Image.FromFile("Images\\mine.jpg");
        public static Hero hero;// { get; private set; }
        public static Hammer hammer;// { get; private set; }
        static Crystal[] crystals = new Crystal[15];
        static Rock[] rocks = new Rock[20];
        static public int score = 0;
        static public int armor = 100;

        //static List<BaseObject> objsList = new List<BaseObject>(); //спсиок всех объектов для Draw и Update
        static public BufferedGraphics Buffer { get; private set; }
        static BufferedGraphicsContext context;
        static Timer timer = new Timer();
        static public Random Random { get; } = new Random();

        #endregion


        #region ClassLifeCycles
        public Game()
        {

        }

        public Game(string message) : base(message)
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
            if (e.KeyCode == Keys.Space)
            {
                hammer = new Hammer(new Point(hero.Rect.X + hero.Width, hero.Rect.Y + hero.Width / 2));
            }
            else hero.Move(e);
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
            hammer?.Draw();
            DrawScore();
            DrawArmor();
            Buffer.Render();
        }

        static public void Update()
        {
            for (int i = 0; i < crystals.Length; i++)
            {
                crystals[i].Update();
                if (crystals[i].Collision(hero))
                {
                    crystals[i] = new Crystal();
                    score++;
                }
            }
            for (int i = 0; i < rocks.Length; i++)
            {
                rocks[i].Update();
                if (rocks[i].Collision(hero))
                {
                    rocks[i] = new Rock();
                    armor--;
                    score--;
                }

                if (hammer != null)
                {
                    if (rocks[i].Collision(hammer))
                    {
                        rocks[i] = new Rock();
                        hammer = null;
                        score++;
                    }
                    else hammer.Update();
                }
            }

            #region Вариант через foreach
            //foreach (Crystal crys in crystals)
            //{
            //    crys?.Update();
            //    if (crys.Collision(hero))
            //    {
            //        score++;
            //        //пееррисовать объект
            //    }
            //}
            //foreach (Rock rock in rocks)
            //{
            //    rock?.Update();
            //    if (rock.Collision(hero)) score--;
            //    if (hammer != null)
            //    {
            //        if (rock.Collision(hammer))
            //        {
            //            score++;
            //            //пееррисовать объект
            //        }
            //        hammer.Update();
            //    }
            //}
            #endregion

            hero.Update();

        }

        public static void DrawScore()
        {
            string drawString = $"Зарплата: {score}";
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Green);
            float x = 20;
            float y = 4;
            StringFormat drawFormat = new StringFormat();
            Buffer.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }

        public static void DrawArmor()
        {
            string drawString = $"Здоровье: {armor}";
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Aqua);
            float x = 20;
            float y = 30;
            StringFormat drawFormat = new StringFormat();
            Buffer.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }
        #endregion

    }
}
