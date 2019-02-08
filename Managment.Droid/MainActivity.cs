using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Core;
using System;
using Managment.Core;

namespace Managment.Droid
{
    [Application]
    public class MainActivity : MvxAndroidApplication<MvxAndroidSetup<app>, app>
    {
        public MainActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }
    }
}