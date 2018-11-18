using UnityEngine;
using System.Collections;

public class ActionItem : MonoBehaviour {

	GameObject controller;

	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	public void actionMethod () {
		controller.GetComponent<RuleController> ().recieveActionName (this.gameObject.name);
	}
}
