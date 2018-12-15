using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MeshModify : MonoBehaviour
{

	private MeshFilter mf;
	public GameObject obj;
	private Vector3[] verts;
	private Vector3[] BufferVerts;
	private bool isSameVertexPos = false;
	private bool FirstLoop = false;

	private int SkipIdx = 500;
	private int SkipIdxCount = 0;
	private List<int> BufferIdx;


	private bool isMove = false;
	
	void Start ()
	{
		mf = obj.GetComponent<MeshFilter>();
		mf.mesh.SetIndices(mf.mesh.GetIndices(0), MeshTopology.Lines, 0);
		mf.mesh.RecalculateBounds();
		
		//頂点の参照を得る
		verts = mf.mesh.vertices;
		BufferIdx = new List<int>();
		//頂点座標のバッファデータ
		BufferVerts = new Vector3[mf.mesh.vertices.Length];
		mf.mesh.vertices.CopyTo(BufferVerts, 0);
	}
	
	void Update ()
	{
	
		if (SkipIdxCount == 0)
			{
				//skip数の決定
				SkipIdx = Random.RandomRange(200, 300);
				FirstLoop = true;

				//頂点をもとに戻す
				for (int i = 0; i < BufferIdx.Count; i++)
				{
					verts[i] = BufferVerts[BufferIdx[i]];
				}
				
				for (int i = 0; i < verts.Length; i ++)
				{
					verts[i] = BufferVerts[i];
				}
				
				
				mf.mesh.vertices = verts;
				mf.mesh.RecalculateBounds();
				BufferIdx.Clear();
			}


			//頂点のアニメーションの計算
			for (int i = 0; i < verts.Length; i += SkipIdx)
			{
				//初回Loopのみインデックスを格納
				if (FirstLoop)
				{
					BufferIdx.Add(i);
				}
				verts[i] += mf.mesh.normals[i] * Mathf.Sin(SkipIdxCount * 10.0f * Mathf.PI / 180.0f) * 10.0f;
			}

			FirstLoop = false;

			mf.mesh.vertices = verts;
			mf.mesh.RecalculateBounds();

			SkipIdxCount++;
			SkipIdxCount %= 30;		
	}
}
