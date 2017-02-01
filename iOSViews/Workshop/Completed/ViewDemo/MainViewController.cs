
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ViewDemo
{
    public partial class MainViewController : UIViewController
    {
        Random random = new Random();

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        private void ContactBioOnChanged(object sender, EventArgs eventArgs)
        {
            this.CharsEnteredLabel.Text = $"{ContactBio.Text.Length} characters";

        }


        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ContactBio.Changed += ContactBioOnChanged;

            MyButton.SetTitle("Click me", UIControlState.Normal);
            MyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            MyButton.SetTitleColor(UIColor.White, UIControlState.Selected);

            MyButton.TouchUpInside += MyButtonOnTouchUpInside;

            // Keyboard popup
            NSNotificationCenter.DefaultCenter
                .AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);

            // Keyboard Down
            NSNotificationCenter.DefaultCenter
                .AddObserver (UIKeyboard.WillHideNotification, KeyBoardDownNotification);

        }

        private void MyButtonOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            MyButton.BackgroundColor = UIColor.FromRGB(r, g, b);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            this.ContactBio.Changed -= ContactBioOnChanged;
        }

        #endregion

        #region KeyBoard Notification
        //Credits: http://www.gooorack.com/2013/08/28/xamarin-moving-the-view-on-keyboard-show/

        private UIView activeView;
        private nfloat scrollAmount = 0.0f;
        private nfloat bottom = 0.0f;
        private nfloat offset = 30.0f;
        private bool moveViewUp;

        private void KeyBoardUpNotification(NSNotification notification)
        {
            // get the keyboard size
            CGRect r = UIKeyboard.BoundsFromNotification(notification);

            // Find what opened the keyboard
            foreach (UIView view in View.Subviews)
            {
                if (view.IsFirstResponder)
                {
                    activeView = view;
                    break;
                }

            }

            // Bottom of the controller = initial position + height + offset
            bottom = (activeView.Frame.Y + activeView.Frame.Height + offset);

            // Calculate how far we need to scroll
            scrollAmount = (r.Height - (View.Frame.Size.Height - bottom));

            // Perform the scrolling
            if (scrollAmount > 0)
            {
                moveViewUp = true;
                ScrollTheView(moveViewUp);
            }
            else
            {
                moveViewUp = false;
                ResetView();
            }

        }

        private void KeyBoardDownNotification(NSNotification notification)
        {
            if (moveViewUp)
            {
                ScrollTheView(false);
            }
        }

        private void ResetView()
        {
            UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
            UIView.SetAnimationDuration(0.3);
            View.Frame = UIScreen.MainScreen.Bounds;
            UIView.CommitAnimations();
        }

        private void ScrollTheView(bool move)
        {

            // scroll the view up or down
            UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
            UIView.SetAnimationDuration(0.3);

            CGRect frame = View.Frame;

            if (move)
            {
                frame.Y -= scrollAmount;
            }
            else
            {
                frame.Y += scrollAmount;
                scrollAmount = 0;
            }

            View.Frame = frame;
            UIView.CommitAnimations();
        }
        #endregion

    }
}