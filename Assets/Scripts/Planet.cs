using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Planet : Circle {
	private List<Entity> entities = new List<Entity> ();

	public void Start () {
		entities.AddRange (this.GetComponentsInChildren<Entity> ());
		for (int i = 0; i < entities.Count; i++) {
			entities[i].SetPlanet (this.gameObject);
			entities[i].SetAngle (i * 2f);
		}
	}

	public List<Entity> GetEntities () {
		return entities;
	}

	public void AddEntity (Entity e) {
		entities.Add (e);
	}

	public void RemoveEntity (Entity e) {
		entities.Remove (e);
	}

	public float GetDistance (Entity e) {
		float distance = (this.transform.position - e.transform.position).magnitude;
		distance -= this.radius;
		return distance;
	}

	private void OnDrawGizmos() {
        // Draw a sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius + 10f);
    }
}
