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

namespace Donkey_Kong_IHM
{
    /// <summary>
    /// Logique d'interaction pour FenetreJeu.xaml
    /// </summary>
    public partial class FenetreJeu : Window
    {
        private LeJeu jeu;


        /// <summary>
        /// Contient le code c# de la fenetre dans lequel va se passer le jeu
        /// </summary>
        public FenetreJeu()
        {
            InitializeComponent();
            WPFScreen screen = new WPFScreen(canvas);
            jeu = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            jeu.Run();
            InitialiserLangue();
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

    }
}
