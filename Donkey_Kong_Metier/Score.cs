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
        /// <summary>
        /// Obtient ou définit le score actuel du joueur
        /// </summary>
        /// <value>Le score actuel sous forme d'entier</value>
        public Score()
        {
            scoreActuel = 0;
        }
        /// <summary>
        /// Initialise une nouvelle instance de la classe Score avec un score de 0
        /// </summary>
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
        /// <summary>
        /// Remet le score à zéro
        /// </summary>
        public void ReinitialiserScore()
        {
            scoreActuel = 0;
        }
        /// <summary>
        /// Retourne une représentation textuelle du score
        /// </summary>
        public override string ToString()
        {
            return scoreActuel.ToString();
        }
        #endregion
    }
}