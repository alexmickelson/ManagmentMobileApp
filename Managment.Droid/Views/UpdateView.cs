using Android.App;
using Android.OS;
using Managment.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Managment.Droid.Views
{
    [Activity(Label = "Update", MainLauncher = false)]
    public class UpdateView : MvxActivity<UpdateViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UpdateView);
        }
    }
}