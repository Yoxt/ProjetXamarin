using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Domaine_informatique_istv
{
    public class SlidingTabScrollView : HorizontalScrollView //Permet de faire glisser les éléments horizontalement 
    {
        //Variables globales necessaire pour cette classe
        private const int TITLE_OFFSET_DIPS = 24;
        private const int TAB_VIEW_PADDING_DIPS = 16;
        private const int TAB_VIEW_TEXT_SIZE_SP = 12;

        private int mTitleOffset;

        private int mTableViewLayoutID;
        private int mTableViewTextViewID;

        private ViewPager mViewPager;
        private ViewPager.IOnPageChangeListener mViewPagerPageChangeListener;

        private static SlidingTabStrip mTabStrip;

        private int mScrollState;


        public interface TabColorizer
        {
            int GetIndicatorColor(int position);
            int GetDividerColor(int position);
        }

        public SlidingTabScrollView (Context context) : this(context, null) { }

        public SlidingTabScrollView (Context context, IAttributeSet attrs) : this(context, attrs, 0) { }

        public SlidingTabScrollView(Context context, IAttributeSet attrs, int defaultStyle) : base(context, attrs, defaultStyle)
        {
            //Désactive la bar de défilement
            HorizontalScrollBarEnabled = false;

            //On veut que notre bande d'onglet remplisse entièrement notre page
            FillViewport = true;
            this.SetBackgroundColor(Android.Graphics.Color.Rgb(0, 0, 0)); //Vert

            mTitleOffset = (int)(TITLE_OFFSET_DIPS * Resources.DisplayMetrics.Density);

            mTabStrip = new SlidingTabStrip(context);
            this.AddView(mTabStrip, LayoutParams.MatchParent, LayoutParams.MatchParent);
        }

        //Détermine la couleur de la bande d'onglet
        public TabColorizer CustomTabColorizer
        {
            set
            {
                mTabStrip.CustomTabColorizer = value;
            }
        }

        //Détermine la couleur de l'indicateur
        public int [] SelectedIndicatorColor
        {
            set { mTabStrip.SelectedIndicatorColors = value;  }
        }

        //Détermine la couleur de la barre séparant les onglets
        public int [] DividerColors
        {
            set { mTabStrip.DividerColors = value; }
        }

        public ViewPager.IOnPageChangeListener OnPageListener
        {
            set { mViewPagerPageChangeListener = value; }
        }
        //ViewPager : assure une navigation horizontale
        public ViewPager ViewPager
        {
            set
            {
                mTabStrip.RemoveAllViews();

                mViewPager = value;
                if(value != null)
                {
                    value.PageSelected += value_PageSelected; //Lorsqu'une page est sélectionnée fait appel à la fonction value_PageSelected
                    value.PageScrollStateChanged += value_PageScrollStateChanged; //Lorsque le défilement change d'état fait appel à la fonction PageScrollStateChanged
                    value.PageScrolled += value_PageScrolled; //Lorsque la page actuelle défile fait appel à la fonction value_PageScrolled
                    PopulateTabStrip();
                }
            }
        }

        //Défile les éléments ainsi que la barre indiquant notre position sur la bande d'onglet
        private void value_PageScrolled(object sender, ViewPager.PageScrolledEventArgs e)
        {
            int tabCount = mTabStrip.ChildCount;

            if ((tabCount == 0) || (e.Position < 0) || (e.Position >= tabCount)) //Si il n'y a pas d'onglet ou l'utilisateur essaye d'aller trop à gauche ou trop à droite
            {
                //Alors on ne veut rien faire
                return;
            }

            mTabStrip.OnViewPagerPageChanged(e.Position, e.PositionOffset);

            View selectedTitle = mTabStrip.GetChildAt(e.Position);

            int extraOffSet = (selectedTitle != null ? (int)(e.Position * selectedTitle.Width) : 0); //Définition la limite 

            ScrollToTab(e.Position, extraOffSet); 

            if (mViewPagerPageChangeListener != null)
            {
                mViewPagerPageChangeListener.OnPageScrolled(e.Position, e.PositionOffset, e.PositionOffsetPixels);
            }

        }

        private void value_PageScrollStateChanged(object sender, ViewPager.PageScrollStateChangedEventArgs e)
        {

            mScrollState = e.State;

            if (mViewPagerPageChangeListener != null)
            {
                mViewPagerPageChangeListener.OnPageScrollStateChanged(e.State);
            }
        }

        //Selection d'une page sans défilement
        private void value_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            if (mScrollState == ViewPager.ScrollStateIdle) //Permet de faire défiler une fois que l'utilisateur a finis et non avant
            {
                mTabStrip.OnViewPagerPageChanged(e.Position, 0f);
                ScrollToTab(e.Position, 0);
            }
            if (mViewPagerPageChangeListener != null)
            {
                mViewPagerPageChangeListener.OnPageSelected(e.Position);
            }
        }

        //Adapte la page selon le nombre d'onglet (adapter.Count)
        private void PopulateTabStrip()
        {
            PagerAdapter adapter = mViewPager.Adapter;

            for (int i =0; i < adapter.Count; i++)
            {
                TextView tabView = CreateDefaultTabView(Context);
                tabView.Text = ((SlidingTabsFragment.SamplePagerAdapter)adapter).GetHeaderTitle(i); 
                tabView.SetTextColor(Android.Graphics.Color.Rgb(148, 205, 97));
                tabView.Tag = i; //Cela nous permettra de retrouver une position 
                tabView.Click += tabView_Click; 
                mTabStrip.AddView(tabView);
            }
        }
        
        //Lorsque l'on clique sur un onglet, on se dirige vers cet onglet
        private void tabView_Click(object sender, EventArgs e)
        {
            TextView clickTab = (TextView)sender; //On sait que c'est un textView, nous le castons donc
            int pageToScrollTo = (int)clickTab.Tag;
            mViewPager.CurrentItem = pageToScrollTo;
        }

        private TextView CreateDefaultTabView(Android.Content.Context context)
        {
            TextView textView = new TextView(context);
            textView.Gravity = GravityFlags.Center;
            textView.SetTextSize(ComplexUnitType.Sp, TAB_VIEW_TEXT_SIZE_SP);
            textView.Typeface = Android.Graphics.Typeface.DefaultBold;

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Honeycomb)
            {
                TypedValue outValue = new TypedValue();
                Context.Theme.ResolveAttribute(Android.Resource.Attribute.SelectableItemBackground, outValue, false);
                textView.SetBackgroundResource(outValue.ResourceId);
            }

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.IceCreamSandwich)
            {
                textView.SetAllCaps(true);
            }

            int padding  = (int)(TAB_VIEW_PADDING_DIPS * Resources.DisplayMetrics.Density);
            textView.SetPadding(padding, padding, padding, padding);

            return textView;
        }

        //Initialisation
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (mViewPager != null)
            {
                ScrollToTab(mViewPager.CurrentItem, 0);
            }
        }
        private void ScrollToTab(int tabIndex, int extraOffSet)
        {
            int tabCount = mTabStrip.ChildCount;

            if (tabCount == 0 || tabIndex <0 || tabIndex >= tabCount) //No need to go further
            {
                return;
            }

            View SelectedChild = mTabStrip.GetChildAt(tabIndex);
            if (SelectedChild != null)
            {
                int scrollAmountX = SelectedChild.Left + extraOffSet;

                if (tabIndex >0 || extraOffSet >0)
                {
                    scrollAmountX -= mTitleOffset;
                }

                this.ScrollTo(scrollAmountX, 0);
            }
        }
    }
}