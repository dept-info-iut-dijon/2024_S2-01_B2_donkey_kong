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

namespace Donkey_Kong_IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructeur de la fenetre d'accueil
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode permettant d'ouvrir la fenetre pour jouer et fermer la fenetre d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Jouer(object sender, RoutedEventArgs e)
        {
            FenetreJeu fenetrejeu = new FenetreJeu();
            fenetrejeu.Show();
            this.Close();
        }

    }
}