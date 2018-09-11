using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class TitleState : State {
	public GameObject titlePanel;

	[Inject]
	private NewGameState newGameState;

	public override void OnEnterState () {
		inputHandler.ResetButtons ();
		inputHandler.buttonSpace = this.BeginGame;
		panelManager.EnablePanel (titlePanel);
	}

	public void BeginGame () {
		fsm.EnterState (newGameState);
	}
}
