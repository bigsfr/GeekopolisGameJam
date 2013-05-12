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

					// Fille
					Sprite girl;
					int compteurenigme;



					// Fond du jeu
					Texture2D background;

					// Fin du jeu ?
					bool finish;
					bool	ischambre;
			bool ischambreaction;

					bool iscuisine;
					bool iscave;
					bool issalon;
					bool isecrandebut;
					bool isecrandemarrage;
					bool isfin;

				bool finaction;
				bool iscaveaction;
					SpriteFont font;
					Vector2 textSize;
					SoundEffect soundeffect;
					SoundEffectInstance soundEffectInstance;
					int time;
					string inputdebut;
				double timercave;
				double totalcave;
			double timercuisine;
			bool iscuisineaction;
			int compteurA;
			int compteurZ;

					public ProjetOP ()
					{
						graphics = new GraphicsDeviceManager (this);
						Content.RootDirectory = "Content";

						graphics.PreferredBackBufferWidth = 640;
						graphics.PreferredBackBufferHeight = 480;
						graphics.IsFullScreen = false;





					}

					protected override void Initialize ()
					{

						finaction = false;

						compteurenigme = 0;
						finish = false;
						ischambre = false;
						iscuisine = false;
				ischambreaction= false;
				iscuisineaction= false;
						iscave = false;
					    iscaveaction = false;
						issalon = false;
						isecrandebut = false;
						isecrandemarrage = true;
				compteurA = 0;
				compteurZ= 0;
						time = 0;
						inputdebut = "";


						base.Initialize ();

						Window.Title = "Projet OP";


					}

					protected override void LoadContent ()
					{
						soundeffect = Content.Load<SoundEffect> ("Sounds/Salon");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = true;
						soundEffectInstance.Play ();
						girl = new Sprite (this);
						girl.Speed = new Vector2 (2, 2);
						spriteBatch = new SpriteBatch (GraphicsDevice);

						// Fond de l'écran
						background = Content.Load<Texture2D> ("EcranDemarrage");




						// Texture de la fille
						girl.LoadContent ("Girl");



						// Position initiale du vaisseau
						girl.Position = new Vector2 (
			                (graphics.PreferredBackBufferWidth / 2) - girl.Width / 2,
			                graphics.PreferredBackBufferHeight - girl.Height * 2);
						girl.LoadContent ("Black");
						base.LoadContent ();
					}

					protected void Demarrage()
					{


					}

					protected  void Salon ()
					{
				finaction = false;
					inputdebut = "";
						issalon = true;
						ischambre = false;
						iscuisine = false;
						iscave = false;
					    iscaveaction = false;
						ischambreaction = false;
				iscuisineaction = false;
						isecrandebut = false;
						iscave = false;
						isecrandebut = false;
						isecrandemarrage = false;
					isfin = false;
					compteurenigme= 0;
				compteurA = 0;
				compteurZ = 0;
						// Fond de l'écran
						background = Content.Load<Texture2D> ("Salon");
						// Texture de la fille
						girl.LoadContent ("Girl");

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/Salon");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = true;
						soundEffectInstance.Play ();

					}

				protected void Fin()
				{
								inputdebut = "";
						issalon = false;
						ischambre= false;
						iscuisine = false;
						iscave = false;
						isecrandebut = false;
						isecrandemarrage = false;
					isfin = true;
					girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranFin");
						girl.Position = new Vector2 (345, 21);

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/Final");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
				}


					// Libération des ressources
					protected override void UnloadContent ()
					{
						background.Dispose ();
						girl.UnloadContent ();



						base.UnloadContent ();
					}

					protected override void Update (GameTime gameTime)
					{

						if (isecrandemarrage)
						{
							Demarrage();
						}


						// On quitte le jeu
						if (Keyboard.GetState ().IsKeyDown (Keys.Escape))
							this.Exit ();

						#region Mise à jour des rectangles de la fille
						girl.Update (gameTime);

						#endregion



						#region Mise à jour du salon

						if (issalon) {
							Vector2 old = girl.Position;
							// Déplacement du vaisseau et gestion des collisions avec les bords
							if (Keyboard.GetState ().IsKeyDown (Keys.Up) && girl.Position.Y > 0)
								girl.Position = new Vector2 (girl.Position.X, girl.Position.Y - girl.Speed.Y);

							if (Keyboard.GetState ().IsKeyDown (Keys.Down) && girl.Position.Y + girl.Height < graphics.PreferredBackBufferHeight)
								girl.Position = new Vector2 (girl.Position.X, girl.Position.Y + girl.Speed.Y);

							if (Keyboard.GetState ().IsKeyDown (Keys.Left) && girl.Position.X > 0)
								girl.Position = new Vector2 (girl.Position.X - girl.Speed.X, girl.Position.Y);

							if (Keyboard.GetState ().IsKeyDown (Keys.Right) && girl.Position.X + girl.Width < graphics.PreferredBackBufferWidth)
								girl.Position = new Vector2 (girl.Position.X + girl.Speed.X, girl.Position.Y);
							#endregion


							// bloque contre la rembarde tristan
							if ((girl.Position.X >= 281 && girl.Position.X <= 291) && (girl.Position.Y >= 278 && girl.Position.Y <= 434)) {
								girl.Position = old;
							}

										// bloque contre escalier
							if ((girl.Position.X >= 245 && girl.Position.X <= 283) && (girl.Position.Y >= 262 && girl.Position.Y <= 268)) {
								girl.Position = old;
							}

							// ici la cave
							if ((girl.Position.X >= 257 && girl.Position.X <= 359) && (girl.Position.Y >= 6 && girl.Position.Y <= 13)) {

								Cave();

							}
										// ici la cave
							if ((girl.Position.X >= 151 && girl.Position.X <= 189) && (girl.Position.Y >= 265 && girl.Position.Y <= 272)) {

								Cuisine();

							}
										// ici la chambre tirstan
							if ((girl.Position.X >= 253 && girl.Position.X <= 279) && (girl.Position.Y >= 300 && girl.Position.Y <= 310)) {

								Chambre ();

							}
						}




					if (isecrandemarrage) {
							if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
								isecrandebut = true;
							isecrandemarrage = false;
							Debut ();
						}
							}


						if (isecrandebut) {

							if (Keyboard.GetState ().IsKeyDown (Keys.Back)) {
								inputdebut = "";
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.M)) {
								if (compteurenigme == 0 || compteurenigme == 2) {
									inputdebut += "M";
									compteurenigme += 1;
								}
							}

							if (Keyboard.GetState ().IsKeyDown (Keys.E)) {
								if (compteurenigme == 1 || compteurenigme == 6) {
									inputdebut += "E";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.O)) {
								if (compteurenigme == 3) {
									inputdebut += "O";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.I)) {

								if (compteurenigme == 4) {
									inputdebut += "I";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.R)) {
								if (compteurenigme == 5) {
									inputdebut += "R";
									compteurenigme += 1;
								}

							}

							if (inputdebut == "MEMOIRE") {
								inputdebut = "";
								Salon ();
							}

						}

								if (issalon) {

							if (Keyboard.GetState ().IsKeyDown (Keys.Back)) {
								inputdebut = "";
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.F)) {
								if (compteurenigme == 0) {
									inputdebut += "F";
									compteurenigme += 1;
								}
							}

							if (Keyboard.GetState ().IsKeyDown (Keys.O)) {
								if (compteurenigme == 1) {
									inputdebut += "O";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.L)) {
								if (compteurenigme == 2) {
									inputdebut += "L";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.I)) {

								if (compteurenigme == 3) {
									inputdebut += "I";
									compteurenigme += 1;
								}
							}
							if (Keyboard.GetState ().IsKeyDown (Keys.E)) {
								if (compteurenigme == 4) {
									inputdebut += "E";
									compteurenigme += 1;
								}

							}

							if (inputdebut == "FOLIE") {
								inputdebut = "";
								Fin();
							}

						}

						if (iscave || ischambre || iscuisine ){
						if (Keyboard.GetState ().IsKeyDown (Keys.Q)) {
							Salon ();
						}
						}


						if (iscave && !iscaveaction) {
										if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
							CaveAction (gameTime);

						}
					}

							if (iscuisine && !iscuisineaction) {
										if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
							CuisineAction (gameTime);

						}
					}

						if (ischambre && !ischambreaction) {
							if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
							ChambreAction (gameTime);

						}

					}

								if (ischambre && ischambreaction) {
							if (Keyboard.GetState ().IsKeyDown (Keys.A)) {
							ChambreFin (false);
					}
					if (Keyboard.GetState ().IsKeyDown (Keys.Z)) {
							ChambreFin (true);
					}

						}



							if(iscave && iscaveaction)
						{
							totalcave = gameTime.TotalRealTime.TotalSeconds - timercave;
					if (Keyboard.GetState ().IsKeyDown (Keys.A)) {
						if ((compteurA - compteurZ) < 1)
						{
						compteurA += 1;
						}
					}
						if (Keyboard.GetState ().IsKeyDown (Keys.Z)) {
							if ((compteurZ - compteurA) < 1)
						{
						compteurZ += 1;
						}





					}

						if ((compteurA +compteurZ) > 40)
						{
							CaveFin (true);
						}
						if (Keyboard.GetState ().IsKeyDown (Keys.E))
						{
							CaveFin (false);
						}







						}
							if (Keyboard.GetState ().IsKeyDown (Keys.E) && !iscaveaction && !isecrandebut && !isfin && !issalon) {
						Salon ();
					}

				if (finaction)
				{
					if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
						Salon ();
					}
				}

						// Si la partie est terminée on réinitialise le tout
						if (finish)
							Initialize ();

						base.Update (gameTime);
					}

					protected  void Cave ()
					{

						issalon = false;

						iscave = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranCaveDebut");
						girl.Position = new Vector2 (345, 21);

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/Cave");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = true;
						soundEffectInstance.Play ();

					}

							protected  void Cuisine ()
					{

						issalon = false;

						iscuisine = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranCuisineDebut");
						girl.Position = new Vector2 (167, 259);

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/Cuisine");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = true;
						soundEffectInstance.Play ();

					}

						protected void CuisineAction(GameTime gametime)
				{
					timercuisine = gametime.TotalRealTime.TotalSeconds;
					iscuisineaction = true;
					background = Content.Load<Texture2D> ("EcranNoir");
				}


							protected  void Chambre ()
					{

						issalon = false;

						ischambre = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranParentDebut");
						girl.Position = new Vector2 (267, 313);
						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/Chambre");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = true;
						soundEffectInstance.Play ();

					}
							protected void ChambreAction(GameTime gametime)
				{
					timercave = gametime.TotalRealTime.TotalSeconds;
					ischambreaction = true;
					background = Content.Load<Texture2D> ("EcranNoir");
				}

			protected void ChambreFin(Boolean fin)
			{
				finaction = true;
				if (fin)
				{
					background = Content.Load<Texture2D> ("EcranParentBon");
				}
				else
				{
					background = Content.Load<Texture2D> ("EcranParentMauvais");
				}
			}

					protected void CaveFin(Boolean fin)
			{
				finaction = true;
				if (fin)
				{
					background = Content.Load<Texture2D> ("EcranCaveBon");
				}
				else
				{
					background = Content.Load<Texture2D> ("EcranCaveMauvais");
				}
			}

				protected void CaveAction(GameTime gametime)
				{
					timercave = gametime.TotalRealTime.TotalSeconds;
					iscaveaction = true;
					background = Content.Load<Texture2D> ("EcranNoir");
				}

					protected void Debut()
					{
						issalon = false;
						iscave = false;
						isecrandebut = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranDebut");

					}

					protected override void Draw (GameTime gameTime)
					{
						// Efface l'écran
						graphics.GraphicsDevice.Clear (Color.AliceBlue);

						// Début du mode dessin
						spriteBatch.Begin ();

						// On affichage le fond à la position 0, 0
						spriteBatch.Draw (background, Vector2.Zero, Color.White);


						font = Content.Load<SpriteFont> ("SpriteFont1");

						spriteBatch.DrawString (font, "X:" + girl.Position.X + "Y:" + girl.Position.Y, new Vector2 (10, 10), Color.White);


						spriteBatch.DrawString (font, soundeffect.Duration.ToString (), new Vector2 (10, 40), Color.White);

						spriteBatch.DrawString (font, "time:" + time, new Vector2 (10, 70), Color.White);

						spriteBatch.DrawString (font, "gameTime:" + gameTime.TotalRealTime.Seconds, new Vector2 (10, 100), Color.White);


					if (isecrandebut)
					{
						spriteBatch.DrawString (font,inputdebut, new Vector2 (10, 130), Color.White);

					}

					if (issalon)
					{
						spriteBatch.DrawString (font,inputdebut, new Vector2 (10, 130), Color.White);
					}

					if(iscave && iscaveaction)
					{
						spriteBatch.DrawString (font,timercave.ToString(), new Vector2 (10, 130), Color.White);
						spriteBatch.DrawString (font,totalcave.ToString(), new Vector2 (10, 150), Color.White);
					spriteBatch.DrawString (font,"CompteurA"+compteurA.ToString(), new Vector2 (10, 170), Color.White);
					spriteBatch.DrawString (font,"CompteurZ"+compteurZ.ToString(), new Vector2 (10, 190), Color.White);

					}

						// On affiche le vaisseau à la position définie dans Update()
						girl.Draw (spriteBatch);





						// Fin du mode dessin
						spriteBatch.End ();

						base.Draw (gameTime);
					}
				}
			}

