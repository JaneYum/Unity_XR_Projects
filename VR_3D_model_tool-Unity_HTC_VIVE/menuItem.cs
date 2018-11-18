using UnityEngine;
using System.Collections;

public class menuItem : MonoBehaviour {

	public Sprite highlight, nomal;
	public GameObject prefab;
	GameObject a, controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
		if (this.GetComponent<EventOn> () != null) {
			this.GetComponent<EventOn> ().gazeInObject += highlightObject;
			this.GetComponent<EventOn> ().gazeOutObject += normalObject;
			if (this.GetComponent<ActionItem> () != null) {
				this.GetComponent<EventOn> ().clickObject += this.GetComponent<ActionItem> ().actionMethod;
			} else {
				this.GetComponent<EventOn> ().clickObject += clone;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void highlightObject (int s) {
		this.GetComponent<SpriteRenderer> ().sprite = highlight;
	}

	void normalObject (int s) {
		this.GetComponent<SpriteRenderer> ().sprite = nomal;
	}

	void clone() {
		if (prefab != null) {
			a = (GameObject)Instantiate (prefab, this.transform.position, this.transform.rotation);
			controller.GetComponent<RuleController> ().getPrefab (a);
		}
	}
}
