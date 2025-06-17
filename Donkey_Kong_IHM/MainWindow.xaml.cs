using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Donkey_Kong_Metier;
using IUTGame.WPF;
using Donkey_Kong_IHM.Res;

namespace Donkey_Kong_IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Parametres parametres;
        /// <summary>
        /// Constructeur de la fenetre d'accueil
        /// </summary>
        public MainWindow()
        {
            parametres = Parametres.Charger();
            InitializeComponent();
            InitialiserLangue();
        }

        private void InitialiserLangue()
        {
            CultureInfo culture = parametres.Langue == Langues.Français
                ? new CultureInfo("fr-FR")
                : new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            this.Title = Strings.MainWindow_Title;
            nvlle_partie.Content = Strings.Button_NewGame;
            labelCopyright.Content = Strings.Label_Copyright;
            labelMadeInJapan.Content = Strings.Label_MadeInJapan;
        }

        /// <summary>
        /// Méthode permettant d'ouvrir la fenetre pour jouer et fermer la fenetre d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jouer(object sender, RoutedEventArgs e)
        {
            FenetreJeu fenetrejeu = new FenetreJeu();
            fenetrejeu.Show();
            this.Close();
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        /// <summary>
        /// Méthode permettant de changer le curseur en main lorsqu'on survole le boutton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Survoler(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        /// <summary>
        /// Méthode permettant d'annuler le changement de curseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoSurvoler(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }
    }
}