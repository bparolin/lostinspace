﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class EndGameState : State {
	public NewGameState newGameState;
	public GameObject endGamePanel;

	public GameController gameController;

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
		inputHandler.buttonSpace = RestartGame;
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