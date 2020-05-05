using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GeologistMonoGame
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    enum Stat
    {
        SplashScreen,
        Game,
        Final,
        Pause
    }

    /// <summary>
    /// Главный тип игры
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stat Stat = Stat.SplashScreen;

        #region Properties
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        static public int Width { get; private set; } = 1500;

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        static public int Height { get; private set; } = 900;
        #endregion


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Позволяет игре выполнить любую необходимую инициализацию перед началом работы.
        /// Здесь он может запрашивать любые требуемые сервисы и загружать любые неграфические
        /// связанный контент. Вызов base.Initialize будет перечислять через любые компоненты
        /// и инициализировать их.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Добавьте свою логику инициализации здесь

            base.Initialize();
        }

        /// <summary>
        /// LoadContent будет вызываться один раз за игру и является местом загрузки
        /// весь ваш контент.
        /// </summary>
        protected override void LoadContent()
        {
            // Создайте новый SpriteBatch, который можно использовать для рисования текстур.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Background = Content.Load<Texture2D>("Background1");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");

            // TODO: используйте this.Content чтобы загрузить ваш игровой контент здесь
        }

        /// <summary>
        /// UnloadContent будет вызываться один раз за игру и является местом для выгрузки игровой контент.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Позволяет игре запускать логику, например, обновлять мир,
        /// проверка на столкновения, отслеживание нажатия клавиш и воспроизведение аудио.
        /// </summary>
        /// <param name="gameTime">Предоставляет снимок временных значений.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Добавьте свою логику обновления здесь
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;
                case Stat.Game:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Stat = Stat.SplashScreen;
                    break;
            }

            //SplashScreen.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// Вызывается, когда игра должна нарисовать себя.
        /// </summary>
        /// <param name="gameTime">Предоставляет снимок временных значений.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            // TODO: Добавьте свой код для рисования здесь
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Game:
                    //SplashScreen.Draw();
                    break;
            }

            SplashScreen.Draw(spriteBatch);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
