using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donkey_Kong_Metier;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    
    /// <summary>
    /// Baril qui apparaît dans le jeu.
    /// </summary>
    public class Baril : GameItem, IAnimable
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

        /// <summary>
        /// Attribut pour servir au switch entre l'image 1 du baril de face et l'image 2
        /// </summary>
        private TimeSpan timeToAnimate;

        /// <summary>
        /// Attribut pour servir au switch entre l'image 1 du baril de face et l'image 2
        /// </summary>
        private TimeSpan durationToAnimate;

        /// <summary>
        /// Attribut pour mettre un delai avant de retester la collision avec l'echelle
        /// </summary>
        private TimeSpan delaiEchelle;

        /// <summary>
        /// Si le baril va à gauche
        /// </summary>
        private bool sensGauche; 

        /// <summary>
        /// Si le baril est en train de descendre l'escalier
        /// </summary>
        private bool enTrainDescendre;

        /// <summary>
        /// Compteur pour le nombre de mouvement qu'il faut pour descendre l'échelle
        /// </summary>
        private int cpt;
        #endregion


        #region Propriété
        public override string TypeName
        {
            get
            {
                return "baril";
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur du baril
        /// </summary>
        /// <param name="p"></param>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="game"></param>
        public Baril(List<Plateforme> p, List<Echelle> e, double x, double y, Game game) : base(x, y, game, "baril_face1.png", 1)
        {
            Collidable = true;
            this.echelles = e;
            this.plateformes = p;
            sensGauche = true;
            enTrainDescendre = false;
            timeToAnimate = new TimeSpan(0, 0, 0, 0, 100);
            cpt = 0;
            delaiEchelle = new TimeSpan(0, 0, 0, 0, 0);
        }

        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode pour animer le baril
        /// </summary>
        /// <param name="dt"></param>
        public void Animate(TimeSpan dt)
        {
            Random generateur = new Random();
            
            //partie mouvement
            if ((enTrainDescendre) && (cpt < 15))
            {
                if (cpt == 0)
                {
                    int randomSens = generateur.Next(0, 3);
                    //2 chance sur 3 pour changer de sens
                    switch (randomSens)
                    {
                        case 2:
                        case 0:
                            sensGauche = !sensGauche;
                            break;
                    }
                }
                MoveXY(0, 2.2);
                cpt += 1;
            }
            else
            {
                if (delaiEchelle.TotalMilliseconds > 0)
                {
                    delaiEchelle -= dt;
                }
                else 
                {
                    cpt = 0;
                    enTrainDescendre = false;
                    if (VerificationCollisionEscalier())
                    {
                        //2 chance sur 3 de descendre les échelles
                        int randomEchelle = generateur.Next(0, 3);
                        switch (randomEchelle)
                        {
                            case 1:
                            case 0:
                                enTrainDescendre = true;
                                this.ChangeSprite("baril.png");
                                if (sensGauche)
                                {
                                    this.MoveXY(2, 0);
                                }
                                else
                                {
                                    this.MoveXY(-2, 0);
                                }
                                break;
                            case 2:
                                enTrainDescendre = false;
                                delaiEchelle = new TimeSpan(0, 0, 0, 15);
                                if (sensGauche)
                                {
                                    this.MoveXY(2, 0);
                                }
                                else
                                {
                                    this.MoveXY(-2, 0);
                                }
                                break;
                        }
                    }
                }
                if (VerificationCollisionPlateformes())
                {
                    //partie animation (sans mouvement)
                    durationToAnimate -= dt;
                    timeToAnimate -= dt;
                    if (timeToAnimate.TotalMilliseconds < 0)
                    {
                        this.ChangeSprite("baril_face.png");
                        timeToAnimate = new TimeSpan(0, 0, 0, 0, 200);
                        durationToAnimate = new TimeSpan(0, 0, 0, 0, 100);
                    }
                    else if (durationToAnimate.TotalMilliseconds < 0)
                    {
                        this.ChangeSprite("baril_face1.png");
                    }

                    //partie mouvement
                    if (sensGauche)
                    {
                        this.MoveXY(1.6, 0);
                    }
                    else
                    {
                        this.MoveXY(-1.6, 0);
                    }
                }
                else
                {
                    this.ChangeSprite("baril.png");
                    MoveXY(0, 2.2);
                }

            }
            
            // Le baril descend et roule
            // implémenter logique de mouvement 
        }

        /// <summary>
        /// Méthode implémentant les conséquences lorsqu'un barril touche autre chose
        /// </summary>
        /// <param name="other"></param>
        public override void CollideEffect(GameItem other)
        {
          
            if (other.TypeName == "tonneau_huile")
            {
                // baril en boule de feu
                BouleFeu feu = new BouleFeu(plateformes, echelles, Left, Top, TheGame);
                TheGame.AddItem(feu);
                TheGame.RemoveItem(this);
            }
        }

        /// <summary>
        /// Méthode qui vérifie s'il y a eu une collision avec une platforme, qu'importe laquelle
        /// </summary> 
        /// <param name="plateformes"></param>
        /// <returns></returns>
        public bool VerificationCollisionPlateformes()
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
        public bool VerificationCollisionEscalier()
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