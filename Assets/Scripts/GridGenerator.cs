using System.Collections;
using UnityEngine;

//[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour {
	public int xSize, ySize;
	private Vector3[] vertices;
	private Vector2[] uv;
	private Mesh mesh;
	int[] triangles;

	void Awake()
	{
//		StartCoroutine (Generate ());
		Generate ();
	}
//	void OnValidate()
//	{
//		Generate ();
//	}
	void Generate()
	{
//		mesh = new Mesh ();
		GetComponent<MeshFilter> ().mesh = mesh = new Mesh ();
		mesh.name = "Procedural Grid";

		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		uv = new Vector2[vertices.Length];
		mesh.Clear ();


		for (int i=0 , y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++, i++) {
				vertices [i] = new Vector3 (x, y, 0);
				uv [i] = new Vector2 ((float)x / xSize, (float)y / ySize);

			}
		}

		mesh.vertices = vertices;
		mesh.uv = uv;

		triangles = new int[xSize * 6 * ySize];
//		Mesh Generation in bottom row
		// ti - triangle index, vi- vertex index
		for (int ti = 0, vi =0, y = 0; y < ySize; y++, vi++) {
			for (int x = 0; x < xSize; x++, ti+=6, vi++) {
				triangles [ti] = vi;
				triangles [ti + 1] = triangles [ti + 4] = xSize + 1+ vi;
				triangles [ti + 2] = triangles [ti + 3] =1 + vi;
				triangles [ti + 5] = xSize + 2 + vi;

			}
		}
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();


	}

//	void OnDrawGizmos()
//	{
//		if(vertices == null)
//		{
//			return;
//		}
//
//		Gizmos.color = Color.white;
//		for (int i = 0; i < vertices.Length; i++) {
//			Gizmos.DrawSphere (vertices [i], 0.1f);
//		}
//
//	}

}
