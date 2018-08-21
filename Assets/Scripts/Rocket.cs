using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Rocket : Entity {
    [SerializeField]
    private float velocity = 0f;
    public float maxVelocity = 100f;
    public float landDistance = 10f;
    public float crashVelocity = 100f;
    
    public void Accelerate () {
        velocity += moveSpeed / 2f;
        if (velocity > maxVelocity)
            velocity = maxVelocity;
    }

    public void Decelerate () {
        velocity -= moveSpeed / 6f;
        if (velocity < 0f) {
            velocity = 0f;
        }
    }

    public Vector3 GetMovement () {
        return this.transform.up * velocity;
    }

    public float GetVelocity () {
        return velocity;
    }

    public void SetVelocity (float newVelocity) {
        velocity = newVelocity;
    }

    public float LandOnPlanet (Planet planet) {
        Vector3 direction = (this.transform.position - planet.transform.position).normalized;
        float angle = Mathf.Acos (direction.x);
        this.SetVelocity (0f);
        this.SetAngle (angle);
        this.SetPlanet (planet.gameObject);
        planet.AddEntity (this);
        return angle;
    }
}
