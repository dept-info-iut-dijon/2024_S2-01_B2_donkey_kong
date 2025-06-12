using Donkey_Kong_Metier;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : Window
    {
        private LeJeu jeu;
        public Parametre(LeJeu jeu)
        {
            this.jeu = jeu;
            InitializeComponent();
        }

        /// <summary>
        /// Permet de mettre le jeu en français
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MettreEnFrançais(object sender, RoutedEventArgs e)
        {
            if (jeu.Langue != Langues.Français)
            {
                jeu.Langue = Langues.Français;

            }

        }

        /// <summary>
        /// Permet de mettre le jeu en anglais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MettreEnAnglais(object sender, RoutedEventArgs e)
        {
            if (jeu.Langue != Langues.Anglais)
            {
                jeu.Langue = Langues.Anglais;

            }

        }

        /// <summary>
        /// Méthode permettant de sortir des parametres et de rejouer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SortirParametre(object sender, RoutedEventArgs e)
        {
            //jeu.Run();
            this.Close();
        }
    }
}
