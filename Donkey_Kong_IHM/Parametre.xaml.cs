using Donkey_Kong_IHM.Res;
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

        /// <summary>
        /// Contient le jeu
        /// </summary>
        private LeJeu jeu;

        /// <summary>
        /// Constructeur de la fenetre de parametre
        /// </summary>
        /// <param name="jeu"></param>
        public Parametre(LeJeu jeu)
        {
            this.jeu = jeu;
            InitializeComponent();
            InitialiserInterface();
            InitialiserLangue();
            
        }

        /// <summary>
        /// Initialise l'interface avec les valeurs de base des paramètres
        /// </summary>
        private void InitialiserInterface()
        {
            
            volumeSlider.Value = jeu.Parametres.Volume;

            if (labelValeurVolume != null)
            {
                int pourcentage = Convert.ToInt32(jeu.Parametres.Volume*100);
                labelValeurVolume.Content = pourcentage + " %";
            }

            if (jeu.Parametres.Langue == Langues.Français)
            {
                radioFrancais.IsChecked = true;
                radioAnglais.IsChecked = false;
            }
            else if (jeu.Parametres.Langue == Langues.Anglais)
            {
                radioFrancais.IsChecked = false;
                radioAnglais.IsChecked = true;
            }
        }

        private void InitialiserLangue()
        {
            this.Title = Strings.Parametre_Title;
            labelVolume.Content = Strings.Label_Volume;
            labelLangue.Content = Strings.Label_Langue;
            radioFrancais.Content = Strings.Radio_French;
            radioAnglais.Content = Strings.Radio_English;
            btnQuitter.Content = Strings.Button_Quit;
            btnTouches.Content = Strings.Button_Keys;
            labelParametresTitre.Content = Strings.Parametre_Title;

        }

        /// <summary>
        /// Permet de mettre le jeu en français
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MettreEnFrançais(object sender, RoutedEventArgs e)
        {
            if (jeu.Parametres.Langue != Langues.Français)
            {
                jeu.Parametres.Langue = Langues.Français;
            }

        }

        /// <summary>
        /// Permet de mettre le jeu en anglais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MettreEnAnglais(object sender, RoutedEventArgs e)
        {
            if (jeu.Parametres.Langue != Langues.Anglais)
            {
                jeu.Parametres.Langue = Langues.Anglais;
            }

        }

        /// <summary>
        /// Méthode permettant de changer le volume du jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangerVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (jeu != null && labelValeurVolume != null)
            {
                jeu.Parametres.Volume = volumeSlider.Value;
                jeu.BackgroundVolume = jeu.Parametres.Volume;

                int pourcentage = Convert.ToInt32(volumeSlider.Value * 100);
                labelValeurVolume.Content = pourcentage + " %";
            }
        }


        /// <summary>
        /// Méthode permettant de sortir des parametres et de rejouer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortirParametre(object sender, RoutedEventArgs e)
        {
            jeu.Run();
            this.Close();
        }

        private void AllerTouche(object sender, RoutedEventArgs e)
        {
            Touches fenTouche = new Touches();
            fenTouche.Show();
        }
    }
}
