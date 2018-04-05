using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace Domaine_informatique_istv
{
    [Activity(Label = "Domaine_informatique_istv", MainLauncher = true, Icon ="@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

           

            Button commencez = FindViewById<Button>(Resource.Id.commencez);
            commencez.Click += (sender, e) =>
            {
                //open the new acitvity
                //Setup a new acitivty
                var intent = new Intent(this, typeof(SecondPage));
                StartActivity(intent);
            };
        }

       
    }
}

