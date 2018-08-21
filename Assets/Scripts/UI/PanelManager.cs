using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PanelManager : MonoBehaviour {
	public GameObject defaultPanel;

	private List<GameObject> panels;

	private void Awake () {
		panels = new List<GameObject> ();
		panels.AddRange (GameObject.FindGameObjectsWithTag ("Panel"));
		EnablePanel (defaultPanel);
	}

	public void EnablePanel (GameObject panel) {
		foreach (GameObject panel_ in panels) {
			panel_.SetActive (panel_ == panel);
		}
	}
}
