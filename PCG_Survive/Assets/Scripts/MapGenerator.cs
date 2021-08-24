using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    public Biome biome;
    public Tilemap tilemap;
    float[,] map;

    [Header("Procedural Settings")]
    public int width;
    public int height;
    public float scale;

    private void Start()
    {
       GenerateTexture(tilemap, width, height, map);
    }
    private void Update()
    {
        ///noisePreview.material.mainTexture = 
        //if(Input.GetMouseButtonDown(0))
            GenerateTexture(tilemap, width, height, map);
    }
    //  PERLIN NOISE
    public Texture2D GenerateTexture(Tilemap tilemap, int width, int height, float[,] map)
    {
        map = new float[width, height];

        Texture2D texture = new Texture2D(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
                map[x, y] = texture.GetPixel(x, y).r;
            }
        }
        biome.GenerateTileMap(tilemap, width, height, map);

        return texture;
    }
    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / width * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
