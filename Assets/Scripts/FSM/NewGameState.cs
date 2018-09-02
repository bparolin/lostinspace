using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class NewGameState : State {
	[Inject]
	private PlanetState planetState;
	[Inject]
	private GameController gameController;

	public GameObject newGamePanel;

	public override void OnEnterState () {
		inputHandler.ResetButtons ();
		inputHandler.buttonSpace = this.BeginGame;
		panelManager.EnablePanel (newGamePanel);
	}
	
	public override void OnFixedUpdate () {

	}

	public override void OnUpdate () {

	}

	public override void OnExitState () {

	}

	public void BeginGame () {
		gameController.StartTimer ();
		fsm.EnterState (planetState);
	}
}
