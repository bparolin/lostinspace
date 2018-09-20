using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

public class EndGameState : State {
	[Inject]
	private NewGameState newGameState;
	[Inject]
	private GameController gameController;

	public GameObject endGamePanel;
	

	public override void OnEnterState () {
		inputHandler.ResetButtons ();
		
		Text endGameText = endGamePanel.GetComponentInChildren<Text> ();
		Image endGameBG = endGamePanel.GetComponent<Image> ();
		if (gameController.AllPicked ()) {
			endGameText.text = "You Win !!";
			Color color = new Color ();
			color.r = 0f;
			color.g = 255f;
			color.b = 0f;
			color.a = 120f;
			endGameBG.color = color;
		} else {
			endGameText.text = "You lose !!";
			Color color = Color.red;
			color.a = 120;
			endGameBG.color = color;
		}

		panelManager.EnablePanel (endGamePanel);
		inputHandler.inputStart = RestartGame;
	}

	public override void OnFixedUpdate () {

	}

	public override void OnUpdate () {

	}

	public override void OnExitState () {

	}

	public void RestartGame () {
		fsm.EnterState (newGameState);
	}
}
