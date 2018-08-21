using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NewGameState : State {
	public GameObject newGamePanel;
	public PlanetState planetState;

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
		fsm.EnterState (planetState);
	}
}
