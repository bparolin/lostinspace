using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TimeController {
	public float timer;

	public void StartTimer () {
		timer = Time.time;
	}
}