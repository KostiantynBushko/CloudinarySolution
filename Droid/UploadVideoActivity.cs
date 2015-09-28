
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
using System.Threading.Tasks;

namespace CISolution.Droid
{
	[Activity (Label = "UploadVideoActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class UploadVideoActivity : Activity
	{
		private VideoView videoView;
		private Android.Net.Uri uri;
		private Android.Content.Context context;
		CloudinaryDotNet.Actions.VideoUploadResult uploadResult = null;

		protected override void OnCreate (Bundle bundle) {
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.upload_video_layout);
			context = this;

			Button buttonSelect = FindViewById<Button> (Resource.Id.button2);
			Button buttonUpload = FindViewById<Button> (Resource.Id.button);
			videoView = FindViewById<VideoView> (Resource.Id.videoView);
			videoView.SetMediaController (new Android.Widget.MediaController (this));
			videoView.RequestFocus ();

			buttonSelect.Click += delegate {
				if(videoView != null) 
					videoView.Pause();
				Intent intent = new Intent (Intent.ActionPick, Android.Provider.MediaStore.Video.Media.ExternalContentUri);
				StartActivityForResult (intent, 0);
			};

			buttonUpload.Click += delegate {
				if(videoView != null) {
					if(videoView.IsPlaying) {
						videoView.Pause();
					}
					new UploadTask(context).Execute(new Java.Lang.Object[]{GetPathFromUri(uri)});
				} 
			};
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data) {
			base.OnActivityResult (requestCode, resultCode, data);
			switch (requestCode) {
			case 0:{
					if (resultCode == Result.Ok) {
						uri = data.Data;
						videoView.SetVideoURI (uri);
						videoView.Start ();
					}
					break;
				}
			default:
				break;
			}
		}

		public string GetPathFromUri(Android.Net.Uri uri) {
			string path = null;
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

		private class UploadTask : AsyncTask {

			CloudinaryDotNet.Actions.VideoUploadResult uploadResult = null;
			ProgressDialog progressDialog;
			Android.Content.Context context;

			public UploadTask(Android.Content.Context context) {
				this.context = context;
				progressDialog = ProgressDialog.Show (this.context, "Pleas wait","Uploading int progress", true);
			}
			protected override void OnPreExecute() {
			}

			protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params) {
				uploadResult = new CISolution.CloudinaryHelper().uploadVideo((string)@params[0]);
				return true;
			}

			protected override void OnPostExecute(Java.Lang.Object result) {
				base.OnPostExecute (result);
				progressDialog.Hide ();

				AlertDialog.Builder builder;
				builder = new AlertDialog.Builder(context);
				builder.SetTitle("Message");
				builder.SetMessage(uploadResult.JsonObj.ToString());
				builder.SetCancelable(false);
				builder.SetNegativeButton ("Cancel", (senderAlert, args) => {});
				builder.Show();
			}
		}
	}
}

