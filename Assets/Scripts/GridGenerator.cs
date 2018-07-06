using System.Collections;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
	public int xSize, ySize;
	private Vector3[] vertices;

	void Awake()
	{
		StartCoroutine (Generate ());
	}

	IEnumerator Generate()
	{
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];

		for (int i=0 ,x = 0; x <= xSize; x++) {
			for (int y = 0; y <= ySize; y++, i++) {
				vertices [i] = new Vector3 (x, y, 0);
				yield return new WaitForSeconds (0.05f);
			}
		}
	}

	void OnDrawGizmos()
	{
		if(vertices == null)
		{
			return;
		}

		Gizmos.color = Color.white;
		for (int i = 0; i < vertices.Length; i++) {
			Gizmos.DrawSphere (vertices [i], 0.1f);
		}

	}

}
