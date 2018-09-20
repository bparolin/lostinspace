using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class RocketState : State {
	[Inject]
	private Player player;
	[Inject]
	private Rocket rocket;
	[Inject]
	private CameraHandler cameraHandler;
	[Inject]
	private GameController gameController;
	[Inject]
	private PlanetState planetState;
	[Inject]
	private EndGameState endGameState;
	[Inject]
	private PlanetGenerator planetGenerator;

	private Planet landablePlanet = null;

	public override void OnEnterState () {
		cameraHandler.SetFollowedObject (rocket.gameObject, false);
		inputHandler.ResetButtons ();
		inputHandler.inputUp = rocket.Accelerate;
		inputHandler.inputLeft = rocket.TurnLeft;
		inputHandler.inputRight = rocket.TurnRight;
	}

	public override void OnFixedUpdate () {
		rocket.Decelerate ();
		Vector3 direction = rocket.GetMovement ();
		rocket.Move (direction.x, direction.y);


		bool nearPlanet = false;
		List<Planet> planets = planetGenerator.GetPlanets ();
		foreach (Planet planet in planets) {
			float planetDistance = planet.GetDistance (rocket);
			if (planetDistance <= 0f) {
				if (rocket.GetVelocity () >= rocket.crashVelocity) {
					CrashRocket ();
				} else {
					rocket.Move (-direction.x, -direction.y);
					rocket.SetVelocity (0);
				}
			} else if (planetDistance <= rocket.landDistance && rocket.GetVelocity () < rocket.crashVelocity) {
				// Land on planet achievable
				landablePlanet = planet;
				nearPlanet = true;
			}
		}

		if (nearPlanet == true)
			inputHandler.inputUse = EnterPlanet;
		else {
			inputHandler.inputUse = inputHandler.DoNothing;
			landablePlanet = null;
		}
	}

	public override void OnUpdate () {
		gameController.UpdateTimer ();
	}

	public override void OnExitState () {

	}

	public void CrashRocket () {
		fsm.EnterState (endGameState);
	}

	public void EnterPlanet () {
		float landAngle = rocket.LandOnPlanet (landablePlanet);
		player.EnterPlanet ();
		player.SetAngle (landAngle);
		player.SetPlanet (landablePlanet.gameObject);
		fsm.EnterState (planetState);
	}
}
