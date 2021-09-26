using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMeshTest : MonoBehaviour
{
    public float width = 1;
    public float height = 1;


    // Start is called before the first frame update
    public void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        
        Mesh mesh = new Mesh();

        //noktaları belirt ve mesh nesnesine ekle
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0,0,0),
            new Vector3(width,0,0),
            new Vector3(0,height,0),
            new Vector3(width,height,0)
        };
        mesh.vertices = vertices;

        //üçgenleri belirt ve mesh nesnesine ekle
        int[] tris = new int[6]
        {
            //left-down triangle
            0,2,1,
            //right-up triangle
            2,3,1
        };
        mesh.triangles = tris;
        //buraya kadar ekranda bir kare gözükür fakat ışığa ve textura
        //duyarlı değil

        //ışıktan etkilenebilmesi için "normal" vektörleri belirtilmeli
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        //texturedan etkilenebilmesi için uv vectorleri gerekir
        Vector2[] uv = new Vector2[4]
        {
              new Vector2(0, 0),
              new Vector2(1, 0),
              new Vector2(0, 1),
              new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    }
}

    
