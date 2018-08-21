using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class Circle : MonoBehaviour {
	public float radius = 0.5f;
	public int verticesNumber = 10;

	private List<Vector3> vertices_;
	private List<int> triangles_;
	private List<Vector2> uvs_;
	private Mesh mesh_;

	// Use this for initialization
	private void Awake () {
		mesh_ = this.GetComponent<MeshFilter> ().mesh;
		CreateCircle ();
	}

	private void CreateCircle () {
		vertices_ = new List<Vector3> ();
		uvs_ = new List<Vector2> ();

		for (int i = 0; i < verticesNumber; i++) {
			float tmp = 2f * Mathf.PI * i / verticesNumber;
			vertices_.Add (new Vector3 (radius * Mathf.Cos (tmp), radius * Mathf.Sin (tmp), 0));
			uvs_.Add (new Vector2 (0, 0));
		}

		vertices_.Add (new Vector3 (0, 0, 0));
		uvs_.Add (new Vector2 (0, 0));

		triangles_ = new List<int> ();

		for (int i = 0; i < verticesNumber - 1; i++) {
			triangles_.Add (verticesNumber);
			triangles_.Add (i + 1);
			triangles_.Add (i);
		}

		triangles_.Add (verticesNumber);
		triangles_.Add (0);
		triangles_.Add (verticesNumber - 1);

		mesh_.Clear ();
		mesh_.SetVertices (vertices_);
		mesh_.SetTriangles (triangles_, 0);
		mesh_.SetUVs (0, uvs_);

		mesh_.RecalculateBounds ();
		mesh_.RecalculateNormals ();
	}

	private void OnDrawGizmos() {
        // Draw a sphere at the transform's position
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
