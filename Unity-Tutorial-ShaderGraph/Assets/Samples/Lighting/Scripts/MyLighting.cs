using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MyLighting : MonoBehaviour
{
   
    public List<GameObject> LightObjs = new List<GameObject>();

    public Color LightColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        foreach (var obj in LightObjs)
        {
            var render = obj.GetComponent<Renderer>();
            if (render != null)
            {
                var mat=  render.sharedMaterial;
                mat.SetVector("_LightPos",this.transform.position);
                mat.SetColor("_LightColor",LightColor);
              
               
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var obj in LightObjs)
        {
            Gizmos.DrawLine(this.transform.position, obj.transform.position);
        }
        
            
    }
}
