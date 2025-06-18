using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_Metier
{
    public class Score
    {
        #region --attributs--
        //score obtenu par le joueur
        private int scoreFinal;
        #endregion

        #region --Propriété--
        public int ScoreFinal { get { return scoreFinal; } }
        #endregion

        #region --Constructeur
        /// <summary>
        /// Constructeur pour initialiser le score du joueur
        /// </summary>
        public Score()
        {
            scoreFinal = 0;
        }
        #endregion

        #region --Méthodes--    
        /// <summary>
        /// Méthode qui sert à jouter un score au joueur en fonction de ses actions
        /// </summary>
        /// <param name="score"></param>
        public void AjouterScore(int score)
        {
            scoreFinal += score;
        }

        /// <summary>
        /// Représentation textuelle du score
        /// </summary>
        /// <returns>Chaîne formatée</returns>
        public override string ToString()
        {
            return ScoreFinal + " points";
        }
        #endregion
    }
}
