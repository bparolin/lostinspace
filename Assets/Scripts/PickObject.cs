using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : Entity {
	public GameController gameController;

	private void Start () {
		this.OnUse = Pick;
	}

	public void Pick () {
		gameController.IncrementScore ();
		this.planetOn.GetComponent<Planet> ().RemoveEntity (this);
		Destroy (this.gameObject);
	}
}
