using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class PickObject : Entity {
	[Inject]
	private GameController gameController;

	private void Awake () {
		this.OnUse = Pick;
	}

	public void Pick () {
		gameController.IncrementScore ();
		this.planetOn.GetComponent<Planet> ().RemoveEntity (this);
		Destroy (this.gameObject);
	}
}
