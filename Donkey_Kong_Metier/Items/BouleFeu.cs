using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup.Localizer;
using Donkey_Kong_Metier;
using DonkeyKongMetier;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Boule de feu présente dans le jeu.
    /// </summary>
    public class BouleFeu : GameItem, IAnimable
    {
        #region Attributs
        /// <summary>
        /// Attribut pour savoir toute les échelles que contient le jeu
        /// </summary>
        private List<Echelle> echelles;

        /// <summary>
        /// Attribut pour savoir toute les plateformes du jeu
        /// </summary>
        private List<Plateforme> plateformes;

        #endregion

        #region Constructeur
        public BouleFeu(List<Plateforme> p, List<Echelle> e, double x, double y, Game game) : base(x, y, game, "feu_bas_droite.png", 2)
        {
            Collidable = true;
            this.echelles = e;
            this.plateformes = p;
        }
        #endregion

        #region Propriété
        public override string TypeName
        {
            get
            {
                return "boule_feu";
            }
        }
        #endregion

        #region Méthodes*

        /// <summary>
        /// Méthode permettant d'animer et de déplacer la boule de feu
        /// </summary>
        /// <param name="dt"></param>
        public void Animate(TimeSpan dt)
        {

            Random aleatoire = new Random();
            int randomNumber = aleatoire.Next(2);

            if (VerificationCollisionPlateformes(plateformes))
            {
                if (VerificationCollisionEscalier(echelles))
                {
                    
                    switch (randomNumber)
                    {
                        case 1:
                            MoveXY(0, -2);
                            MoveXY(0, -2);
                            MoveXY(0, -2);
                            MoveXY(0, -2);
                            //verifier qu'il va au bout de l'echelle
                            break;
                        case 2:
                            MoveXY(0, 0);
                            break;
                    }
                }
                else
                {
                    switch (randomNumber)
                    {
                        case 1:
                            MoveXY(1, 0);
                            break;
                        case 2:
                            MoveXY(-4, 0);
                            break;
                    }
                }
            }
            else
            {
                MoveXY(0, 2);
            }
            // La boule de feu se déplace 
            // implémenter mouvement aléatoire
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Joueur")
            {
                // Vérifier si Mario a le marteau actif
                if (other is Joueur joueur && joueur.AMarteau)
                {
                    TheGame.RemoveItem(this);
                    // il faut aussi que l'on oublie d'Ajouter des points au score
                }
            }
        }

        /// <summary>
        /// Méthode qui vérifie s'il y a eu une collision avec une platforme, qu'importe laquelle
        /// </summary> 
        /// <param name="plateformes"></param>
        /// <returns></returns>
        public bool VerificationCollisionPlateformes(List<Plateforme> plateformes)
        {
            bool res = false;
            foreach (Plateforme p in plateformes)
            {
                if (this.IsCollide(p) && !res)
                {
                    res = true;
                }
            }
            return res;
        }

        /// <summary>
        /// Méthode qui vérifie s'il y a eu une collision avec une échelle, qu'importe laquelle
        /// </summary> 
        /// <param name="echelles"></param>
        /// <returns></returns>
        public bool VerificationCollisionEscalier(List<Echelle> echelles)
        {
            bool res = false;
            foreach (Echelle e in echelles)
            {
                if (this.IsCollide(e) && !res)
                {
                    res = true;
                }
            }
            return res;
        }
        #endregion
    }
}
