using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	private MeshFilter mf;
	private Vector3[] Verts;
	private Vector3[] InitVerts;
	private Vector3[] Normals;
	private Vector3[] Vels;
	private Vector3[] ReturnVels;

	private bool isAttract = false;
	void Start ()
	{
		mf = this.GetComponent<MeshFilter>();
		mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.Points, 0);
		//mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.Triangles, 0);
		
		
		InitVerts = new Vector3[mf.mesh.vertices.Length];
		Verts = new Vector3[mf.mesh.vertices.Length];
		mf.mesh.vertices.CopyTo(InitVerts, 0);
		mf.mesh.vertices.CopyTo(Verts, 0);
		Normals = new Vector3[mf.mesh.vertices.Length];
		mf .mesh.normals.CopyTo(Normals, 0);
		Vels = new Vector3[mf.mesh.vertices.Length];
		ReturnVels = new Vector3[mf.mesh.vertices.Length];

		//init verls
		for (int i = 0; i < Vels.Length; i++)
		{
			Vels[i] = new Vector3(Random.RandomRange(-2, 2), Random.RandomRange(-2, 2), Random.RandomRange(-2, 2));
		}
	}
	
	
	void Update () {

		if (Input.GetKeyDown("a"))
		{
			isAttract = !isAttract;
		}
		
		if (!isAttract)
		{
			for (int i = 0; i < Verts.Length; i++)
			{
				Verts[i] += Vels[i];
			}
			mf.mesh.vertices = Verts;
			mf.mesh.RecalculateBounds();
		}
		else
		{
			for (int i = 0; i < Verts.Length; i++)
			{
				if ((InitVerts[i] - Verts[i]).magnitude < 1.5f)
				{
					ReturnVels[i] = Vector3.zero;
					mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.Lines, 0);
				}
				else
				{
					ReturnVels[i] = InitVerts[i] - Verts[i];
					ReturnVels[i] = ReturnVels[i].normalized * 2.5f;
					mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.Points, 0);
				}
				Verts[i] += ReturnVels[i];
			}
			mf.mesh.vertices = Verts;
			mf.mesh.RecalculateBounds();
		}
	}
}
