using Donkey_Kong_Metier.Items;
using Donkey_Kong_Metier;
using IUTGame;
using TestsMouvement;


namespace TestColision
{
   
        /// <summary>
        /// Tests unitaires pour CollideEffect de Joueur
       /// </summary>
      [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]
     
    public class TCollisionJoueur
    {



        /// <summary>
        /// Joueur sans marteau collision avec BouleFeu perd une vie
        /// </summary>
        [Fact]
        public void Joueur_SansMarteau_CollisionBouleFeu_PerdUneVie()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);

            List<Plateforme> plateformesBoule = new List<Plateforme>();
            List<Echelle> echellesBoule = new List<Echelle>();
            BouleFeu bouleFeu = new BouleFeu(plateformesBoule, echellesBoule, 150, 150, g);

          
            Assert.Equal(3, joueur.NbVie);
            Assert.False(joueur.AMarteau);

          
            joueur.CollideEffect(bouleFeu);

            Assert.Equal(2, joueur.NbVie); 
        }

        /// <summary>
        ///  collision avec Princesse gagne des points
        /// </summary>
        [Fact]
        public void Joueur_CollisionPrincesse_GagnePoints()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image","Ressource/Son");


            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);
            Princesse princesse = new Princesse(150, 150, g);

           
            Assert.Equal(0, joueur.Score);

            joueur.CollideEffect(princesse);

                // Le joueur doit avoir gagné 5000 points
                Assert.Equal(5000, joueur.Score);
                // On vérifie quand même le score
                Assert.Equal(5000, joueur.Score);
                Assert.Equal(5000, joueur.Score);
            
        
        
        
        
        }
        

        /// <summary>
        /// dernière vie collision avec ennemi 
        /// </summary>
        [Fact]
        public void Joueur_DerniereVie_CollisionEnnemi_GameOver()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);

            // Perdre 2 vies pour arriver à la dernière
            List<Plateforme> plateformesBaril = new List<Plateforme>();
            List<Echelle> echellesBaril = new List<Echelle>();
            Baril baril1 = new Baril(plateformesBaril, echellesBaril, 150, 150,g);
            Baril baril2 = new Baril(plateformesBaril, echellesBaril, 150, 150, g);

            joueur.CollideEffect(baril1); 
            joueur.CollideEffect(baril2); 

            Assert.Equal(1, joueur.NbVie); 

            
            Baril barilFinal = new Baril(plateformesBaril, echellesBaril, 150, 150, g);

            
            
                joueur.CollideEffect(barilFinal);

                //  Plus de vies
                Assert.Equal(0, joueur.NbVie);
                Assert.Equal(0, joueur.NbVie);
            }
        

        /// <summary>
        /// collision avec objet sans effet de colision 
        /// </summary>
        [Fact]
        public void Joueur_CollisionObjetInconnu_NeFaitRien()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);
            Plateforme plateforme = new Plateforme(150, 150, g);

         
            int viesInitiales = joueur.NbVie;
            int scoreInitial = joueur.Score;
            bool marteauInitial = joueur.AMarteau;

            joueur.CollideEffect(plateforme);

         
            Assert.Equal(viesInitiales, joueur.NbVie);
            Assert.Equal(scoreInitial, joueur.Score);
            Assert.Equal(marteauInitial, joueur.AMarteau);
        }

        /// <summary>
        /// Double collision avec le même objet 
        /// </summary>
        [Fact]
        public void Joueur_DoubleCollisionMemeObjet_UneSeuleFois()
        {

            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            Joueur joueur = new Joueur(100, 100, g, plateformes, echelles);
            Marteau marteau = new Marteau(150, 150, g);

            // Première collision
            joueur.CollideEffect(marteau);
            Assert.Equal(100, joueur.Score);
            Assert.True(joueur.AMarteau);

            // Deuxième collision avec le même marteau
            joueur.CollideEffect(marteau);

            
            Assert.Equal(100, joueur.Score); // Pas compter 2 x
        }


       }
    }
    
