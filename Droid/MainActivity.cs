using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CISolution;

namespace CISolution.Droid
{
	[Activity (Label = "CISolution.Droid", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity {

		protected override void OnCreate (Bundle bundle) {
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			Button buttonUploadImage = FindViewById<Button> (Resource.Id.button2);
			Button buttonUploadVideo = FindViewById<Button> (Resource.Id.button);

			
			buttonUploadImage.Click += delegate {
				StartActivity(typeof(UploadImageActivity));
			};

			buttonUploadVideo.Click += delegate {
				StartActivity(typeof(UploadVideoActivity));
			};
		}
	}
}


