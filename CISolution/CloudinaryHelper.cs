using System;
using System.IO;
using CloudinaryDotNet;

namespace CISolution
{
	public class CloudinaryHelper {

		// Replace with your own cloud name, api key and api secret
		private static string CLOUD_NAME = "bushko";
		private static string API_KEY = "796715849772345";
		private static string API_SECRET = "ubwDreGbsrLp4NsLzRWzgGorSbw";

		private Account account;
		private Cloudinary cloudinary;

		public CloudinaryHelper () {
			account = new Account (CLOUD_NAME, API_KEY, API_SECRET);
			cloudinary = new Cloudinary (account);
		}

		public CloudinaryDotNet.Actions.VideoUploadResult uploadVideo(string videoFilePath) {
			CloudinaryDotNet.Actions.VideoUploadParams uploadParam = new CloudinaryDotNet.Actions.VideoUploadParams(){
				File = new CloudinaryDotNet.Actions.FileDescription(videoFilePath)
			};
			return cloudinary.Upload(uploadParam);
		}

		public CloudinaryDotNet.Actions.ImageUploadResult uploadImage(string imageFilePath) {
			CloudinaryDotNet.Actions.ImageUploadParams uploadParam = new CloudinaryDotNet.Actions.ImageUploadParams(){
				File = new CloudinaryDotNet.Actions.FileDescription(imageFilePath)
			};
			return cloudinary.Upload(uploadParam);
		}
			
		public CloudinaryDotNet.Actions.VideoUploadResult uploadVideo(CloudinaryDotNet.Actions.FileDescription fileDescription) {
			CloudinaryDotNet.Actions.VideoUploadParams uploadParam = new CloudinaryDotNet.Actions.VideoUploadParams(){
				File = fileDescription
			};
			return cloudinary.Upload(uploadParam);
		}

		public CloudinaryDotNet.Actions.ImageUploadResult uploadImage(CloudinaryDotNet.Actions.FileDescription fileDescription) {
			CloudinaryDotNet.Actions.ImageUploadParams uploadParam = new CloudinaryDotNet.Actions.ImageUploadParams(){
				File = fileDescription
			};
			return cloudinary.Upload(uploadParam);
		}
	}
}

