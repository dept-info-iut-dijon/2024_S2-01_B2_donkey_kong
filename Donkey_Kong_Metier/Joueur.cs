using Donkey_Kong_Metier.Items;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace DonkeyKongMetier
{
    /// <summary>
    /// Classe représentant le joueur
    /// </summary>
    public class Joueur : GameItem, IAnimable, IKeyboardInteract
    {
        #region Attributs
        //constante a ajuster pour bouger a la bonne vitesse
        private const double VitesseDeplacement = 5.0;
        //orientation du sprite
        private double direction = 0;
        //si je joueur bouge ou non
        private bool enMouvement = false;
        //coordonnées x
        private double x;
        //coordonnées y
        private double y;
        //Jeu du joueur
        private Game game;
        //sprite de joueur
        private string sprite;
        //priorité d'affichage du sprite
        private int zindex;
        //nombre d evue du joueur
        private int nbVie = 3;
        //score du joueur
        private int score = 0;
        //determine si le joueur peut grimper
        private bool peutGrimper = false;
        //determine si le joeuur a un marteau
        private bool aMarteau = false;
        //depuis combien de temps mario a le marteau
        private double tempsMarteau = 0;

        #endregion

        #region Propriétés
        public bool AMarteau
        {
            get { return aMarteau; }
        }

        public bool PeutGrimper
        { 
            get { return peutGrimper; } 
        }

        public double TempsMaretau
        { 
            get { return tempsMarteau; }
        }

         
        #endregion

            /// <summary>
            /// constructeur du joueur
            /// </summary>
            /// <param name="x">coordonnées x du joueur</param>
            /// <param name="y">coordonnées y du joueur</param>
            /// <param name="game">le jeu en cours</param>
            /// <param name="spriteName">le sprite du joueur a charger initialement</param>
            /// <param name="zindex">priorité d'affichage du sprite</param>
        public Joueur(double x, double y, Game game, string spriteName, int zindex = 0) : base(x, y, game, "mario_debout_droite", zindex)
        {
            this.x = x;
            this.y = y;
            this.game = game;
            this.zindex = zindex;
            this.sprite = spriteName;
            Collidable = true;

        }

        /// <summary>
        /// tupe de l'objet
        /// </summary>
        public override string TypeName => "Joueur";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">FPS</param>
        public void Animate(TimeSpan dt)
        {
            {
                if (enMouvement)
                {
                    MoveDA(VitesseDeplacement, direction);

                    // Vérification des limites de l'écran
                    if (Left < 0) PutXY(0, Top);
                    if (Top < 0) PutXY(Left, 0);
                    if (Right > GameWidth) PutXY(GameWidth - Width, Top);
                    if (Bottom > GameHeight) PutXY(Left, GameHeight - Height);
                }
            }
        }

        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    direction = 180;
                    enMouvement = true;
                    break;
                case Key.Right:
                    direction = 0;
                    enMouvement = true;
                    break;
                case Key.Up:
                    direction = 270;
                    enMouvement = true;
                    break;
                case Key.Down:
                    direction = 90;
                    enMouvement = true;
                    break;
            }
            Orientation = direction; // Oriente le sprite
        }

        public void KeyUp(Key key)
        {
            // On arrête le mouvement quand la touche est relâchée
            if (key == Key.Left || key == Key.Right || key == Key.Up || key == Key.Down)
            {
                enMouvement = false;
            }
        }

        /// <summary>
        /// Collision avec les autres objets
        /// </summary>
        /// <param name="other"></param>
        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "baril")
            {
                this.nbVie -= 1;
                if (this.nbVie < 1)
                {
                    game.Loose();
                }
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plateforme"></param>
        /// <returns></returns>
        public bool VerificationCollision(List<Plateforme> plateforme)
        {
            bool res = false;
            foreach (Plateforme p in plateforme)
            {
                if (this.IsCollide(p))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

    }
}
