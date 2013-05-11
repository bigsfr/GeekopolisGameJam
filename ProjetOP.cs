using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameTutorial
{
    public class ProjetOP : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Vaisseau
		Sprite girl;



        // Compteur pour ajouter des enemies
        long spawnTime;


        // Fond du jeu
        Texture2D background;

        // Fin du jeu ?
        bool finish;

				bool	chambre_parent;
			bool chambre_enfant;
			bool cuisine  ;
			bool salledebain;
			bool jardin  ;
		bool iscave;
		bool issalon;


			SpriteFont font;
Vector2 textSize;
				SoundEffect soundeffect;
		int time;
					
        public ProjetOP()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;


	
			

        }

        protected override void Initialize()
        {



            finish = false;
			chambre_parent = false;
			chambre_enfant = false;
			cuisine = false ;
			salledebain = false;
			jardin = false ;
			iscave = false;
			issalon = true;
			time = 0;
			 

            base.Initialize();

            Window.Title = "Projet OP";


        }

        protected override void LoadContent()
        {
			soundeffect = Content.Load<SoundEffect>("Sounds/test"); 
			soundeffect.Play ();
			girl = new Sprite(this);
			girl.Speed = new Vector2(2, 2);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Fond de l'écran
            background = Content.Load<Texture2D>("Salon");


            // Texture du vaisseau
			girl.LoadContent("girl");



            // Position initiale du vaisseau
            girl.Position = new Vector2(
                (graphics.PreferredBackBufferWidth / 2) - girl.Width / 2,
                graphics.PreferredBackBufferHeight - girl.Height * 2);

	
             
            base.LoadContent();
        }

       protected  void Salon()
		{
			issalon = true;
			   // Fond de l'écran
			background = Content.Load<Texture2D>("Salon");
            // Texture de la fille
			girl.LoadContent("girl");
			soundeffect = Content.Load<SoundEffect>("Sounds/test"); 


		}



        // Libération des ressources
        protected override void UnloadContent()
        {
			background.Dispose();
            girl.UnloadContent();



            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
	


			if (gameTime.TotalRealTime.Seconds % 8 == 0)
			{
				if (time != gameTime.TotalRealTime.Seconds){
					time = gameTime.TotalRealTime.Seconds;

							soundeffect.Play();
				}


			}


            // On quitte le jeu
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            #region Mise à jour des rectangles de la fille
            girl.Update(gameTime);

            #endregion


			
            #region Mise à jour du salon

			if (issalon)
			{
            // Déplacement du vaisseau et gestion des collisions avec les bords
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && girl.Position.Y > 0)
                girl.Position = new Vector2(girl.Position.X, girl.Position.Y - girl.Speed.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && girl.Position.Y + girl.Height < graphics.PreferredBackBufferHeight)
                girl.Position = new Vector2(girl.Position.X, girl.Position.Y + girl.Speed.Y); 

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && girl.Position.X > 0)
                girl.Position = new Vector2(girl.Position.X - girl.Speed.X, girl.Position.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && girl.Position.X + girl.Width < graphics.PreferredBackBufferWidth)
                girl.Position = new Vector2(girl.Position.X + girl.Speed.X, girl.Position.Y);
            #endregion

			if ((girl.Position.X >= 331 && girl.Position.X <= 357) && (girl.Position.Y <= 8))
			{

				Cave();

			}
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Z))
			{
				Salon();
			}

			if (iscave)
			{
			}

            // Si la partie est terminée on réinitialise le tout
            if (finish)
                Initialize();

            base.Update(gameTime);
        }

		protected  void Cave()
		{
			issalon = false;
			iscave = true;
			girl.LoadContent("black");
			background = Content.Load<Texture2D>("Cave");
			girl.Position = new Vector2(345,21);
		}

        protected override void Draw(GameTime gameTime)
        {
            // Efface l'écran
            graphics.GraphicsDevice.Clear(Color.AliceBlue);

            // Début du mode dessin
            spriteBatch.Begin();

            // On affichage le fond à la position 0, 0
            spriteBatch.Draw(background, Vector2.Zero, Color.White);


			font = Content.Load<SpriteFont>("SpriteFont1");

			spriteBatch.DrawString(font,"X:"+girl.Position.X+"Y:"+girl.Position.Y,new Vector2(10,10),Color.White);


			spriteBatch.DrawString(font,soundeffect.Duration.ToString(),new Vector2(10,40),Color.White);

			spriteBatch.DrawString(font,"time:"+time,new Vector2(10,70),Color.White);

			spriteBatch.DrawString(font,"gameTime:"+gameTime.TotalRealTime.Seconds,new Vector2(10,100),Color.White);			

            // On affiche le vaisseau à la position définie dans Update()
            girl.Draw(spriteBatch);





            // Fin du mode dessin
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

