using UnityEngine;
using System.Collections;

public class ModelController : MonoBehaviour {
	public Material lightMaterial, normal, choosedMaterial;
	GameObject Controller;
	int states = 0;
	int state {
		set {
			if (value == 0) {
				this.GetComponent<Renderer> ().material = normal;
				states = value;
			}
			if (value == 1) {
				this.GetComponent<Renderer> ().material = lightMaterial;
				states = value;
			}
			if (value == 2) {
				this.GetComponent<Renderer> ().material = choosedMaterial;
				states = value;
			}
		}
		get {
			return states;
		}
	}
	// Use this for initialization
	void Start () {
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		if (this.GetComponent<EventOn> () != null) {
			this.GetComponent<EventOn> ().touchObject += touch;
			this.GetComponent<EventOn> ().untouchObject += untouch;
			this.GetComponent<EventOn> ().fullClickObject += fullClick;
			this.GetComponent<EventOn> ().gazeInObject += gazeIn;
			this.GetComponent<EventOn> ().gazeOutObject += gazeOut;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void touch () {
		if (state == 0)
		state = 1;
	}

	void untouch () {
		Debug.Log (state);
		if (state == 1)
		state = 0;
	}

	void fullClick () {
		if (state != 2) {
			state = 2;
			Controller.GetComponent<RuleController> ().addChoosedObject (this.gameObject);
		} else {
			state = 0;
			Controller.GetComponent<RuleController> ().removeChoosedObject (this.gameObject);
		}

	}

	void gazeIn (int s) {
		if (s > 0 && state < 2) {
			state = 1;
		}
	}

	void gazeOut (int s) {
		if (state < 2)
		state = 0;
	}
}
