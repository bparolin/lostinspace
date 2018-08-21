using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlanetState : State {
	public PlayerController player;
	public Rocket rocket;
	public CameraHandler cameraHandler;
	public GameController gameController;
	public GameObject gamePanel;
	public RocketState rocketState;

	private Planet planet;

	public override void OnEnterState () {
		planet = player.GetPlanet ().GetComponent<Planet> ();
		rocket.OnUse = this.EnterRocket;
		cameraHandler.SetFollowedObject (player.gameObject);
		inputHandler.ResetButtons ();
		inputHandler.buttonD = player.MoveCW;
		inputHandler.buttonQ = player.MoveCCW;
		panelManager.EnablePanel (gamePanel);
	}
	public override void OnFixedUpdate () {}
	public override void OnUpdate () {
		gameController.UpdateTimer ();
		
		List<Entity> entities = planet.GetEntities ();
		float minDistance = 100000f;
		Entity nearestEntity = null;

		foreach (Entity e in entities) {
			float entityDistance = player.GetSqrDistance (e);
			if (entityDistance < minDistance) {
				minDistance = entityDistance;
				nearestEntity = e;
			}
		}

		if (nearestEntity != null && minDistance <= (player.useDistance * player.useDistance)) {
			inputHandler.buttonF = nearestEntity.OnUse;
		} else {
			inputHandler.buttonF = inputHandler.DoNothing;
		}
	}
	public override void OnExitState () {

	}

	public void EnterRocket () {
		player.EnterRocket ();
		rocket.SetPlanet (null);
		fsm.EnterState (rocketState);
	}
}
