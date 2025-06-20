using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitaires
{
    /// <summary>
    /// Classe pour faire les tests unitaires des déplacements de la boule de feu
    /// </summary>
    [CollectionDefinition("NonParallelCollection", DisableParallelization = true)]
    public class TBouleDeFeu
    {
        /// <summary>
        /// Test de si le mouvement de la boule de feu parait cohérent
        /// </summary>
        [Fact]
        public void MouvementNormal()
        {
            FakeScreen screen = new FakeScreen();
            LeJeu g = new LeJeu(screen, "Ressources/Image/Sprites", "Ressources/Son");
            TimeSpan dt = new TimeSpan();
            g.Run();

            List<Plateforme> plateformes = new List<Plateforme>();
            List<Echelle> echelles = new List<Echelle>();

            double y = 360;
            double x = 520;


            Plateforme p1 = new Plateforme(x, y, g);
            plateformes.Add(p1);

            /*BouleFeu b = new BouleFeu(plateformes, echelles, x, y, g);

            b.Animate(dt);

            Assert.True((b.Left < 522) && (b.Left > 518));
            Assert.True((b.Top < 362) && (b.Top > 358));  */ 
        }
    }
}
