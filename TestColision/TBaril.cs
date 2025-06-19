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
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();  

            Baril baril = new Baril(plateformes, echelles, 100, 100, g);

            TonneauHuile tonneauHuile = new TonneauHuile(200, 200, g);

            
                baril.CollideEffect(tonneauHuile);
            
           
                Assert.True(false);
            }

 

        /// <summary>
        /// on verifi une colision avec une interacation 
        /// </summary>
        [Fact]
        public void BarilVerificationCollision()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            Plateforme plateforme = new Plateforme(100, 100, g);
            plateformes.Add(plateforme);

            List<Echelle> echelles = new List<Echelle>();  

            Baril baril = new Baril(plateformes, echelles, 100, 100, g);



            bool resultat = baril.VerificationCollisionPlateformes(plateformes);

          
            Assert.True(resultat);
        }

       
    }

      
  }
