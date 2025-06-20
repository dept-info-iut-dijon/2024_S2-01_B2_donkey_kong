using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xunit;

namespace TestsUnitaires
{
    /// <summary>
    /// Test des méthodes du joueur
    /// </summary>

    [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]
    public class TJoueur
    {
      
        /// <summary>
        /// Test  déplacement vers la gauche 
        /// </summary>
        [Fact]
        public void Deplacement_Gauche()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);//60 fps -> 16ms pr frame
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);

            joueur.KeyDown(Key.Q);
            joueur.Animate(dt);

         
            Assert.Equal(97, Math.Round(joueur.Left));  
            Assert.Equal(200, Math.Round(joueur.Top));   
        }

        /// <summary>
        /// Test déplacement vers la droite
        /// </summary>
        [Fact]
        public void Deplacement_Droite()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);
            joueur.KeyDown(Key.D);
            joueur.Animate(dt);

            Assert.Equal(103, Math.Round(joueur.Left));  
            Assert.Equal(200, Math.Round(joueur.Top));   
        }

        /// <summary>
        /// Test arrêt du mouvement quand on relâche la touche
        /// </summary>
        [Fact]
        public void Arret_Mouv()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            plateformes.Add(new Plateforme(0, 250, g)); 
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 220, g, plateformes, echelles);
            joueur.Animate(dt); 
            joueur.KeyDown(Key.D);
            joueur.Animate(dt);
            double positionApresUnFrame = joueur.Left;
            joueur.KeyUp(Key.D);
            joueur.Animate(dt);

            Assert.Equal(positionApresUnFrame, joueur.Left);
        }

        /// <summary>
        /// Test de la gravité 
        /// </summary>
        [Fact]
        public void Test_Gravite()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);
            joueur.Animate(dt);

            Assert.True(joueur.Top > 100); // Le joueur doit avoir chuté
        }

        /// <summary>
        /// Test du saut
        /// </summary>
        [Fact]
        public void Test_saut()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            plateformes.Add(new Plateforme(0, 150, g));
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 120, g, plateformes, echelles);
            for (int i = 0; i < 10; i++)
            {
                joueur.Animate(dt);
            }
            double positionSol = joueur.Top;
            joueur.KeyDown(Key.Space);
            joueur.Animate(dt);

            Assert.True(joueur.Top > positionSol); 
        }

        /// <summary>
        /// Test saut en l'air
        /// </summary>
        [Fact]
        public void Saut_pas_au_sol()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);
            joueur.Animate(dt); 
            double positionEnLair = joueur.Top;
            joueur.KeyDown(Key.Space);
            joueur.Animate(dt);

            Assert.True(joueur.Top > positionEnLair); 
        }

        /// <summary>
        /// Test de montée sur une échelle
        /// </summary>
        [Fact]
        public void Echelle_Monter()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            echelles.Add(new Echelle(95, 150, g)); 
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);
            joueur.KeyDown(Key.Z);
            joueur.Animate(dt);

            Assert.True(joueur.Top > 200); 
        }

        /// <summary>
        /// Test de descente sur une échelle
        /// </summary>
        [Fact]
        public void Echelle_Descendre()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            echelles.Add(new Echelle(95, 150, g));

            Joueur joueur = new Joueur(100, 180, g, plateformes, echelles);
            joueur.KeyDown(Key.S);
            joueur.Animate(dt);

            Assert.True(joueur.Top > 180); 
        }

        /// <summary>
        /// Teste de ne pas tomber de l'échelle
        /// </summary>
        [Fact]
        public void Echelle_PasDeGravite()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16); 
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            echelles.Add(new Echelle(95, 150, g));

            Joueur joueur = new Joueur(100, 180, g, plateformes, echelles);
            joueur.KeyDown(Key.Z);
            joueur.Animate(dt);
            double position = joueur.Top;
            joueur.KeyUp(Key.Z);

            Assert.Equal(Math.Round(position), Math.Round(joueur.Top));
        }

        /// <summary>
        /// Test de collision avec un marteau
        /// </summary>
        [Fact]
        public void Collision_Marteau()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);
            Marteau marteau = new Marteau(100, 200, g);
            joueur.CollideEffect(marteau);

            Assert.True(joueur.AMarteau);
        }

        /// <summary>
        /// Test de collision avec un baril sans marteau
        /// </summary>
        [Fact]
        public void Collision_baril_sns_marteau_()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);
            int vieInitiale = joueur.NbVie;
            Baril baril = new Baril(plateformes,echelles,100, 200, g);
            joueur.CollideEffect(baril);

            Assert.Equal(vieInitiale - 1, joueur.NbVie);        }

        /// <summary>
        /// Test de collision du baril avec marteau
        /// </summary>
        [Fact]
        public void Collision_baril_marteau()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);

            Marteau marteau = new Marteau(100, 200, g);
            joueur.CollideEffect(marteau);

            int scoreInitial = joueur.Score;
            int vieInitiale = joueur.NbVie;

            Baril baril = new Baril(plateformes, echelles,100, 200, g);
            joueur.CollideEffect(baril);

            
            Assert.Equal(scoreInitial + 300, joueur.Score);
            Assert.Equal(vieInitiale, joueur.NbVie); 
        }


        /// <summary>
        /// Test de blocage au bord gauche de l'écran
        /// </summary>
        [Fact]
        public void Limite_bord_gauche()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(-10, 200, g, plateformes, echelles);
            joueur.Animate(dt);

            Assert.Equal(0, joueur.Left);
        }

        /// <summary>
        /// Test de blocage au bord haut de l'écran
        /// </summary>
        [Fact]
        public void Limite_BordHaut()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16);
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, -10, g, plateformes, echelles);
            joueur.Animate(dt);

            Assert.Equal(0, joueur.Top);
        }

        /// <summary>
        /// Test suppression du marteau après 10 secondes
        /// </summary>
        [Fact]
        public void Marteau_Expire()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, 16); 
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            Joueur joueur = new Joueur(100, 200, g, plateformes, echelles);
            Marteau marteau = new Marteau(100, 200, g);
            joueur.CollideEffect(marteau);

            Assert.True(joueur.AMarteau);

            // 11 secs d'animation et on est a 60 fps -> 660ms
            for (int i = 0; i < 660; i++)
            {
                joueur.Animate(dt);
            }

            Assert.False(joueur.AMarteau);
        }
   
    }
}
