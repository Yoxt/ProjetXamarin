using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Domaine_informatique_istv
{
    [Activity(Label = "SecondPage")]
    public class SecondPage : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SlidingTabsFragment.SamplePagerAdapter A = new SlidingTabsFragment.SamplePagerAdapter();
            base.OnCreate(savedInstanceState);
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();
            SetContentView(Resource.Layout.SecondPage);
        }


        public void startLicence()
        {
          

        } 

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

    }
}