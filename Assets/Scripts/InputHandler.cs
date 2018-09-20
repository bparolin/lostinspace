using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InputHandler : MonoBehaviour {
	[HideInInspector]
	public Action inputUp;
	[HideInInspector]
	public Action inputLeft;
	[HideInInspector]
	public Action inputRight;
	[HideInInspector]
	public Action inputUse;
	[HideInInspector]
	public Action inputStart;

	public void ResetButtons () {
		inputLeft = DoNothing;
		inputRight = DoNothing;
		inputUp = DoNothing;
		inputUse = DoNothing;
		inputStart = DoNothing;
	}

	public void DoNothing () {

	}
}
