using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VoronaiMap : MonoBehaviour
{
    float[,] map;
    public bool generate;
    [Range(0, 1000)]
    public int size;
    [Range(1, 100)]
    public int polygons;
    [Range(0, 1000)]
    public int CircleSize;
    Renderer render;
    Color[] col;
    Texture2D tex;
    Vector2[] randomPositions;
    private void Start()
    {
        render = GetComponent<Renderer>();
        col = new Color[size * size];
        randomPositions = new Vector2[size * size];
        tex = new Texture2D(size, size);
        render.material.mainTexture = tex;
        GenerateVoronoi();
    }
    
    private void LateUpdate()
    {
        if (generate)
        {
            col = new Color[size * size];
            randomPositions = new Vector2[size * size];
            tex = GenerateVoronoi();
            render.material.mainTexture = tex;
        }
    }
    public Texture2D GenerateVoronoi()
    {
        for (int a = 0; a < polygons; a++)
        {
            randomPositions[a] = new Vector2(Random.Range(0, size), Random.Range(0, size));
        }
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float[] distances = new float[polygons];
                for (int p = 0; p < polygons; p++)
                {
                    distances[p] = Vector2.Distance(new Vector2(x, y), randomPositions[p]);
                }
                float sample = Mathf.Min(distances) / CircleSize;
                col[x * size + y] = new Color(sample, sample, sample);
            }
        }
        tex.SetPixels(col);
        tex.Apply();
        return tex;
    }
}
