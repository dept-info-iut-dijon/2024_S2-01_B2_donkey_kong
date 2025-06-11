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
        public MainWindow()
        {
            InitializeComponent();
        }

        void Jouer(object sender, RoutedEventArgs e)
        {
            WPFScreen screen = new WPFScreen(canvas);
            LeJeu jeu = new LeJeu(screen, "C:\\Users\\ruddy\\OneDrive\\Desktop\\S2.01\\2024_S2-01_B2_donkey_kong\\Donkey_Kong_VM\\Ressources\\Image", "C:\\Users\\ruddy\\OneDrive\\Desktop\\S2.01\\2024_S2-01_B2_donkey_kong\\Donkey_Kong_VM\\Ressources\\Son"); ;
            jeu.Run();
        }

    }
}