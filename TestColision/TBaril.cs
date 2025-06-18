using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using TestsMouvement;


namespace TestColision
{

    /// <summary>
    /// Méthode pour faire les tests unitaires
    /// </summary>
    [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]
 
    /// <summary>
    /// Tests unitaires pour CollideEffect du Baril 
    /// </summary>
   
    public class TCollisionBaril
    {
        /// <summary>
        ///Baril collision avec TonneauHuile doit créer BouleFeu et supprimer le baril
        /// </summary>
        [Fact]
        public void Baril_tonneau()
        {
            
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

          
            List<Plateforme> plateformes = new List<Plateforme>();
            Baril baril = new Baril(plateformes, 100, 100, jeu);
            TonneauHuile tonneauHuile = new TonneauHuile(200, 200, jeu);

            try
            {
                baril.CollideEffect(tonneauHuile);
            }
            catch (Exception )
            {
                Assert.True(false);
            }

        }

        /// <summary>
        ///un baril en collision avec objet non géré ne fait rien
        /// </summary>
        [Fact]
        public void Baril_objet_nongerer()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            Baril baril = new Baril(plateformes, 100, 100, jeu);
            Plateforme plateforme = new Plateforme(150, 150, jeu);

      
            var exception = Record.Exception(() => baril.CollideEffect(plateforme));
            Assert.Null(exception);
        }

        /// <summary>
        /// on verifi une colision avec un vrai ogjet
        /// </summary>
        [Fact]
        public void BarilVerificationCollision()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            Plateforme plateforme = new Plateforme(100, 100, jeu);
            plateformes.Add(plateforme);

            Baril baril = new Baril(plateformes, 100, 100, jeu);

            
            bool resultat = baril.VerificationCollisionPlateformes(plateformes);

          
            Assert.True(resultat);
        }

       
    }

      
  }
