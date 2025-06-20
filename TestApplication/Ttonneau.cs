using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using IUTGame;
using IUTGame.WPF;
using System.Windows.Controls;
using Xunit;

namespace TestsUnitaires
{

    /// <summary>
    /// Méthode pour faire les tests unitaires du mouvements des tonneaux de façon séparé
    /// </summary>
    [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]

    
    public class TTonneaux
    {
        /// <summary>
        /// Méthode si le barril touche la plateforme et doit se déplacer à gauche
        /// </summary>
        [Fact]
        public void ToucherPlateformes_Gauche()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan();
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            double y = 360;
            double x = 520;


            Plateforme p1 = new Plateforme(x, y, g);
            plateformes.Add(p1);

            Baril baril = new Baril(plateformes, echelles, x, y, g);

            baril.Animate(dt);

            Assert.Equal(360, Math.Round(baril.Top));   //le baril ne bouge pas en hauteur
            Assert.Equal(522, Math.Round(baril.Left));  //le baril se déplace à gauche puisqu'il touche la plateforme 
        }

        /// <summary>
        /// Méthode si le baril touche la plateforme et doit à droite
        /// </summary>
        [Fact]
        public void ToucherPlateformes_Droite()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan();
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            double y = 360;
            double x = 785;


            Plateforme p1 = new Plateforme(x, y, g);
            plateformes.Add(p1);

            Baril baril = new Baril(plateformes, echelles, x, y, g);

            baril.Animate(dt);
             
            Assert.Equal(360, Math.Round(baril.Top));   //le baril ne bouge pas en hauteur
            Assert.Equal(783, Math.Round(baril.Left));  //le baril se déplace à droite puisqu'il touche la plateforme 
        }

        /// <summary>
        /// Méthode si le baril ne touche pas de plateformes et doit donc descendre
        /// </summary>
        [Fact]
        public void PasToucherPlateformes()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan();
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            double y = 360;
            double x = 320;


            Plateforme p1 = new Plateforme(x, y, g);
            plateformes.Add(p1);

            Baril baril = new Baril(plateformes, echelles, x, y-50, g);

            baril.Animate(dt);

            Assert.Equal(312, Math.Round(baril.Top));   //le baril descend car il touche pas la plateforme
            Assert.Equal(320, Math.Round(baril.Left)    );  //le baril ne se deplace pas horizontalement
        }

        /// <summary>
        /// Méthode si le baril touche l'escalier 
        /// </summary>
        [Fact]
        public void ToucherEscalier()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan();
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            double y = 360;
            double x = 320;


            Echelle e1 = new Echelle(x, y, g);
            echelles.Add(e1);

            Baril baril = new Baril(plateformes, echelles, x, y, g);

            baril.Animate(dt);

            Assert.Equal(362, Math.Round(baril.Top));   //le baril descend car il touche l'escalier
            Assert.Equal(322, Math.Round(baril.Left));  //le baril se deplace de 2 pour être au centre d'léchelle car quand il touche il touche alors qu'il n'est pas totalement en face
        }
    }
}


