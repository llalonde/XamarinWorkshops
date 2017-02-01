// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ViewDemo
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CharsEnteredLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView ContactBio { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MyButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CharsEnteredLabel != null) {
                CharsEnteredLabel.Dispose ();
                CharsEnteredLabel = null;
            }

            if (ContactBio != null) {
                ContactBio.Dispose ();
                ContactBio = null;
            }

            if (MyButton != null) {
                MyButton.Dispose ();
                MyButton = null;
            }
        }
    }
}