using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Text.Method;
using Android.Transitions;

namespace ActivityLifecycleDemo
{
    [Activity(Label = "ActivityLifecycleDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView statusTextView;
        private Button launchActivityButton;
        private Button launchWebUrlButton;

        private const string ActivityName = "MainActivity";
        private const string StatusKey = "Status";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            statusTextView = FindViewById<TextView>(Resource.Id.statusTextView);

            //ensure the textview scrolls vertically if the text goes off screen
            statusTextView.MovementMethod = new ScrollingMovementMethod();

            if (bundle != null)
            {
                statusTextView.Text = bundle.GetString(StatusKey);
            }

            launchActivityButton = FindViewById<Button>(Resource.Id.launchActivity);
            launchActivityButton.Click += delegate(object sender, EventArgs args)
            {
                StartActivity(typeof(NotMainActivity));
            };

            launchWebUrlButton = FindViewById<Button>(Resource.Id.launchWebUrl);
            launchWebUrlButton.Click += delegate (object sender, EventArgs args)
            {
                var uri = Android.Net.Uri.Parse("http://www.meetup.com/cttdnug");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };

            SetStatus($"{ActivityName} Created");
        }

        protected override void OnStart()
        {
            base.OnStart();
            SetStatus($"{ActivityName} Started");
        }

        protected override void OnResume()
        {
            base.OnResume();
            SetStatus($"{ActivityName} Resumed");
        }

        protected override void OnPause()
        {
            base.OnPause();
            SetStatus($"{ActivityName} Paused");
        }

        protected override void OnStop()
        {
            base.OnStop();
            SetStatus($"{ActivityName} Stopped");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            SetStatus($"{ActivityName} Saved instance state");
            outState.PutString(StatusKey, statusTextView.Text);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            if (savedInstanceState != null)
            {
                statusTextView.Text = savedInstanceState.GetString(StatusKey);
                SetStatus($"{ActivityName} Restored instance state");
            }
        }

        private void SetStatus(string status)
        {
            if (statusTextView != null)
                statusTextView.Text += status + System.Environment.NewLine;
        }


    }
}

