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
    [Activity(Label = "formationActivity")]
    public class formationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.pager_formation);


            Button formation_button1 = FindViewById<Button>(Resource.Id.formation_button1);
            formation_button1.Click += (sender, e) =>
            {
                //open the new acitvity
                //Setup a new acitivty
                var intent = new Intent(this, typeof(licenceInfoActivity));
                StartActivity(intent);
            };

            Button formation_button2 = FindViewById<Button>(Resource.Id.formation_button2);
            formation_button2.Click += (sender, e) =>
            {
                //open the new acitvity
                //Setup a new acitivty
                var intent = new Intent(this, typeof(deustIOSI_Activity));
                StartActivity(intent);
            };
            Button formation_button3 = FindViewById<Button>(Resource.Id.formation_button3);
            formation_button3.Click += (sender, e) =>
            {
                //open the new acitvity
                //Setup a new acitivty
                var intent = new Intent(this, typeof(masterTNSI_Activity));
                StartActivity(intent);
            };

            Button formation_button4 = FindViewById<Button>(Resource.Id.formation_button4);
            formation_button4.Click += (sender, e) =>
            {
                //open the new acitvity
                //Setup a new acitivty
                var intent = new Intent(this, typeof(masterIRCOMS_Activity));
                StartActivity(intent);
            };
        }
    }
}