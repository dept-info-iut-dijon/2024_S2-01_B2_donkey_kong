using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using Xunit;


namespace TestsUnitaires
{
    /// <summary>
    /// Test unitaires pour CollideEffect de BouleFeu
    /// </summary>
    [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]
    public class TCollisionBouleFeu
    {
        /// <summary>
        /// Test: BouleFeu collision avec Echelle
        /// </summary>
        [Fact]
        public void BouleFeu_echelle()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            BouleFeu bouleFeu = new BouleFeu(plateformes, echelles, 100, 100, g);
            Echelle echelle = new Echelle(150, 150, g);

            
           
                bouleFeu.CollideEffect(echelle);
                Assert.True(true); 
           
           
        }

        /// <summary>
        /// boule de feu en colision avec un objert pas gere 
        /// </summary>
        [Fact]
        public void BouledeFeu_objet_nongerer()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            BouleFeu bouleFeu = new BouleFeu(plateformes, echelles, 100, 100, g);

         
            Plateforme plateforme = new Plateforme(150, 150, g);

           
            
                bouleFeu.CollideEffect(plateforme);
          
            
                Assert.True(false); 
            }

        }
    }
    