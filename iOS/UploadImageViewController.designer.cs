// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CISolution.iOS
{
	[Register ("UploadImageViewController")]
	partial class UploadImageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton selectImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton uploadImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
			if (selectImage != null) {
				selectImage.Dispose ();
				selectImage = null;
			}
			if (uploadImage != null) {
				uploadImage.Dispose ();
				uploadImage = null;
			}
		}
	}
}
