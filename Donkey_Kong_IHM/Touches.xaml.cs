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

        // <summary>
        /// Constructeur de la fenêtre Touches.
        /// Initialise les composants et charge les touches sauvegardées.
        /// Sélectionne dans chaque ComboBox la touche correspondante.
        /// </summary>
        public Touches()
        {
            InitializeComponent();
            parametres = Parametres.Charger();
            InitialiserComboBoxes();
           
        }

        // <summary>
        /// Recherche un ComboBoxItem correspondnat a une valeur donnée
        /// Permet de sélectionner l'element qui correspond à la touche sauvegardée
        /// </summary>
        /// <param name="combo"> La combob
        private void InitialiserComboBoxes()
        {
            string[] touchesPossibles = new string[]
            {
                "Z", "Q", "S", "D", "Space", "Left arrow", "Right Arrow", "Up Arrow", "Down Arrow"
            };

            RemplirComboBox(comboGauche, touchesPossibles, parametres.ToucheGauche);
            RemplirComboBox(comboDroite, touchesPossibles, parametres.ToucheDroite);
            RemplirComboBox(comboHaut, touchesPossibles, parametres.ToucheHaut);
            RemplirComboBox(comboBas, touchesPossibles, parametres.ToucheBas);
            RemplirComboBox(comboSaut, touchesPossibles, parametres.ToucheSaut);
        }

        /// <summary>
        /// Remplit une ComboBox avec des éléments et sélectionne la valeur actuelle
        /// </summary>
        private void RemplirComboBox(ComboBox comboBox, string[] touches, string valeurActuelle)
        {
            comboBox.Items.Clear();

            foreach (string t in touches)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = t;
                comboBox.Items.Add(item);

                if (t == valeurActuelle)
                {
                    comboBox.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// Événement quand on change la touche "Aller à gauche"
        /// </summary>
        public void Tgauche(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboGauche.SelectedItem as ComboBoxItem;
            if (item != null) 
            {
                parametres.ToucheGauche = item.Content.ToString();
            }
        }

        /// <summary>
        /// Événement quand on change la touche "Aller à doite"
        /// </summary>
        public void Tdroite(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboDroite.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                parametres.ToucheDroite = item.Content.ToString();
            }
        }

        /// <summary>
        /// Événement quand on change la touche "Grimper à l'échelle"
        /// </summary>
        public void Thaut(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboHaut.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                parametres.ToucheHaut = item.Content.ToString();
            }
        }

        /// <summary>
        /// Événement quand on change la touche "Descendre l'échelle"
        /// </summary>
        public void Tbas(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboBas.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                parametres.ToucheBas = item.Content.ToString();
            }
        }

        /// <summary>
        /// Événement quand on change la touche "Sauter"
        /// </summary>
        public void Tsaut(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboSaut.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                parametres.ToucheSaut = item.Content.ToString();
            }
        }
    }   
}
