package md5e75a48450634864d22f9f7adebb54156;


public class MyRunnable
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Com.Hold1.MyRunnable, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", MyRunnable.class, __md_methods);
	}


	public MyRunnable ()
	{
		super ();
		if (getClass () == MyRunnable.class)
			mono.android.TypeManager.Activate ("Com.Hold1.MyRunnable, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

	private java.util.ArrayList refList;
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
