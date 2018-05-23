package md53ea4b3039098c5e1a6404f859b7754b4;


public class MainActivity_MyData
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ListViewSwitchTest.MainActivity+MyData, ListViewSwitchTest", MainActivity_MyData.class, __md_methods);
	}


	public MainActivity_MyData ()
	{
		super ();
		if (getClass () == MainActivity_MyData.class)
			mono.android.TypeManager.Activate ("ListViewSwitchTest.MainActivity+MyData, ListViewSwitchTest", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_MyData (java.lang.String p0, boolean p1)
	{
		super ();
		if (getClass () == MainActivity_MyData.class)
			mono.android.TypeManager.Activate ("ListViewSwitchTest.MainActivity+MyData, ListViewSwitchTest", "System.String, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

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
