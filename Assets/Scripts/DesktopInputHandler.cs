using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DesktopInputHandler : InputHandler {
	// Update is called once per frame
	private void Update () {
		if (Input.GetKey (KeyCode.Q) == true || Input.GetKey (KeyCode.LeftArrow) == true)
			inputLeft ();
		if (Input.GetKey (KeyCode.D) == true || Input.GetKey (KeyCode.RightArrow) == true)
			inputRight ();
		if (Input.GetKey (KeyCode.Z) == true || Input.GetKey (KeyCode.UpArrow) == true)
			inputUp ();
		if (Input.GetKeyDown (KeyCode.F) == true)
			inputUse ();
		if (Input.GetKeyDown (KeyCode.Space) == true)
			inputStart ();
	}
}
