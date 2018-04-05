using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Domaine_informatique_istv
{
    public class SlidingTabStrip : LinearLayout //Instauration de la bande 
    {
        //Variables globales necessaire pour cette classe
        private const int DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS = 2; //Epaisseur par défault de la bordure du bas de la bande
        private const byte DEFAULT_BOTTOM_BORDER_COLOR_ALPHA = 0X26; 
        private const int SELECTED_INDICATOR_THICKNESS_DIPS = 8; //Epaisseur par défault de la barre indicateur 
        private int[] INDICATOR_COLORS = { 9751905, 9751905 }; //Couleurs entre lesquelles la barre indicateur va tourner 
        private int[] DIVIDER_COLORS = { 9751905 }; //Couleur de la petite barre séparant les onglets 

        private const int DEFAULT_DIVIDER_THICKNESS_DIPS = 1; //Epaisseur par défault de la petite barre séparant les onglets
        private const float DEFAULT_DIVIDER_HEIGHT = 0.5f; //Taille par défault de la petite barre séparant les onglets

        //Bordure du bas
        private int mBottomBorderThickness; //Epaisseur
        private Paint mBottomBorderPaint; //Peinture
        private int mDefaultBottomBorderColor; //Code couleur en entier

        //Indicateur : petite barre nous indiquant dans quelle onglet nous nous trouvons
        private int mSelectedIndicatorThickness; //Epaisseur
        private Paint mSelectedIndicatorPaint; //Peinture

        //Diviseur: petit barre séparant les onglets
        private Paint mDividerPaint; //Peinture
        private float mDividerHeight; //Taille

        //Position selectionné et décalage de sélection
        private int mSelectedPosition; //position
        private float mSelectionOffSet; 


        //Tab colorizer
        private SlidingTabScrollView.TabColorizer mCustomTabColorizer;
        private SimpleTabColorizer mDefaultTabColorizer;


        //Constructeur
        public SlidingTabStrip (Context context) : this(context, null)
        { }
        
        public SlidingTabStrip (Context context, IAttributeSet attrs) : base(context, attrs)
        {
            SetWillNotDraw(false);

            float density = Resources.DisplayMetrics.Density; //Obtenir la densité de l'appareil 

            TypedValue outValue = new TypedValue(); 
            context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorForeground, outValue, true); //Recupere un entier correspondant à la couleur de font et remplis outValue avec
            int ThemeForeGround = outValue.Data; 
            mDefaultBottomBorderColor = SetColorAlpha(ThemeForeGround, DEFAULT_BOTTOM_BORDER_COLOR_ALPHA); //Fixe la couleur de de la bordure du bas avec celle récupérée précédement

            mDefaultTabColorizer = new SimpleTabColorizer();
            mDefaultTabColorizer.IndicatorColors = INDICATOR_COLORS;
            mDefaultTabColorizer.DividerColors = DIVIDER_COLORS;

            mBottomBorderThickness = (int)(DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS * density);
            mBottomBorderPaint = new Paint();
            mBottomBorderPaint.Color = GetColorFromInteger(0xC5C5C5); //Gray

            mSelectedIndicatorThickness = (int)(SELECTED_INDICATOR_THICKNESS_DIPS * density);
            mSelectedIndicatorPaint = new Paint();

            mDividerHeight = DEFAULT_DIVIDER_HEIGHT;
            mDividerPaint = new Paint();
            mDividerPaint.StrokeWidth = (int)(DEFAULT_DIVIDER_THICKNESS_DIPS * density);

        }

        public SlidingTabScrollView.TabColorizer CustomTabColorizer
        {
            set
            {
                mCustomTabColorizer = value;
                this.Invalidate();

            }
        }

        public int [] SelectedIndicatorColors
        {
            set
            {
                mCustomTabColorizer = null;
                mDefaultTabColorizer.IndicatorColors = value;
                this.Invalidate(); 
            }
        }

        public int [] DividerColors
        {
            set
            {
                mDefaultTabColorizer = null;
                mDefaultTabColorizer.DividerColors = value;
                this.Invalidate(); 
            }
        }

        //Obtenir une couleur à partir de son code en entier
        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }

        //Fixe l'opacité d'une couleur
        private int SetColorAlpha(int color, byte alpha)
        {
            return Color.Argb(alpha, Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }

        //Actualise la position et le décalage lorsque l'on change d'onglet
        public void OnViewPagerPageChanged(int position, float positionOffSet)
        {
            mSelectedPosition = position;
            mSelectionOffSet = positionOffSet;
            this.Invalidate(); //Permet de redessiner encore et encore
        }

        //Dessine La bande
        protected override void OnDraw(Canvas canvas) //Canvas permet au "view" de se dessiner
        {
            int height = Height; //Height : Retourne la taille de la vue (View) 
            int tabCount = ChildCount; //ChildCount : Retourne le nombre de fils dans le groupe (ViewGroup)
            int dividerHeightPx = (int)(Math.Min(Math.Max(0f, mDividerHeight), 1f) * height); //Fixe la taille de la barre séparant les différents onglets
            SlidingTabScrollView.TabColorizer tabColorizer = mCustomTabColorizer != null ? mCustomTabColorizer : mDefaultTabColorizer; //On vérifie si le mCustomTabColorizer est null, si il ne l'est pas cela signifie que l'utilisateur utilise son propre mCustomTabColorizer autrement on utilise notre mDefaultTabColorizer

            //Indicateur
            if (tabCount > 0) //Sinon cela signifie qu'il n'y a pas d'onglet
            {
                View SelectedTitle = GetChildAt(mSelectedPosition); //On récupère le view à la position sélectionnée 
                int left = SelectedTitle.Left; //Position gauche de ce view
                int right = SelectedTitle.Right; //Position droite de ce view
                int color = tabColorizer.GetIndicatorColor(mSelectedPosition);

                if (mSelectionOffSet > 0f && mSelectedPosition < (tabCount - 1)) //Si le mSelectionOffSet est égal à 0 cela signifie que le glissement est finis
                {
                    //Change la couleur de l'indicateur 
                    int nextColor = tabColorizer.GetIndicatorColor(mSelectedPosition + 1); 
                    if(color != nextColor)
                    {
                        color = blendColor(nextColor, color, mSelectionOffSet); 
                    }
                    //Change de view et actualise gauche et droite
                    View nextTitle = GetChildAt(mSelectedPosition + 1);
                    left = (int)(mSelectionOffSet * nextTitle.Left + (1.0f - mSelectionOffSet) * left);
                    right = (int)(mSelectionOffSet * nextTitle.Right + (1.0f - mSelectionOffSet) * right);
                }

                mSelectedIndicatorPaint.Color = GetColorFromInteger(color);

                canvas.DrawRect(left, height - mSelectedIndicatorThickness, right, height, mSelectedIndicatorPaint);

                //Créer la barre séparant les différents onglet
                int separatorTop = (height - dividerHeightPx) / 2;
                for(int i = 0; i < ChildCount; i++)
                {
                    View child = GetChildAt(i);
                    mDividerPaint.Color = GetColorFromInteger(tabColorizer.GetDividerColor(i));
                    canvas.DrawLine(child.Right, separatorTop, child.Right, separatorTop + dividerHeightPx, mDividerPaint);
                }
                //Dessine la bordure de la bande
                canvas.DrawRect(0, height - mBottomBorderThickness, Width, height, mBottomBorderPaint);
            }
        }

        //Melange les 2 couleurs dont les codes en entier sont en parametre
        private int blendColor(int color1, int color2, float ratio)
        {
            float inverseRatio = 1f - ratio;
            float r = (Color.GetRedComponent(color1) * ratio) + (Color.GetRedComponent(color2) * inverseRatio);
            float g = (Color.GetGreenComponent(color1) * ratio) + (Color.GetGreenComponent(color2) * inverseRatio);
            float b = (Color.GetBlueComponent(color1) * ratio) + (Color.GetBlueComponent(color2) * inverseRatio);

            return Color.Rgb((int)r, (int)g, (int)b);
        }

        private class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
        {
            private int[] mIndicatorColors;
            private int[] mDividerColors;

            public int GetIndicatorColor(int position)
            {
                return mIndicatorColors[position % mIndicatorColors.Length];
            }

            public int GetDividerColor(int position)
            {
                return mDividerColors[position % mDividerColors.Length];
            }

            public int[] IndicatorColors
            { 
                set { mIndicatorColors = value; }
            }

            public int[] DividerColors
            {
                set { mDividerColors = value; }
            }
        }
    }
}