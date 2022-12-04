using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	private Vector2[] uvs;

	public float biasScale = 1.0f;

	void OnDrawGizmos()
	{
		if (vertices == null)
		{
			mesh = GetComponent<MeshFilter>().sharedMesh;
			vertices = mesh.vertices;
			uvs = mesh.uv;

		}
		else
		{
			var cam = SceneView.GetAllSceneCameras()[0];
			var w2cMatrix = cam.worldToCameraMatrix;
			
			for(int i =0; i< vertices.Length;i++)
			{
				var v = vertices[i];
				var uv = uvs[i];
				var bias = new Vector3(0f, -0.1f, 0f)*biasScale;
				var local = (v);
				var world = transform.localToWorldMatrix * new Vector4(local.x, local.y, local.z, 1f);
				var w = new Vector3(world.x, world.y, world.z);
				var c = cam.WorldToScreenPoint(w);
				Vector2 wuv = new Vector2(c.x / cam.pixelWidth, c.y / cam.pixelHeight);
				
				
				
				/*UnityEditor.Handles.Label(w, "c: " + c.ToString());*/
				UnityEditor.Handles.Label(w-bias, "v: " + v.ToString());
				UnityEditor.Handles.Label(w, "uv: " + uv.ToString());
				UnityEditor.Handles.Label(w + bias, "w: " + w.ToString());
				UnityEditor.Handles.Label(w + 2f*bias, "wuv: " + wuv.ToString());
			}
		}
		

		
	}
}
