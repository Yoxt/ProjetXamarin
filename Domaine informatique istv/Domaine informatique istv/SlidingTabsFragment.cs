using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;
using Android.Graphics;

namespace Domaine_informatique_istv
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager; //Disposition permettant à l'utilisateur de glisser vers la droite et vers la gauche

        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) // instancie la vue et les composants graphiques
        {
            View view = inflater.Inflate(Resource.Layout.fragment_sample, container, false);
            Button btn1 = view.FindViewById<Button>(Resource.Id.formation_button1);
            btn1.Click += StartLicenceInfo;
            Button btn2 = view.FindViewById<Button>(Resource.Id.formation_button2);
            btn2.Click += StartDeust;
            Button btn3 = view.FindViewById<Button>(Resource.Id.formation_button3);
            btn3.Click += StartTNSI;
            Button btn4 = view.FindViewById<Button>(Resource.Id.formation_button4);
            btn4.Click += StartIRCOMS;
            //On utilise ceci pour retourner notre interface personnalisée pour ce Fragment
            //inflate est bien à utiliser pour les interfaces recycler 
            //on ajoute fragment_sample à la disposition parent qu'est container, mais on ne veut pas l'ajouter maintenant (false)
            return view;


        }


        //Cette méthode sera appelé après que View ai été créée 
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs); 
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();
            mSlidingTabScrollView.ViewPager = mViewPager;

        }

        void StartLicenceInfo(object sender, EventArgs e) {
            Intent intent = new Intent(this.Activity, typeof(licenceInfoActivity));
            StartActivity(intent);
        }

        void StartDeust(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(deustIOSI_Activity));
            StartActivity(intent);
        }

        void StartTNSI(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(masterTNSI_Activity));
            StartActivity(intent);
        }

        void StartIRCOMS(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(masterIRCOMS_Activity));
            StartActivity(intent);
        }

        public class SamplePagerAdapter : PagerAdapter //Page actuelle
        {
            List<string> items = new List<string>();

            //Constructeur
            public SamplePagerAdapter() : base()
            {
                items.Add("Université");
                items.Add("Contacts");
                items.Add("Formations");
                items.Add("Aide");
                
            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                View view1 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                View view2 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_contact, container, false);
                View view3 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_formation, container, false);
                View view4 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_help, container, false);
                View view5 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.licence_informatique, container, false);

                
                if (position == 0)
                {
                    container.AddView(view1);
                    return view1;
                }
                else if (position == 1)
                {
                    container.AddView(view2);
                    return view2;
                }
                else if (position == 2)
                {
                    container.AddView(view3);
                    
                    return view3;
                }
                else
                {
                    container.AddView(view4);
                    return view4;
                }

            }

            //En fonction de la position retourne la chaîne de caractère correspondante (le titre)
            public string GetHeaderTitle (int position)
            {
                return items[position];
            }

            //Retire une page pour une position donnée
            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj); //On sait que obj sera un view
            }

            

        }
    }
 }