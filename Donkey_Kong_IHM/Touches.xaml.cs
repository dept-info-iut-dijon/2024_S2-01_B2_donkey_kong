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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Donkey_Kong_IHM.Res;
using Donkey_Kong_Metier;
using IUTGame;

namespace Donkey_Kong_IHM
{
    /// <summary>
    /// Logique d'interaction pour Touches.xaml
    /// </summary>
    public partial class Touches : Window
    {

        /// <summary>
        /// Instance des paramètres du jeu
        /// </summary>
        private Parametres parametres;

        /// <summary>
        /// Constructeur de la fenêtre Touches.
        /// Initialise les composants et charge les touches sauvegardées.
        /// Sélectionne dans chaque ComboBox la touche correspondante.
        /// </summary>
        public Touches()
        {
            InitializeComponent();
            parametres = Parametres.Charger();
            InitialiserLangue();
        }

        private void InitialiserLangue()
        {
            this.Title = Strings.Touches_Title;
            labelFonctionnalite.Content = Strings.Label_Fonctionnalite;
            labelToucheAssociee.Content = Strings.Label_ToucheAssociee;
            labelGauche.Content = Strings.Label_AllerGauche;
            labelDroite.Content = Strings.Label_AllerDroite;
            labelHaut.Content = Strings.Label_GrimperEchelle;
            labelBas.Content = Strings.Label_DescendreEchelle;
            labelSaut.Content = Strings.Label_Sauter;
        }

        /// <summary>
        /// Événement quand on change la touche "Aller à gauche"
        /// </summary>
        private void Tgauche(object sender, RoutedEventArgs e)
        {
            comboGauche.Content = "Veuillez appuyer sur une touche";

            //Key key = Key.();
            //ManageKey("moveLeft", key);
        }
        /// <summary>
        /// Événement quand on change la touche "Aller à droite"
        /// </summary>
        private void Tdroite(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Événement quand on change la touche "Grimper à l'échelle"
        /// </summary>
        private void Thaut(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Événement quand on change la touche "Descendre l'échelle"
        /// </summary>
        private void Tbas(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Événement quand on change la touche "Sauter"
        /// </summary>
        private void Tsaut(object sender, RoutedEventArgs e)
        {
            
        }

        private void ManageKey(string mouv, ConsoleKeyInfo touche)
        {
            Content = mouv;
        }
    }
}