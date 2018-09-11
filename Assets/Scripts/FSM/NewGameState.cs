using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class NewGameState : State {
	[Inject]
	private PlanetState planetState;
	[Inject]
	private TimeController timeController;
	[Inject]
	private PlanetGenerator planetGenerator;
	[Inject]
	private GameController gameController;
	[Inject]
	private Player player;
	[Inject]
	private Rocket rocket;

	public override void OnEnterState () {
		inputHandler.ResetButtons ();
		gameController.ResetScore ();
		planetGenerator.Generate ();
		player.EnterPlanet ();
		rocket.SetVelocity (0);
		float angle = Random.Range (0f, 2f * Mathf.PI);
		player.SetAngle (angle);
		rocket.SetAngle (angle);
		int firstPlanetID = Random.Range (0, planetGenerator.GetPlanets ().Count - 1);
		GameObject firstPlanet = planetGenerator.GetPlanets ()[firstPlanetID].gameObject;
		player.SetPlanet (firstPlanet);
		rocket.SetPlanet (firstPlanet);
		firstPlanet.GetComponent<Planet> ().AddEntity (rocket);
		timeController.StartTimer ();
		fsm.EnterState (planetState);
	}
}
