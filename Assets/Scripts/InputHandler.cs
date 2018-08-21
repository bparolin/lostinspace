using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InputHandler : MonoBehaviour {
	[HideInInspector]
	public Action buttonQ;
	[HideInInspector]
	public Action buttonD;
	[HideInInspector]
	public Action buttonZ;
	[HideInInspector]
	public Action buttonF;
	[HideInInspector]
	public Action buttonSpace;

	// Update is called once per frame
	private void Update () {
		if (Input.GetKey (KeyCode.Q) == true || Input.GetKey (KeyCode.LeftArrow) == true)
			buttonQ ();
		if (Input.GetKey (KeyCode.D) == true || Input.GetKey (KeyCode.RightArrow) == true)
			buttonD ();
		if (Input.GetKey (KeyCode.Z) == true || Input.GetKey (KeyCode.UpArrow) == true)
			buttonZ ();
		if (Input.GetKeyDown (KeyCode.F) == true)
			buttonF ();
		if (Input.GetKeyDown (KeyCode.Space) == true)
			buttonSpace ();
	}

	public void ResetButtons () {
		buttonQ = DoNothing;
		buttonD = DoNothing;
		buttonZ = DoNothing;
		buttonF = DoNothing;
		buttonSpace = DoNothing;
	}

	public void DoNothing () {

	}
}
