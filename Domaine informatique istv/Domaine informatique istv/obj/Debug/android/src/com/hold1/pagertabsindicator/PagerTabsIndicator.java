package com.hold1.pagertabsindicator;


public class PagerTabsIndicator
	extends android.widget.HorizontalScrollView
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.OnPageChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_measureChildWithMargins:(Landroid/view/View;IIII)V:GetMeasureChildWithMargins_Landroid_view_View_IIIIHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_onPageScrollStateChanged:(I)V:GetOnPageScrollStateChanged_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"n_onPageScrolled:(IFI)V:GetOnPageScrolled_IFIHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"n_onPageSelected:(I)V:GetOnPageSelected_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"";
		mono.android.Runtime.register ("Com.Hold1.PagerTabsIndicator, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", PagerTabsIndicator.class, __md_methods);
	}


	public PagerTabsIndicator (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PagerTabsIndicator.class)
			mono.android.TypeManager.Activate ("Com.Hold1.PagerTabsIndicator, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public PagerTabsIndicator (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PagerTabsIndicator.class)
			mono.android.TypeManager.Activate ("Com.Hold1.PagerTabsIndicator, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public PagerTabsIndicator (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PagerTabsIndicator.class)
			mono.android.TypeManager.Activate ("Com.Hold1.PagerTabsIndicator, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PagerTabsIndicator (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == PagerTabsIndicator.class)
			mono.android.TypeManager.Activate ("Com.Hold1.PagerTabsIndicator, PagerTabIndicator, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public void measureChildWithMargins (android.view.View p0, int p1, int p2, int p3, int p4)
	{
		n_measureChildWithMargins (p0, p1, p2, p3, p4);
	}

	private native void n_measureChildWithMargins (android.view.View p0, int p1, int p2, int p3, int p4);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);


	public void onPageScrollStateChanged (int p0)
	{
		n_onPageScrollStateChanged (p0);
	}

	private native void n_onPageScrollStateChanged (int p0);


	public void onPageScrolled (int p0, float p1, int p2)
	{
		n_onPageScrolled (p0, p1, p2);
	}

	private native void n_onPageScrolled (int p0, float p1, int p2);


	public void onPageSelected (int p0)
	{
		n_onPageSelected (p0);
	}

	private native void n_onPageSelected (int p0);

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
