using UnityEngine;
using System.Collections;

public class EventOn : MonoBehaviour {
	public delegate void  GazingEventHandle (int state);
	public delegate void  HandEventHandle ();
	public event GazingEventHandle gazeInObject;
	public event GazingEventHandle gazeOutObject;


	public event HandEventHandle clickObject;
	public event HandEventHandle unclickObject;

	public event HandEventHandle touchObject;
	public event HandEventHandle untouchObject;

	public event HandEventHandle fullClickObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gazeOnEvent (int s) {
		if (gazeInObject != null) {
			gazeInObject (s);
		}
	}

	public void gazeOutEvent (int s) {
		if (gazeOutObject != null) {
			gazeOutObject (s);
		}
	}



	public void clickEvent () {
		if (clickObject != null) {
			clickObject ();
		}
	}

	public void unclickEvent () {
		if (unclickObject != null) {
			unclickObject ();
		}
	}

	public void touchEvent () {
		if (touchObject != null) {
			touchObject ();
		}
	}

	public void untouchEvent () {
		if (untouchObject != null) {
			untouchObject ();
		}
	}

	public void fullClickEvent () {
		if (fullClickObject != null) {
			fullClickObject ();
		}
	}
}
