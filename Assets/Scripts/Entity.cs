using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class Entity : MonoBehaviour {
	protected SpriteRenderer spriteRenderer;

	protected GameObject planetOn;
	protected float moveSpeed = 10f;
	private float phi = 0f;
	private float planetScale = 0f;
	private float spriteSize = 0f;

	public Action OnUse = null;

	// Use this for initialization
	private void Awake () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		spriteSize = spriteRenderer.bounds.extents.y;
	}
	
	private void FixedUpdate () {
		if (planetOn != null) {
			this.transform.position = new Vector3 (planetScale * Mathf.Cos (phi) + planetOn.transform.position.x, planetScale * Mathf.Sin(phi) + planetOn.transform.position.y, 0f);
			//this.transform.up = this.transform.position - planetOn.transform.position;
			this.transform.rotation = Quaternion.Euler (0f, 0f, Mathf.Rad2Deg * phi - 90f);
		}
	}

	public void SetPlanet (GameObject planet) {
		if (planet != null) {
			planetOn = planet;

			spriteRenderer = this.GetComponent<SpriteRenderer> ();
			if (spriteSize == 0f)
				spriteSize = spriteRenderer.bounds.extents.y;

			planetScale = planetOn.GetComponent<Planet> ().radius + spriteSize;
		} else {
			planetOn = null;
			planetScale = 0f;
		}
	}

	public GameObject GetPlanet () {
		return planetOn;
	}

	public void SetAngle (float angle) {
		phi = angle;
	}

	public float GetSqrDistance (Entity e) {
		return (this.transform.position - e.transform.position).sqrMagnitude;
	}

	public void MoveCW () {
		spriteRenderer.flipX = true;
		phi -= moveSpeed / planetScale * Time.fixedDeltaTime;
	}

	public void MoveCCW () {
		spriteRenderer.flipX = false;
		phi += moveSpeed / planetScale * Time.fixedDeltaTime;
	}

	public void Move (float x, float y) {
		this.transform.Translate (x * Time.fixedDeltaTime, y * Time.fixedDeltaTime, 0f, Space.World);
	}

	public void TurnLeft () {
		this.transform.Rotate (0, 0, moveSpeed * 6f * Time.deltaTime);
	}

	public void TurnRight () {
		this.transform.Rotate (0, 0, -moveSpeed * 6f * Time.deltaTime);
	}
}
