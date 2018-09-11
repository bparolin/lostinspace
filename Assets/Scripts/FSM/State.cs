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

	public virtual void OnEnterState () {}
	public virtual void OnFixedUpdate () {}
	public virtual void OnUpdate () {}
	public virtual void OnExitState () {}
}
