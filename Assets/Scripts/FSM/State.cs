using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class State : MonoBehaviour {
	public InputHandler inputHandler;
	public PanelManager panelManager;
	protected FSM fsm;

	public void Start () {
		fsm = this.GetComponentInParent<FSM> ();
	}

	public abstract void OnEnterState ();
	public abstract void OnFixedUpdate ();
	public abstract void OnUpdate ();
	public abstract void OnExitState ();
}
