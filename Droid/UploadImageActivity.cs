
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

namespace CISolution.Droid
{
	[Activity (Label = "UploadImageActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class UploadImageActivity : Activity
	{
		ImageView imageView; 
		Android.Net.Uri uri;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.upload_image_layout);
			Button selectImage = FindViewById<Button> (Resource.Id.button2);
			Button uploadImage = FindViewById<Button> (Resource.Id.button);

			imageView = FindViewById<ImageView> (Resource.Id.imageView);

			selectImage.Click += delegate {
				Intent intent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
				StartActivityForResult(intent, 0);
			};

			uploadImage.Click += delegate {
				new UploadTask().Execute(new Java.Lang.Object[]{GetPathFromUri(uri)});
			};
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data) {
			base.OnActivityResult (requestCode, resultCode, data);
			switch (requestCode) {
			case 0:
				{
					if (resultCode == Result.Ok) {
						uri = data.Data;
						imageView.SetImageURI (uri);
					}
					break;
				}
			}
		}


		public string GetPathFromUri(Android.Net.Uri uri)
		{
			string path = null;
			// The projection contains the columns we want to return in our query.
			string[] projection = new[] { Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };
			using (Android.Database.ICursor cursor = ManagedQuery(uri, projection, null, null, null))
			{
				if (cursor != null)
				{
					int columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
					cursor.MoveToFirst();
					path = cursor.GetString(columnIndex);
				}
			}
			return path;
		}

		public class UploadTask : AsyncTask {

			protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params) {
				new CISolution.CloudinaryHelper ().uploadImage ((string)@params [0]);
				return null;
			}
		}
	}
}

