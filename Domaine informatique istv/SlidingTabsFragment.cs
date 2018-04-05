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
using Android.Text.Method;

namespace Domaine_informatique_istv
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
      
        


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();
            mSlidingTabScrollView.ViewPager = mViewPager;

        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();
            public int btn1 = 0;
            private int btn2;
            private int btn3;
            private int btn4;

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
                View view6 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.deust_IOSI, container, false);
                View view7 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.master_TNSI, container, false);
                View view8 = LayoutInflater.From(container.Context).Inflate(Resource.Layout.master_IRCOMS, container, false);

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
                    var i = 0;
                    var button = view3.FindViewById<Button>(Resource.Id.formation_button1);
                    var button1 = view3.FindViewById<Button>(Resource.Id.formation_button2);
                    var button2 = view3.FindViewById<Button>(Resource.Id.formation_button3);
                    var button3 = view3.FindViewById<Button>(Resource.Id.formation_button4);



                    button.Click += (sender, args) => {
                        
                        this.btn1 = 1;

                    };
                    button1.Click += (sender, args) => {

                        this.btn1 = 2;

                    };
                    button2.Click += (sender, args) => {

                        this.btn1 = 3;

                    };
                    button3.Click += (sender, args) => {

                        this.btn1 = 4;

                    };


                    if (this.btn1 == 1)
                    {
                        this.btn1 = 0;
                        container.AddView(view5);
                        return view5;

                    }
                    else if (this.btn1 == 2)
                    {
                        this.btn1 = 0;
                        container.AddView(view6);
                        return view6;

                    }
                    else if (this.btn1 == 3)
                    {
                        this.btn1 = 0;
                        container.AddView(view7);
                        return view7;

                    }
                   else  if (this.btn1 == 4)
                    {
                        this.btn1 = 0;
                        container.AddView(view8);
                        return view8;

                    }
                    else
                    {
                        container.AddView(view3);
                        return view3;
                    }
                }
                else
                {
                    container.AddView(view4);
                     return view4;
                }
                    
      
            }

            public string GetHeaderTitle (int position)
            {
                return items[position];
            }
            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj); //On sait que obj sera un view
            }
        }
    }
 }