using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CISolution.iOS
{
	partial class UploadImageViewController : UIViewController {

		UIImagePickerController imagePicker = null;
		string imageFilePath = null;
		CloudinaryDotNet.Actions.ImageUploadResult uploadResult = null;

		#region View lifecycle
		public UploadImageViewController (IntPtr handle) : base (handle) {
			
		}

		public override void ViewDidLoad () {

			uploadImage.Enabled = false;

			imagePicker = new UIImagePickerController();
			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.PhotoLibrary);
			imagePicker.FinishedPickingMedia += finishPickImage;
			imagePicker.Canceled += cancelImagePicker;

			selectImage.TouchUpInside += (sender, e) => {
				Console.WriteLine ("Execute image picker controller");
				PresentViewController(imagePicker,true, null);
			};

			uploadImage.TouchUpInside += (sender, e) => {
				Console.WriteLine("Execute cloudinary upload image " + imageFilePath);

				uploadResult = new CISolution.CloudinaryHelper().uploadImage(imageFilePath);

				if(uploadResult.Error == null) {
					Console.WriteLine("Video success uploaded...");
				} else {
					Console.WriteLine("Error : " + uploadResult.Error.Message);
				}
				uploadImage.Enabled = false;
			};
		}
		#endregion

		protected void finishPickImage (object sender, UIImagePickerMediaPickedEventArgs e) {

			if (e.Info [UIImagePickerController.MediaType].ToString ().Equals ("public.image")) {
				UIImage originalImage = e.Info [UIImagePickerController.OriginalImage] as UIImage;
				if (originalImage != null) {
					imageView.Image = originalImage;
					string documentsDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
					string path = System.IO.Path.Combine (documentsDirectory, "image.jpg");
					NSData imgData = originalImage.AsJPEG ();
					NSError err = null;
					if (imgData.Save (path, false, out err)) {
						Console.WriteLine ("Save image to application bundle directory as : " + path);
						this.imageFilePath = path;
						uploadImage.Enabled = true;
					} else {
						this.imageFilePath = null;
					}
				}
			} 
			imagePicker.DismissViewController (true, null);
		}

		void cancelImagePicker(object sender, EventArgs eventArgs) {
			imagePicker.DismissViewController (true, null);
			Console.WriteLine ("Canceled image picker");
		}
	}
}
