using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class PlanetState : State {
	[Inject]
	private Player player;
	[Inject]
	private Rocket rocket;
	[Inject]
	private CameraHandler cameraHandler;
	[Inject]
	private GameController gameController;
	[Inject]
	private RocketState rocketState;

	private Planet planet;
	public GameObject gamePanel;

	public override void OnEnterState () {
		planet = player.GetPlanet ().GetComponent<Planet> ();
		rocket.OnUse = this.EnterRocket;
		cameraHandler.SetFollowedObject (player.gameObject, true);
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
