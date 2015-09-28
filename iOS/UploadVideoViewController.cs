using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CISolution.iOS
{
	partial class UploadVideoViewController : UIViewController
	{

		UIImagePickerController pickerController;
		string videoPath;
		CloudinaryDotNet.Actions.VideoUploadResult uploadResult = null;
		UIAlertController alertController = null;

		public UploadVideoViewController (IntPtr handle) : base (handle) {}

		public override void ViewDidLoad() {

			uploadVideo.Enabled = false;

			pickerController = new UIImagePickerController();
			pickerController.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			pickerController.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.PhotoLibrary);
			pickerController.FinishedPickingMedia += finishPickImage;
			pickerController.Canceled += cancelImagePicker;

			selectVideo.TouchUpInside += (sender, e) => PresentViewController (pickerController, true, null);

			uploadVideo.TouchUpInside += (sender, e) =>  {
				Console.WriteLine("Execute cloudinary upload video " + videoPath);

				uploadResult = new CISolution.CloudinaryHelper().uploadVideo(videoPath);

				if(uploadResult.Error == null) {
					alertController = UIAlertController.Create("Success", uploadResult.JsonObj.ToString(), UIAlertControllerStyle.ActionSheet);
				} else {
					alertController = UIAlertController.Create("Error", uploadResult.Error.Message, UIAlertControllerStyle.ActionSheet);
				}

				alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
				PresentViewController(alertController,true,null);
				uploadVideo.Enabled = false;
			};
		}

		protected void finishPickImage (object sender, UIImagePickerMediaPickedEventArgs e) {

			if(e.Info [UIImagePickerController.MediaType].ToString ().Equals ("public.movie")) {
				NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
				NSData data = NSData.FromUrl (mediaURL);
				string documentsDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				string path = System.IO.Path.Combine (documentsDirectory, "video.m4v");
				NSError err = null;
				if (data.Save (path, false, out err)) {
					Console.WriteLine ("Save video to application bundle directory as : " + path);
					this.videoPath = path;
					uploadVideo.Enabled = true;
				} else {
					this.videoPath = null;
				}
			} 

			pickerController.DismissViewController (true, null);
		}

		void cancelImagePicker(object sender, EventArgs eventArgs) {
			pickerController.DismissViewController (true, null);
			Console.WriteLine ("Canceled image picker");
		}
	}
}
