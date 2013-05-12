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
		bool yeux;
		bool vintro;
		bool ouvrir;
		bool cavev;
		bool cuisinev1;
		bool cuisinev2;
		bool chambrev1;
		bool chambrev2;
		bool chambrev3;
		bool chambrev4;
		bool lettref;
		bool lettreo;
		bool lettrel;
		bool lettrei;
		bool lettree;


				bool finaction;
				bool iscaveaction;
					SpriteFont font;
					Vector2 textSize;
					SoundEffect soundeffect;
					SoundEffectInstance soundEffectInstance;

							SoundEffect soundeffect2;
					SoundEffectInstance soundEffectInstance2;
					int time;
					string inputdebut;
				double timercave;
				double totalcave;
			double timercuisine;
		double totalcuisine;
			bool iscuisineaction;
			int compteurA;
			int compteurZ;
		// compteur son
		double count1;

		bool cuisinevalid;
		bool chambrevalid;
		bool cavevalid;
		bool salonvalid;

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
			count1 =0;
			yeux = false;
			vintro = false;
			ouvrir = false;
			cavev = false;
			cuisinev1 = false;
			cuisinev2 = false;
			chambrev1 = false;
			chambrev2 = false;
			chambrev3 = false;
			chambrev4 = false;
		lettref = true;
		lettreo = true;
		 lettrel = true;
		 lettrei = true;
		lettree   = true;

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
		 cuisinevalid=false;
		chambrevalid=false;
		 cavevalid=false;
		 salonvalid=false;
			totalcave = 0;
			totalcuisine=0;


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



						// Position initiale du girl
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
						count1 =0;
			yeux = false;
			vintro = false;
			ouvrir = false;
			cavev = false;
			cuisinev1 = false;
			cuisinev2 = false;
			chambrev1 = false;
			chambrev2 = false;
			chambrev3 = false;
			chambrev4 = false;
			soundEffectInstance.Stop ();
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
			totalcuisine = 0;
			totalcave = 0;
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

			
			if (cuisinevalid && lettref)
			{
						soundeffect = Content.Load<SoundEffect> ("Sounds/F");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.Play ();
						lettref = false;
			}

						if (chambrevalid && lettrei)
			{
						soundeffect = Content.Load<SoundEffect> ("Sounds/I");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.Play ();
						lettrei = false;
			}

			if (cavevalid && lettreo)
			{
						soundeffect = Content.Load<SoundEffect> ("Sounds/O");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.Play ();
						lettreo = false;
			}

		

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

			if (yeux && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Yeux(gameTime);
			}

				if (vintro && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vintro(gameTime);
			}

						if (ouvrir && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Ouvrir(gameTime);
			}

			
						if (cavev && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vcave(gameTime);
			}

									if (cuisinev1 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vcuisine1(gameTime);
			}

												if (cuisinev2 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vcuisine2(gameTime);
			}

															if (chambrev1 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vchambre1(gameTime);
			}

				if (chambrev2 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vchambre2(gameTime);
			}

							if (chambrev3 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vchambre3(gameTime);
			}

										if (chambrev4 && count1 < gameTime.TotalGameTime.TotalSeconds)
			{
				Vchambre4(gameTime);
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
							// Déplacement du girl et gestion des collisions avec les bords
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


				// entree droite
					if ((girl.Position.X >= 323 && girl.Position.X <= 347) && (girl.Position.Y >= 273 && girl.Position.Y <= 450)) {
								girl.Position = old;
							}
				// entree gauche
				if ((girl.Position.X >= 233 && girl.Position.X <= 255) && (girl.Position.Y >= 273 && girl.Position.Y <= 450)) {
								girl.Position = old;
							}


							// coin droit
				if ((girl.Position.X >= 347 && girl.Position.X <= 489) && (girl.Position.Y >= 340 && girl.Position.Y <= 342)) {
								girl.Position = old;
							}

				//mur droit 
							
				if ((girl.Position.X >= 489 && girl.Position.X <= 495) && (girl.Position.Y >= 0 && girl.Position.Y <= 342)) {
								girl.Position = old;
							}
				// mur gauche 

					if ((girl.Position.X >= 97 && girl.Position.X <= 129) && (girl.Position.Y >= 0 && girl.Position.Y <= 269)) {
								girl.Position = old;
							}

				//MUR DU HAUT
								if ((girl.Position.X >= 131 && girl.Position.X <= 495) && (girl.Position.Y >= 0 && girl.Position.Y <= 2)) {
								girl.Position = old;
							}
						// bas gauche

					if ((girl.Position.X >= 131 && girl.Position.X <= 147) && (girl.Position.Y >= 264 && girl.Position.Y <= 312)) {
								girl.Position = old;
							}

										// bas droit

					if ((girl.Position.X >= 201 && girl.Position.X <= 247) && (girl.Position.Y >= 262 && girl.Position.Y <= 312)) {
								girl.Position = old;
							}

							// ici la cave
							if ((girl.Position.X >= 333 && girl.Position.X <= 359) && (girl.Position.Y >= 0 && girl.Position.Y <= 13)) {

								Cave();

							}
										// ici la cuisine
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
							Debut (gameTime);
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
							ChambreFin (false,gameTime);
					}
					if (Keyboard.GetState ().IsKeyDown (Keys.Z)) {
							ChambreFin (true,gameTime);
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
							CaveFin (true,gameTime);
						}
						if (Keyboard.GetState ().IsKeyDown (Keys.E))
						{
							CaveFin (false,gameTime);
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

			if (iscuisine && iscuisineaction)
			{
				// timer cuisine
				int tempsdonne = 10;
				totalcuisine = gameTime.TotalRealTime.TotalSeconds - timercuisine;
				soundeffect = Content.Load<SoundEffect> ("Sounds/VCuisine1");			
				totalcuisine = totalcuisine - soundeffect.Duration.TotalSeconds ;
				soundeffect = Content.Load<SoundEffect> ("Sounds/VCuisine2");			
				totalcuisine = totalcuisine - soundeffect.Duration.TotalSeconds;

				if (Keyboard.GetState ().IsKeyDown (Keys.A) && totalcuisine < tempsdonne ) {
					CuisineFin(true,gameTime);
				}
				if (totalcuisine > tempsdonne)
				{
					CuisineFin(false,gameTime);
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
			         soundEffectInstance.Stop ();
					timercuisine = gametime.TotalRealTime.TotalSeconds;
					iscuisineaction = true;
					background = Content.Load<Texture2D> ("EcranNoir");
					count1 = gametime.TotalGameTime.TotalSeconds + 1;
					cuisinev1 = true;
				}

			protected void CuisineFin(Boolean fin,GameTime gametime)
			{
			soundEffectInstance.Stop ();
			count1 = gametime.TotalGameTime.TotalSeconds + 1;
			ouvrir = true;
				finaction = true;
				if (fin)
				{
					background = Content.Load<Texture2D> ("EcranCuisineBon");
				cuisinevalid = true;
				}
				else
				{
					background = Content.Load<Texture2D> ("EcranCuisineMauvais");
				}
			}



							protected  void Chambre ()
					{

						issalon = false;

						ischambre = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranParentsDebut");
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
					count1 = gametime.TotalGameTime.TotalSeconds + 1;
					chambrev1 = true;
				}

			protected void ChambreFin(Boolean fin,GameTime gametime)
			{
			soundEffectInstance.Stop ();
			count1 = gametime.TotalGameTime.TotalSeconds + 1;
			ouvrir = true;

				finaction = true;
				if (fin)
				{
					background = Content.Load<Texture2D> ("EcranParentsBon");
				chambrevalid = true;
				}
				else
				{
					background = Content.Load<Texture2D> ("EcranParentsMauvais");
				}
			}

					protected void CaveFin(Boolean fin,GameTime gametime)
			{
						count1 = gametime.TotalGameTime.TotalSeconds + 1;
									ouvrir = true;
			soundEffectInstance.Stop ();
				finaction = true;
				if (fin)
				{
					background = Content.Load<Texture2D> ("EcranCaveBon");
				cavevalid = true;
				}
				else
				{
					background = Content.Load<Texture2D> ("EcranCaveMauvais");
				}
			}

				protected void CaveAction(GameTime gametime)
				{
			soundEffectInstance.Stop ();
					timercave = gametime.TotalRealTime.TotalSeconds;
					iscaveaction = true;
					background = Content.Load<Texture2D> ("EcranNoir");
					count1 = gametime.TotalGameTime.TotalSeconds + 1;
					cavev = true;
				}

					protected void Debut(GameTime gameTime)
					{
						issalon = false;
						iscave = false;
		
						isecrandebut = true;
						girl.LoadContent ("Black");
						background = Content.Load<Texture2D> ("EcranDebut");


								count1 = gameTime.TotalGameTime.TotalSeconds  + 2;
								yeux = true;
					}

		protected void Vintro(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VIntro");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						vintro = false;
						ouvrir = true;
						
		}

		protected void Yeux(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VYeux");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						yeux = false ;
						vintro = true;
		}

				protected void Vcuisine1(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VCuisine1");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						cuisinev1 = false ;
						cuisinev2 = true;
		}

						protected void Vcuisine2(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VCuisine2");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						cuisinev2 = false;
		}


						protected void Vchambre1(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VChambre1");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						chambrev1 = false ;
						chambrev2 = true;
		}

								protected void Vchambre2(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VChambre2");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						chambrev2 = false ;
						chambrev3 = true;
		}

										protected void Vchambre3(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VChambre3");
						count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						chambrev3 = false ;
						chambrev4 = true;
		}
												protected void Vchambre4(GameTime gameTime)
		{

						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VChambre4");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						chambrev4 = false;
		}




		protected void Ouvrir(GameTime gameTime)
		{
						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VDecompte");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
						ouvrir = false;

		}

				protected void Vcave(GameTime gameTime)
		{
						soundEffectInstance.Stop ();
						soundeffect = Content.Load<SoundEffect> ("Sounds/VCave");
						soundEffectInstance = soundeffect.CreateInstance ();
						soundEffectInstance.IsLooped = false;
						soundEffectInstance.Play ();
			count1 = soundeffect.Duration.TotalSeconds + 1 + gameTime.TotalGameTime.TotalSeconds;

			cavev = false;


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

			/* 

						spriteBatch.DrawString (font, "X:" + girl.Position.X + "Y:" + girl.Position.Y, new Vector2 (10, 10), Color.White);


						spriteBatch.DrawString (font, soundeffect.Duration.ToString (), new Vector2 (10, 40), Color.White);

						spriteBatch.DrawString (font, "time:" + time, new Vector2 (10, 70), Color.White);

				spriteBatch.DrawString (font, yeux.ToString(), new Vector2 (10, 120), Color.White);
				spriteBatch.DrawString (font, count1.ToString(), new Vector2 (10, 150), Color.White);

						spriteBatch.DrawString (font, "gameTime:" + gameTime.TotalRealTime.Seconds, new Vector2 (10, 100), Color.White);

			*/

					if (isecrandebut)
					{
						spriteBatch.DrawString (font,inputdebut, new Vector2 (300, 280 ), Color.White);

					}

					if (issalon)
					{
						spriteBatch.DrawString (font,inputdebut, new Vector2 (281, 244), Color.Black);
				if (cavevalid && chambrevalid && cuisinevalid)
				{
						spriteBatch.DrawString (font,"E", new Vector2 (281, 200), Color.Black);
				}
					}

					if(iscave && iscaveaction && false)
					{
						spriteBatch.DrawString (font,timercave.ToString(), new Vector2 (10, 130), Color.White);
						spriteBatch.DrawString (font,totalcave.ToString(), new Vector2 (10, 150), Color.White);
					spriteBatch.DrawString (font,"CompteurA"+compteurA.ToString(), new Vector2 (10, 170), Color.White);
					spriteBatch.DrawString (font,"CompteurZ"+compteurZ.ToString(), new Vector2 (10, 190), Color.White);

					}
			/*
			if (iscuisine && iscuisineaction)
			{
										spriteBatch.DrawString (font,timercuisine.ToString(), new Vector2 (10, 130), Color.White);
						spriteBatch.DrawString (font,totalcuisine.ToString(), new Vector2 (10, 150), Color.White);
			}
			*/


						girl.Draw (spriteBatch);




						// Fin du mode dessin
						spriteBatch.End ();

						base.Draw (gameTime);
					}
				}
			}

