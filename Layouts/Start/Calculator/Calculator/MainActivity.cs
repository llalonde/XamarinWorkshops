using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Java.Lang;
using NCalc;

// This software includes the NCalc Library: Copyright (C) 2011 sebastienros
// NCalc Package: http://ncalc.codeplex.com/
// Created By: Sebastien Ros - http://www.codeplex.com/site/users/view/sebastienros
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software
// and associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.


namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private StringBuilder _expressionBuilder;
        private TextView _expressionTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // TODO: Use SetContentView to the layout

            // TODO: Use FindViewById<TextView> to retrieve a handle to the TextView in the Main.axml layout
            // Set _expressionTextView to the TextView.

            _expressionBuilder = new StringBuilder();

        }

        [Java.Interop.Export("CalcButtonPressed")]
        public void CalcButtonPressed(View view)
        {
            Button btn = view as Button;
            if (btn == null)
                return;

            switch (btn.Text)
            {
                case "C":
                    ClearAll();
                    break;
                case "=":
                    Calculate();
                    break;
                case "CE":
                    ClearLastEntry();
                    break;
                default:
                    _expressionBuilder.Append(btn.Text);
                    break;
            }

            UpdateExpressionTextView();
        }

        private void UpdateExpressionTextView()
        {
            _expressionTextView.Text = _expressionBuilder.ToString();
        }

        private void ClearAll()
        {
            _expressionBuilder = new StringBuilder();

        }

        private void ClearLastEntry()
        {
            if (_expressionBuilder.Length() > 0)
                _expressionBuilder.DeleteCharAt(_expressionBuilder.Length()-1);
        }

        private void Calculate()
        {
            Expression e = new Expression(_expressionBuilder.ToString());
            var result = e.Evaluate().ToString();
            ClearAll();

            _expressionBuilder.Append(result);
        }
    }


}

