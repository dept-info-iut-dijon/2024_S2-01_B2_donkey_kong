using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using TestsMouvement;


namespace TestColision
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
            LeJeu jeu = new LeJeu(screen, "", "");

            BouleFeu bouleFeu = new BouleFeu(100, 100, jeu);
            Echelle echelle = new Echelle(150, 150, jeu);


            try
            {
                bouleFeu.CollideEffect(echelle);
            }
            catch (Exception )
            {
                Assert.True(false);
            }
        }

        /// <summary>
        /// boule de feu en colision avec un objert pas gere 
        /// </summary>
        [Fact]
        public void BouledeFeu_objet_nongerer()
        {
           
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            BouleFeu bouleFeu = new BouleFeu(100, 100, jeu);
            Plateforme plateforme = new Plateforme(150, 150, jeu);


            try
            {
                bouleFeu.CollideEffect(plateforme);
            }
            catch (Exception)
            {
                Assert.True(false);
            }

        }
    }
    }