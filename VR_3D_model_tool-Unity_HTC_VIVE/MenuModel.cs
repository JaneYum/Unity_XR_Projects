using UnityEngine;
using System.Collections;

public class MenuModel : MonoBehaviour {
	public int state = 0;
	public GameObject[] menus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setMenuState (int i) {
		for (int k = 0; k < menus.Length; k++) {
			menus [k].SetActive (false);
		}
		menus [i].SetActive (true);
	}

}
