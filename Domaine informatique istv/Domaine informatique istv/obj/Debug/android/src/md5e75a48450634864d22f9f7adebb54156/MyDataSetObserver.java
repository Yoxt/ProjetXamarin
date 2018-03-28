package md5e75a48450634864d22f9f7adebb54156;


public class MyDataSetObserver
	extends android.database.DataSetObserver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onChanged:()V:GetOnChangedHandler\n" +
			"n_onInvalidated:()V:GetOnInvalidatedHandler\n" +
			"";
		mono.android.Runtime.register ("Com.Hold1.MyDataSetObserver, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", MyDataSetObserver.class, __md_methods);
	}


	public MyDataSetObserver ()
	{
		super ();
		if (getClass () == MyDataSetObserver.class)
			mono.android.TypeManager.Activate ("Com.Hold1.MyDataSetObserver, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onChanged ()
	{
		n_onChanged ();
	}

	private native void n_onChanged ();


	public void onInvalidated ()
	{
		n_onInvalidated ();
	}

	private native void n_onInvalidated ();

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
