using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

public class GameController : MonoBehaviour {
	public GameObject firstPlanet;
	[Inject]
	private PlayerController playerController;
	[Inject]
	private Rocket rocket;
	[Inject]
	private FSM fsm;
	[Inject]
	private NewGameState newGameState;
	[Inject]
	private EndGameState endGameState;

	public Text timerText;
	public Text scoreText;

	private float startTime;

	private int score = 0;
	public int pickObjectNumber = 1;

	private void Awake () {
		UpdateScore ();

		playerController.SetPlanet (firstPlanet);
		rocket.SetPlanet (firstPlanet);
		firstPlanet.GetComponent<Planet> ().AddEntity (rocket);
		fsm.EnterState (newGameState);
	}

	private void Update () {
		fsm.OnUpdate ();
	}

	private void FixedUpdate () {
		fsm.OnFixedUpdate ();
	}

	public void UpdateTimer () {
		float time = Time.time - startTime;
		float seconds = Mathf.Floor (time);
		float hundredth = Mathf.Floor((time - seconds) * 100f);
		timerText.text = seconds + "\"" + hundredth;
	}

	public void UpdateScore () {
		scoreText.text = score + "/" + pickObjectNumber;
	}

	public void StartTimer () {
		startTime = Time.time;
	}

	public void IncrementScore () {
		score++;
		UpdateScore ();
		if (score == pickObjectNumber) // Victory
			fsm.EnterState (endGameState);
	}

	public bool AllPicked () {
		return score == pickObjectNumber;
	}
}
