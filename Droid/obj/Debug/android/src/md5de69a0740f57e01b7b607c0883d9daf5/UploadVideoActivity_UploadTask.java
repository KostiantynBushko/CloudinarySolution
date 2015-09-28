package md5de69a0740f57e01b7b607c0883d9daf5;


public class UploadVideoActivity_UploadTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("CISolution.Droid.UploadVideoActivity/UploadTask, CISolution.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", UploadVideoActivity_UploadTask.class, __md_methods);
	}


	public UploadVideoActivity_UploadTask () throws java.lang.Throwable
	{
		super ();
		if (getClass () == UploadVideoActivity_UploadTask.class)
			mono.android.TypeManager.Activate ("CISolution.Droid.UploadVideoActivity/UploadTask, CISolution.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public UploadVideoActivity_UploadTask (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == UploadVideoActivity_UploadTask.class)
			mono.android.TypeManager.Activate ("CISolution.Droid.UploadVideoActivity/UploadTask, CISolution.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
