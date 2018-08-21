using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : Entity {
	public float useDistance = 3f;

	public void EnterRocket () {
		spriteRenderer.enabled = false;
	}

	public void ExitRocket () {
		spriteRenderer.enabled = true;
	}

	private void OnDrawGizmos() {
		// Draw a sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, useDistance);
	}
}
