using Donkey_Kong_Metier;
using Xunit;

namespace TestsMouvement
{
    public class TTonneau
    {
        /// <summary>
        /// Test pour savoir si le tonneau se d�place dans le bon sens
        /// </summary>
        [Fact]
        public void TestMouvementClassic()
        {
            LeJeu jeu = new LeJeu();
            Tonneau tonneau = new Tonneau(2,4, LeJeu);
            Assert.Equals();
        }
    }
}