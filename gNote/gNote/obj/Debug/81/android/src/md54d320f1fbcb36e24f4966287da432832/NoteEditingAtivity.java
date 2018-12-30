package md54d320f1fbcb36e24f4966287da432832;


public class NoteEditingAtivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("gNote.NoteEditingAtivity, gNote", NoteEditingAtivity.class, __md_methods);
	}


	public NoteEditingAtivity ()
	{
		super ();
		if (getClass () == NoteEditingAtivity.class)
			mono.android.TypeManager.Activate ("gNote.NoteEditingAtivity, gNote", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
