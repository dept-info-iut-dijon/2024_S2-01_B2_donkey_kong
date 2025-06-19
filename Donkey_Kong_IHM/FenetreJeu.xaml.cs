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
            InitialiserTimerScore();
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
        private void InitialiserTimerScore()
        {
            timerScore = new DispatcherTimer();
            timerScore.Interval = TimeSpan.FromMilliseconds(100); // Mise à jour toutes les 100ms
            timerScore.Tick += MettreAJourAffichage;
            timerScore.Start();
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

                // MODIFIÉ : Utiliser le MeilleurScore depuis Parametres
                labelValeurMeilleurScore.Content = jeu.MeilleurScore.ToString();
                canvas.Focus();

            }
        }
        /// <summary>
        /// Affiche le meilleur score
        /// </summary>
        private void AfficherHighScore()
        {
            if (jeu != null && jeu.Parametres != null)
            {
                labelValeurMeilleurScore.Content = jeu.Parametres.MeilleurScore.ToString();
            }
        }

        /// <summary>
        /// Nettoie les ressources lors de la fermeture
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            timerScore?.Stop();
            base.OnClosed(e);
        }
    }
}
    
    
    
    