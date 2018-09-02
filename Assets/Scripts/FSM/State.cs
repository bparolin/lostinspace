using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public abstract class State : MonoBehaviour {
	[Inject]
	protected InputHandler inputHandler;
	[Inject]
	protected PanelManager panelManager;
	[Inject]
	protected FSM fsm;

	public abstract void OnEnterState ();
	public abstract void OnFixedUpdate ();
	public abstract void OnUpdate ();
	public abstract void OnExitState ();
}
