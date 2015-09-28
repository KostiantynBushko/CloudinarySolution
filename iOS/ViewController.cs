using System;
		
using UIKit;

namespace CISolution.iOS
{
	public partial class ViewController : UIViewController {

		public ViewController (IntPtr handle) : base (handle) {		
		}
			

		public override void ViewDidLoad () {
			base.ViewDidLoad ();

//			uploadVideo.TouchUpInside += (object sender, EventArgs e) => {
//				Console.WriteLine(" Upload Video: button click");
//				Console.WriteLine(" run action");
//			};
//
//			uploadImage.TouchUpInside += (object sender, EventArgs e) => {
//				Console.WriteLine(" Upload Image: button click");
//				Console.WriteLine(" run action");
//			};
		}


		public override void DidReceiveMemoryWarning () {		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
