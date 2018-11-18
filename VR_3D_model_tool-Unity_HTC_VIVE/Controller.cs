using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRTK;

public class Controller : MonoBehaviour {
	public GameObject rayCamera, leftHand, rightHand;
	GameObject gazedObject, prefab, clickedObject;
	List<GameObject> choosedObjects;
	bool hastouch = false, hasClicked = false;
	public bool activeOrNot = true;
	int gazeState {
		get {
			if (hasClicked) {
				return 2;
			} else if (hastouch) {
				return 1;
			} else {
				return 0;
			}
		}
	}
	// Use this for initialization
	void Start () {
		enableTheEvent ();
	}

	public void disableTheEvent (bool a = true, bool b = true, bool c = true) {
		if (a) {
			rayCamera.GetComponent<RayCollidision> ().raycastIn -= gazeon;
			rayCamera.GetComponent<RayCollidision> ().raycastout -= gazeout;
		}

		if (b) {
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerClicked -= new ControllerInteractionEventHandler (DoTriggerClicked);
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerUnclicked -= new ControllerInteractionEventHandler (DoTriggerUnclicked);
		}

		if (c) {
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerTouchStart -= new ControllerInteractionEventHandler (DoTriggerTouchStart);
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerTouchEnd -= new ControllerInteractionEventHandler (DoTriggerTouchEnd);
		}
	}

	public void enableTheEvent (bool a = true, bool b = true, bool c = true) {
		if (a) {
			rayCamera.GetComponent<RayCollidision> ().raycastIn += gazeon;
			rayCamera.GetComponent<RayCollidision> ().raycastout += gazeout;
		}

		if (b) {
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerClicked += new ControllerInteractionEventHandler (DoTriggerClicked);
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerUnclicked += new ControllerInteractionEventHandler (DoTriggerUnclicked);
		}

		if (c) {
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerTouchStart += new ControllerInteractionEventHandler (DoTriggerTouchStart);
			rightHand.GetComponent<VRTK_ControllerEvents> ().TriggerTouchEnd += new ControllerInteractionEventHandler (DoTriggerTouchEnd);
		}
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}

	void gazeon (GameObject g) {
		if (g.GetComponent<EventOn>() != null) {
			g.GetComponent<EventOn> ().gazeOnEvent (gazeState);
			gazedObject = g;
		}
	}
	void gazeout (GameObject g) {
		if (g.GetComponent<EventOn>() != null) {
			g.GetComponent<EventOn> ().gazeOutEvent (gazeState);
		}
		if (g == gazedObject) {
			gazedObject = null;
		}
	}

	private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
	{
		if (gazedObject != null) {
			if (gazedObject.GetComponent<EventOn> () != null) {
				gazedObject.GetComponent<EventOn> ().clickEvent ();
				clickedObject = gazedObject;
			}
		}
		hasClicked = true;
	}

	private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
	{
		if (gazedObject != null) {
			if (gazedObject.GetComponent<EventOn> () != null) {
				gazedObject.GetComponent<EventOn> ().unclickEvent ();
				if (gazedObject == clickedObject) {
					gazedObject.GetComponent<EventOn> ().fullClickEvent ();
				}
			}
		}
		hasClicked = false;
	}

	private void DoTriggerTouchStart(object sender, ControllerInteractionEventArgs e)
	{
		if (gazedObject != null) {
			if (gazedObject.GetComponent<EventOn> () != null) {
				gazedObject.GetComponent<EventOn> ().touchEvent ();
			}
		}
		hastouch = true;
	}

	private void DoTriggerTouchEnd(object sender, ControllerInteractionEventArgs e)
	{
		if (gazedObject != null) {
			if (gazedObject.GetComponent<EventOn> () != null) {
				gazedObject.GetComponent<EventOn> ().untouchEvent ();
			}
		}
		hastouch = false;
	}

}
