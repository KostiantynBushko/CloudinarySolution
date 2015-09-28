using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CISolution.iOS
{
	partial class UploadVideoViewController : UIViewController
	{

		CloudinaryDotNet.Actions.FileDescription fd;
		UIImagePickerController pickerController;
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
				
				uploadResult = new CISolution.CloudinaryHelper().uploadVideo(fd);

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
				fd = new CloudinaryDotNet.Actions.FileDescription ("video",data.AsStream());
				uploadVideo.Enabled = true;
			} 

			pickerController.DismissViewController (true, null);
		}

		void cancelImagePicker(object sender, EventArgs eventArgs) {
			pickerController.DismissViewController (true, null);
			Console.WriteLine ("Canceled image picker");
		}
	}
}
