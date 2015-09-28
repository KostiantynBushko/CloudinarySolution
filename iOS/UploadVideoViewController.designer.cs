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
	[Register ("UploadVideoViewController")]
	partial class UploadVideoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton selectVideo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton uploadVideo { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (selectVideo != null) {
				selectVideo.Dispose ();
				selectVideo = null;
			}
			if (uploadVideo != null) {
				uploadVideo.Dispose ();
				uploadVideo = null;
			}
		}
	}
}
