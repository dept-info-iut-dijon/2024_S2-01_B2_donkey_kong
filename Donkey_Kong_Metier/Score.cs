using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Donkey_Kong_Metier
{/// <summary>
 /// Classe avec le score d'un joueur d
 /// Permet de gérer l'accumulation des points et leur affichage
 /// </summary>
    public class Score
    {
        #region Attributs
        private int scoreActuel;
        #endregion

        #region Propriétés
        /// <summary>
        /// Score actuel du joueur
        /// </summary>
        public int ScoreActuel
        {
            get { return scoreActuel; }
            set { scoreActuel = value; }
        }
        #endregion

        #region Constructeur
       
        public Score()
        {
            scoreActuel = 0;
        }

        public Score(int scoreInitial)
        {
            scoreActuel = scoreInitial;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Ajoute des points au score
        /// </summary>
        public void AjouterPoints(int points)
        {
            if (points > 0)
            {
                scoreActuel += points;
            }
        }

        public void ReinitialiserScore()
        {
            scoreActuel = 0;
        }

        public override string ToString()
        {
            return scoreActuel.ToString();
        }
        #endregion
    }
}