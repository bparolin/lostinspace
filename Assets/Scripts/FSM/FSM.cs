using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FSM : MonoBehaviour {
	private State currentState;
	
	public void EnterState (State newState) {
		if (currentState != null)
			currentState.OnExitState ();
		
		currentState = newState;
		currentState.OnEnterState ();
	}

	// Update is called once per frame
	public void OnUpdate () {
		currentState.OnUpdate ();
	}

	// Update is called once per fixed frame
	public void OnFixedUpdate () {
		currentState.OnFixedUpdate ();
	}
}
