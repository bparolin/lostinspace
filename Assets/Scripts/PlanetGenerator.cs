using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

public class PlanetGenerator : MonoBehaviour {
    public GameObject planetsHolder;
    public int worldSize = 300;
    public float density = 0.1f;
    public int pickObjectNumber = 10;

    private List<Planet> planets = new List<Planet> ();

    [Inject]
    private Rocket rocket;

    public void ClearWorld () {
        foreach (Planet planet in planets) {
            Destroy (planet.gameObject);
        }
        planets.Clear ();
    }

    public void Generate () {
        ClearWorld ();

        float worldArea = worldSize * worldSize;
        float planetArea = 0;
        float min = (-worldSize/2) + rocket.landDistance;
        float max = (worldSize/2) - rocket.landDistance;

        while ((planetArea / worldArea) < density) {
            int radius = Random.Range (10, 20);
            Vector3 center = new Vector3 (
                Random.Range (min + radius, max - radius),
                Random.Range (min + radius, max - radius),
                0f);

            bool collide = false;
            foreach (Planet planet in planets) {
                float distance = (planet.transform.position - center).magnitude - radius - planet.radius - rocket.landDistance * 2;
                if (distance < 0f) {
                    collide = true;
                }
            }

            if (collide == false) {
                AddPlanet (center, radius);
                planetArea += Mathf.PI * radius * radius;
            }
        }

        GeneratePickObject ();
    }

    private void AddPlanet (Vector3 center, int radius) {
        GameObject instance = Instantiate (Resources.Load ("Planet", typeof (GameObject))) as GameObject;
        instance.transform.position = center;
        instance.transform.SetParent (planetsHolder.transform, false);
        Planet newPlanet = instance.GetComponent<Planet> ();
        newPlanet.radius = radius;
        newPlanet.CreateCircle ();
        planets.Add (newPlanet);
    }

    private void GeneratePickObject () {
        for (int i = 0; i < pickObjectNumber; i++) {
            int planetId = Random.Range (0, planets.Count - 1);
            float angle = Random.Range (0f, 2f * Mathf.PI);
            GameObject instance = Instantiate (Resources.Load ("Pick Object", typeof (GameObject))) as GameObject;
            instance.transform.SetParent (planets[planetId].transform, false);
            PickObject pickObject = instance.GetComponent<PickObject> ();
            pickObject.SetAngle (angle);
            pickObject.SetPlanet (planets[planetId].gameObject);
            planets[planetId].AddEntity (pickObject);
            pickObject.OnUse = pickObject.Pick;
        }
    }

    public List<Planet> GetPlanets () {
        return planets;
    }

	private void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (Vector3.zero, worldSize * Vector3.one);
	}
}