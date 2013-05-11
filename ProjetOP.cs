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

        // Enemies


        // Compteur pour ajouter des enemies
        long spawnTime;


        // Fond du jeu
        Texture2D backgroundSalon;

        // Fin du jeu ?
        bool finish;

				bool	chambre_parent;
			bool chambre_enfant;
			bool cuisine  ;
			bool salledebain;
			bool jardin  ;
			bool cave;

        public ProjetOP()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;
			SoundEffect soundeffect;
			soundeffect = Content.Load<SoundEffect>("Sounds/test"); 
			soundeffect.Play();
            Window.Title = "Projet OP";
			

        }

        protected override void Initialize()
        {
			girl = new Sprite(this);

			girl.Speed = new Vector2(2, 2);


            finish = false;
			chambre_parent = false;
			chambre_enfant = false;
			cuisine = false ;
			salledebain = false;
			jardin = false ;
			cave = false;

			 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Fond de l'écran
            backgroundSalon = Content.Load<Texture2D>("Salon");


            // Texture du vaisseau
			girl.LoadContent("girl");

            // Position initiale du vaisseau
            girl.Position = new Vector2(
                (graphics.PreferredBackBufferWidth / 2) - girl.Width / 2,
                graphics.PreferredBackBufferHeight - girl.Height * 2);
			

             
            base.LoadContent();
        }

      



        // Libération des ressources
        protected override void UnloadContent()
        {
			backgroundSalon.Dispose();
            girl.UnloadContent();



            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // On quitte le jeu
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            #region Mise à jour des rectangles de la fille
            girl.Update(gameTime);

            #endregion


			
            #region Mise à jour du vaisseau
            // Gestion de l'accélération du vaisseau
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                girl.Speed = new Vector2(5, 5);
            else
                girl.Speed = new Vector2(2, 2);

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

            // Si la partie est terminée on réinitialise le tout
            if (finish)
                Initialize();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Efface l'écran
            graphics.GraphicsDevice.Clear(Color.AliceBlue);

            // Début du mode dessin
            spriteBatch.Begin();

            // On affichage le fond à la position 0, 0
            spriteBatch.Draw(backgroundSalon, Vector2.Zero, Color.White);

            // On affiche le vaisseau à la position définie dans Update()
            girl.Draw(spriteBatch);





            // Fin du mode dessin
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

