using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

public class GameController : MonoBehaviour {
	[Inject]
	private FSM fsm;
	[Inject]
	private TitleState titleState;
	[Inject]
	private EndGameState endGameState;
	[Inject]
	private PlanetGenerator planetGenerator;
	[Inject]
	private TimeController timeController;

	public Text timerText;
	public Text scoreText;

	private int score = 0;

	private void Awake () {
		fsm.EnterState (titleState);
	}

	private void Update () {
		fsm.OnUpdate ();
	}

	private void FixedUpdate () {
		fsm.OnFixedUpdate ();
	}

	public void UpdateTimer () {
		float time = Time.time - timeController.timer;
		int minutes = Mathf.FloorToInt (time / 60f);
		int seconds = Mathf.FloorToInt (time % 60f);
		int hundredth = Mathf.FloorToInt (Mathf.Repeat (time, 1) * 100f);
		if (minutes > 0)
			timerText.text = minutes.ToString ("D2") + "'" + seconds.ToString ("D2") + "\"" + hundredth.ToString ("D2");
		else
			timerText.text = seconds.ToString ("D2") + "\"" + hundredth.ToString ("D2");
	}

	public void UpdateScore () {
		scoreText.text = score + "/" + planetGenerator.pickObjectNumber;
	}

	public void IncrementScore () {
		score++;
		UpdateScore ();
		if (score == planetGenerator.pickObjectNumber) // Victory
			fsm.EnterState (endGameState);
	}

	public void ResetScore () {
		score = 0;
		UpdateScore ();
	}

	public bool AllPicked () {
		return score == planetGenerator.pickObjectNumber;
	}
}
