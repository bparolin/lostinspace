using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class RocketState : State {
	[Inject]
	private PlayerController player;
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
		cameraHandler.SetFollowedObject (rocket.gameObject);
		inputHandler.ResetButtons ();
		inputHandler.buttonZ = rocket.Accelerate;
		inputHandler.buttonQ = rocket.TurnLeft;
		inputHandler.buttonD = rocket.TurnRight;
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
			inputHandler.buttonF = EnterPlanet;
		else {
			inputHandler.buttonF = inputHandler.DoNothing;
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
		player.ExitRocket ();
		player.SetAngle (landAngle);
		player.SetPlanet (landablePlanet.gameObject);
		fsm.EnterState (planetState);
	}
}
