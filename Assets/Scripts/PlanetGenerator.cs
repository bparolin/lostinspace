using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
    private List<Planet> planets = new List<Planet> ();

    public GameObject planetsHolder;

    public void Start () {
        planets.AddRange (planetsHolder.GetComponentsInChildren<Planet> ());
    }

    public List<Planet> GetPlanets () {
        return planets;
    }
}