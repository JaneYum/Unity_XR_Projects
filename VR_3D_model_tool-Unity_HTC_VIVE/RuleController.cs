using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRTK;

public class RuleController : MonoBehaviour {
	public GameObject rightHand, modelHouse, menus, zoomPlace;
	GameObject prefab;
	List<GameObject> choosedObjects = new List<GameObject>();
	string actionName = "", selfAction = "";
	Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		rightHand.GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);
		rightHand.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);
	}
	
	// Update is called once per frame
	void Update () {
		if (selfAction == "Rotate") {
			foreach (GameObject g in choosedObjects) {
				g.transform.rotation = rightHand.transform.rotation;
			}
		}
		if (selfAction == "Zoom") {
			Vector3 distance = rightHand.transform.position - lastPosition;
			Debug.Log (distance);
			Vector3 newScala = Vector3.one + distance * 0.3f;
			Debug.Log (newScala);
			zoomPlace.transform.localScale = newScala;
		}
	}

	public void addChoosedObject(GameObject g) {
		choosedObjects.Add (g);
		menus.GetComponent<MenuModel> ().setMenuState (1);
	}

	public void removeChoosedObject(GameObject g) {
		choosedObjects.Remove (g);
		menus.GetComponent<MenuModel> ().setMenuState (choosedObjects.Count > 0 ? 1 : 0);
	}

	public void getPrefab(GameObject p) {
		prefab = p;
		p.transform.parent = rightHand.transform;
		p.transform.localPosition = Vector3.zero;
		//this.GetComponent<Controller> ().disableTheEvent ();
	}

	private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
	{
		if (prefab) {
			prefab.transform.parent = modelHouse.transform;
			prefab = null;
		}
		if (actionName == "Move") {
			foreach (GameObject g in choosedObjects) {
				g.transform.parent = modelHouse.transform;
			}
		}

		if (actionName == "Rotate" || actionName == "Zoom") {
			selfAction = "";
			foreach (GameObject g in choosedObjects) {
				g.transform.parent = modelHouse.transform;
			}
		}
		//this.GetComponent<Controller> ().enableTheEvent ();
	}

	private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
	{
		if (actionName == "Move") {
			foreach (GameObject g in choosedObjects) {
				g.transform.parent = rightHand.transform;
			}
		}
		if (actionName == "Rotate") {
			selfAction = actionName;
		}

		if (actionName == "Zoom") {
			selfAction = actionName;
			lastPosition = rightHand.transform.position;
			foreach (GameObject g in choosedObjects) {
				g.transform.parent = zoomPlace.transform;
			}
		}
	}

	public void recieveActionName(string s) {
		actionName = s;
	}
}
