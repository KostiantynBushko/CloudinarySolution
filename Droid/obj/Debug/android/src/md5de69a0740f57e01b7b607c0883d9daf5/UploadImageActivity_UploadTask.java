package md5de69a0740f57e01b7b607c0883d9daf5;


public class UploadImageActivity_UploadTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("CISolution.Droid.UploadImageActivity/UploadTask, CISolution.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", UploadImageActivity_UploadTask.class, __md_methods);
	}


	public UploadImageActivity_UploadTask () throws java.lang.Throwable
	{
		super ();
		if (getClass () == UploadImageActivity_UploadTask.class)
			mono.android.TypeManager.Activate ("CISolution.Droid.UploadImageActivity/UploadTask, CISolution.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);

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
