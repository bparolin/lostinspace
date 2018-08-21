using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent (typeof (Camera))]
public class CameraHandler : MonoBehaviour {
	public GameObject followedObject;

	private static CameraHandler INSTANCE;

	public static CameraHandler instance () {
		return INSTANCE;
	}

	private void Awake () {
		if (INSTANCE == null) {
			INSTANCE = this;
		} else {
			Debug.Log ("Error: Two instances of CameraHandler");
			Destroy (this);
		}
	}
	
	public void SetFollowedObject (GameObject objectToFollow) {
		followedObject = objectToFollow;
	}


	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = new Vector3 (followedObject.transform.position.x, followedObject.transform.position.y, this.transform.position.z);
		this.transform.rotation = followedObject.transform.rotation;
	}
}
