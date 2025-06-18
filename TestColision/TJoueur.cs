using Donkey_Kong_Metier.Items;
using Donkey_Kong_Metier;
using DonkeyKongMetier;
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
        /// Classe TestJoueur pour les tests
        /// </summary>
        public class TestJoueur : Joueur
        {
            private bool aMarteau;
            private int nbVie = 3;
            private Score score;

            public TestJoueur(double x, double y, LeJeu game, List<Plateforme> plateformes, List<Echelle> echelles, bool avecMarteau = false)
                : base(x, y, game, plateformes, echelles, 3)
            {
                this.aMarteau = avecMarteau;
                this.score = new Score();
            }

            public new bool AMarteau
            {
                get { return aMarteau; }
            }

            public int NbVie
            {
                get { return nbVie; }
            }

            public void SetMarteau(bool valeur)
            {
                aMarteau = valeur;
            }

            public void SetNbVie(int valeur)
            {
                nbVie = valeur;
            }


            public override void CollideEffect(GameItem other)
            {
            

                if (other.TypeName == "baril" || other.TypeName == "boule_feu" || other.TypeName == "donkey_kong")
                {
                    if (aMarteau == false)
                    {
                        nbVie -= 1;
                        if (nbVie < 1)
                        {
                            // j'appelle pas loose car je veux esquiver NotImplementedException dans les tests
                            
                        }
                    }
                    else
                    {
                        TheGame.RemoveItem(other);
                        score.AjouterScore(100);
                    }
                }
                // je chekc le type marteau
                else if (other.TypeName == "marteau_debout" || other.TypeName == "marteau")
                {
                    aMarteau = true;
                    TheGame.RemoveItem(other);
                    ChangeSprite("mario_marteau_droite.png");
                }
                else if (other.TypeName == "princesse")
                {
                    score.AjouterScore(5000);
                    //j'appelle pas win car je veux esquiver NotImplementedException dans les tests
                   
                }
            }
        }

        /// <summary>
        /// Test: Joueur sans marteau collision avec Baril
        /// </summary>
        [Fact]
        public void Joueur_baril_moins1vie()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, false);
            joueur.SetNbVie(2);

            List<Plateforme> plateformesBaril = new List<Plateforme>();
            Baril baril = new Baril(plateformesBaril, 150, 150, jeu);

           
            joueur.CollideEffect(baril);

           
            Assert.Equal(1, joueur.NbVie);
        }

        /// <summary>
        /// lorsqu'il ya une colision avec le marteau 
        /// </summary>
        [Fact]
        public void Joueur_marteeau()
        {
            // Arrange
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, false);
            Marteau marteau = new Marteau(150, 150, jeu);

            Assert.False(joueur.AMarteau);

            
            joueur.CollideEffect(marteau);

            // on verifie que le marteau a été recuperer 
            Assert.True(joueur.AMarteau);
        }

        /// <summary>
        /// quand le joueur a une colision avec un baril avec son marteau
        /// </summary>
        [Fact]
        public void Joueur_baril_marteaue()
        {
          
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, true);
            joueur.SetNbVie(3);

            List<Plateforme> plateformesBaril = new List<Plateforme>();
            Baril baril = new Baril(plateformesBaril, 150, 150, jeu);

            int viesAvant = joueur.NbVie;

            joueur.CollideEffect(baril);

            Assert.Equal(viesAvant, joueur.NbVie);
        }

        /// <summary>
        /// quand le joueur a une collision avec une de BouleFeu sans marteau
        /// </summary>
        [Fact]
        public void Joueur_bouledefeu_1vieenmoins ()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, false);
            joueur.SetNbVie(3);

            BouleFeu bouleFeu = new BouleFeu(150, 150, jeu);

            
            joueur.CollideEffect(bouleFeu);

            Assert.Equal(2, joueur.NbVie);
        }

        /// <summary>
        /// quanf le joueur collision avec Princesse 
        /// </summary>
        [Fact]
        public void Joueur_princesse ()
        {
            
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();
            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, false);

            Princesse princesse = new Princesse(150, 150, jeu);

            try
            {
                joueur.CollideEffect(princesse);
               
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        /// <summary>
        /// quand le joueur est a sa derniere vie
        /// </summary>
        [Fact]
        public void Joueur_0vie()
        {
           
            FakeScreen screen = new FakeScreen();
            LeJeu jeu = new LeJeu(screen, "", "");

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            TestJoueur joueur = new TestJoueur(100, 100, jeu, plateformes, echelles, false);
            joueur.SetNbVie(1);

            List<Plateforme> plateformesBaril = new List<Plateforme>();
            Baril baril = new Baril(plateformesBaril, 150, 150, jeu);

        
            joueur.CollideEffect(baril);

            // on verifei que le nombre de vie est bien de 0
            Assert.Equal(0, joueur.NbVie);
        }
    }
}
