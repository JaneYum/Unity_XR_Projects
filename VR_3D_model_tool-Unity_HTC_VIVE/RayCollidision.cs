using UnityEngine;
using System.Collections;


public class RayCollidision : MonoBehaviour {

	public delegate void  RayEventHandle (GameObject g);
	public event RayEventHandle raycastIn;
	public event RayEventHandle raycastout;

	public GameObject tem = null;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//发射射线
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(transform.position, fwd,out hit))
		{
			if (hit.collider.gameObject != tem) {
				if (raycastout != null && tem != null) {
					raycastout (tem);
				}
				if (raycastIn != null) {
					raycastIn (hit.collider.gameObject);
				}
				tem = hit.collider.gameObject;
			}
		} 
	}
}
