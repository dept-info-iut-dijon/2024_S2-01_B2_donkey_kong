using Donkey_Kong_IHM.Res;
using Donkey_Kong_Metier;
using IUTGame;
using IUTGame.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Donkey_Kong_IHM
{
    /// <summary>
    /// Logique d'interaction pour FenetreJeu.xaml
    /// </summary>
    public partial class FenetreJeu : Window
    {
        private LeJeu jeu;
        private DispatcherTimer timerScore;
        /// <summary>
        /// Contient le code c# de la fenetre dans lequel va se passer le jeu
        /// </summary>
        public FenetreJeu()
        {
            InitializeComponent();

            WPFScreen screen = new WPFScreen(canvas);
            jeu = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");

            // IMPORTANT : Le canvas doit avoir le focus pour recevoir les événements clavier
            canvas.Focusable = true;
            canvas.Focus();


            InitialiserLangue();
            InitialiserTimerScoreEtVerificationWinOrLoose();
            AfficherHighScore();


            jeu.Run();
        }

        private void InitialiserLangue()
        {
            btnParametre.Content = Strings.Button_Settings;
            this.Title = Strings.FenetreJeu_Title;
        }

        /// <summary>
        /// Méthode pour ouvrir la fenetre des parametres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OuvrirParametre(object sender, RoutedEventArgs e)
        {
            Parametre parametre = new Parametre(jeu);
            jeu.Pause();
            parametre.Show();
        }
        /// <summary>
        /// Initialise le timer pour la mise à jour de l'affichage
        /// </summary>
        private void InitialiserTimerScoreEtVerificationWinOrLoose()
        {
            timerScore = new DispatcherTimer();
            timerScore.Interval = TimeSpan.FromMilliseconds(100); // Mise à jour toutes les 100ms
            timerScore.Tick += MettreAJourAffichage;
            timerScore.Tick += MettreAJourWin;
            timerScore.Tick += MettreAJourLoose;
            timerScore.Start();
        }


        /// <summary>
        /// Teste si on a gagné et si oui lance la win
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MettreAJourWin(object sender, EventArgs e)
        {
            if (jeu.Win)
            {
                FenetreWin fenetreWin = new FenetreWin();
                fenetreWin.Show();
                this.Close();
                timerScore.Stop();
            }
            
        }

        /// <summary>
        /// Teste si on a pardu et si oui lance la fenetre perdu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MettreAJourLoose(object sender, EventArgs e)
        {
            if (jeu.Loose)
            {
                FenetreLoose fenetreperdu = new FenetreLoose();
                fenetreperdu.Show();
                this.Close();
                timerScore.Stop();
            }
        }
        /// <summary>
        /// Met à jour l'affichage des scores et vies
        /// </summary>
        private void MettreAJourAffichage(object sender, EventArgs e)
        {
            if (jeu?.Joueur?.MonScore != null)
            {
                // Afficher le score actuel
                labelValeurScore.Content = jeu.Joueur.MonScore.ScoreActuel.ToString();

                // Afficher les vies
                labelValeurVies.Content = jeu.Joueur.NbVie.ToString();

                // Utiliser le MeilleurScore depuis Parametres
                labelValeurMeilleurScore.Content = jeu.MeilleurScore.ToString();


            }
        }
        /// <summary>
        /// Affiche le meilleur score
        /// </summary>
        private void AfficherHighScore()
        {
            if (jeu != null)
                labelValeurMeilleurScore.Content = jeu.Parametres.MeilleurScore.ToString();
        }

       
    }
}    
    
    
    