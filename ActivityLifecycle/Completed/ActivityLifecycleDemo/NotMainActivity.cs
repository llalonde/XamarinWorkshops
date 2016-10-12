using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ActivityLifecycleDemo
{
    [Activity(Label = "NotMainActivity")]
    public class NotMainActivity : Activity
    {
        private const string StatusKey = "Status";
        private const string ActivityName = "NotMainActivity";

        private TextView notMainStatusTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NotMain);

            notMainStatusTextView = FindViewById<TextView>(Resource.Id.notMainStatusTextView);
            if (savedInstanceState != null)
            {
                notMainStatusTextView.Text = savedInstanceState.GetString(StatusKey);
            }

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
            outState.PutString(StatusKey, notMainStatusTextView.Text);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            if (savedInstanceState != null)
            {
                notMainStatusTextView.Text = savedInstanceState.GetString(StatusKey);
                SetStatus($"{ActivityName} Restored instance state");
            }
        }

        private void SetStatus(string status)
        {
            if (notMainStatusTextView != null)
                notMainStatusTextView.Text += status + System.Environment.NewLine;
        }


    }

}