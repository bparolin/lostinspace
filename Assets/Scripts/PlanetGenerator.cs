using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
    private List<Planet> planets = new List<Planet> ();

    private static PlanetGenerator INSTANCE;

    public GameObject planetsHolder;

    public static PlanetGenerator instance () {
        return INSTANCE;
    }

    private void Awake () {
        planets.AddRange (planetsHolder.GetComponentsInChildren<Planet> ());
        if (INSTANCE == null) {
            INSTANCE = this;
        } else {
            Debug.Log ("Error: Two instances of PlanetGenerator");
            Destroy (this);
        }
    }

    public List<Planet> GetPlanets () {
        return planets;
    }
}