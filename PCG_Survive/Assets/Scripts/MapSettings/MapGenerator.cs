using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    public Biome biome;

    /// <summary>
    /// 0 -> sand
    /// 1 -> grass
    /// 2 -> water
    /// </summary>
    public Tilemap[] tilemaps;
    public bool editMode;
    public bool randomize;

    float[,] map;

    [Header("Procedural Settings")]
    public int width;
    public int height;
    public float scale;
    public Renderer render;
    [Header("Bioma Propriedades")]
    [Range(0, 1)]
    public float intensity;
    [Range(0, 1)]
    public float forcaGrass, forcaSand, forcaWater, borda;

    private void Start()
    {
        if (editMode)
        {
            biome.Setup(intensity, forcaGrass, forcaSand, forcaWater, borda, randomize);
            GenerateTexture(tilemaps, width, height, map);
        }
    }
    private void Update()
    {
        if (editMode)
        {
            biome.Setup(intensity, forcaGrass, forcaSand, forcaWater, borda, randomize);
            render.material.mainTexture = GenerateTexture(tilemaps, width, height, map);
        }
    }
    //  PERLIN NOISE
    public Texture2D GenerateTexture(Tilemap[] tilemap, int width, int height, float[,] map) //PERLIN NOISE
    {
        map = new float[width, height];

        Texture2D texture = new Texture2D(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
                map[x, y] = texture.GetPixel(x, y).g;
            }
        }
        biome.GenerateTileMap(tilemaps, width, height, map);
        texture.Apply();
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
