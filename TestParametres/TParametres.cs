using Donkey_Kong_Metier;
using NuGet.Frameworks;
using Xunit;

namespace TestParametres
{
    public class TParametres
    {
        private const string FichierTest = "parametres.txt";


        private void SupprimerFichier()
        {
            if (File.Exists(FichierTest))
            {
                File.Delete(FichierTest);
            }
        }

        [Fact]
        public void TestSauvegarder()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();

            parametres.Sauvegarder();

            Assert.True(File.Exists(FichierTest));

            SupprimerFichier();

        }

        [Fact]
        public void TestChargerParamParDefaut()
        {
            SupprimerFichier();

            Parametres parametres = Parametres.Charger();
            Assert.Equal(Langues.Français, parametres.Langue);
            Assert.Equal(0.5, parametres.Volume);
            Assert.Equal("Q", parametres.ToucheGauche);
            Assert.Equal("D", parametres.ToucheDroite);
            Assert.Equal("Z", parametres.ToucheHaut);
            Assert.Equal("S", parametres.ToucheBas);
            Assert.Equal("Espace", parametres.ToucheSaut);

        }

        [Fact]
        public void TestSauvegardeEtChargement()
        {
            SupprimerFichier();
            Parametres parametresDeBase = new Parametres();

            parametresDeBase.Langue = Langues.Anglais;
            parametresDeBase.Volume = 0.8;
            parametresDeBase.ToucheGauche = "Left Arrow";
            parametresDeBase.ToucheDroite = "Right Arrow";
            parametresDeBase.ToucheHaut = "Up Arrow";
            parametresDeBase.ToucheBas = "Down Arrow";
            parametresDeBase.ToucheSaut = "Space";

            Parametres parametresCharges = Parametres.Charger();

            Assert.Equal(Langues.Anglais, parametresCharges.Langue);
            Assert.Equal(0.8, parametresCharges.Volume, 3);
            Assert.Equal("Left Arrow", parametresCharges.ToucheGauche);
            Assert.Equal("Right Arrow", parametresCharges.ToucheDroite);
            Assert.Equal("Up Arrow", parametresCharges.ToucheHaut);
            Assert.Equal("Down Arrow", parametresCharges.ToucheBas);
            Assert.Equal("Space", parametresCharges.ToucheSaut);

            SupprimerFichier();

        }

        [Fact]
        public void TestSauvegardeAuto()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();

            parametres.Volume = 0.75;

            Parametres parametresCharges = Parametres.Charger();

            Assert.Equal(0.75, parametresCharges.Volume, 3);

            SupprimerFichier();
        }

        [Fact]
        public void TestModifLangue()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();

            parametres.Langue = Langues.Anglais;

            Parametres parametresCharges = Parametres.Charger();

            Assert.Equal(Langues.Anglais, parametresCharges.Langue);

            SupprimerFichier();
        }

        [Fact]
        public void TestModifTouches()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();

            parametres.ToucheGauche = "Left Arrow";
            parametres.ToucheDroite = "Right Arrow";
            parametres.ToucheHaut = "Up Arrow";
            parametres.ToucheBas = "Down Arrow";
            parametres.ToucheSaut = "Space";

            Parametres parametresCharges = Parametres.Charger();

            Assert.Equal("Left Arrow", parametresCharges.ToucheGauche);
            Assert.Equal("Right Arrow", parametresCharges.ToucheDroite);
            Assert.Equal("Up Arrow", parametresCharges.ToucheHaut);
            Assert.Equal("Down Arrow", parametresCharges.ToucheBas);
            Assert.Equal("Space", parametresCharges.ToucheSaut);
        }

        [Fact]
        public void TestVolumeDecimal()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();

            parametres.Volume = 0.227669;

            Parametres parametresCharges = Parametres.Charger();

            Assert.Equal(0.227669, parametresCharges.Volume, 6);

            SupprimerFichier();
        }

        [Fact]
        public void TestContenuFichier()
        {
            SupprimerFichier();
            Parametres parametres = new Parametres();
            parametres.Volume = 0.9;
            parametres.ToucheGauche = "Test";

            parametres.ToucheGauche = "Z";

            string contenu = File.ReadAllText(FichierTest);

            Assert.Contains("Volume=0.9", contenu);
            Assert.Contains("ToucheGauche=Z", contenu);
            Assert.Contains("Langue=Français", contenu);

            SupprimerFichier();
        }
    }
}