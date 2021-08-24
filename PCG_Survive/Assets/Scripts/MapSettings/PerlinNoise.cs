using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public static PerlinNoise Instance { get; private set; }

    public int width;
    public int height;
    public float scale;
    public float hMultiplier;
    public float[,] mapInFloat;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
    }
    public void InitMaps()
    {
        mapInFloat = new float[width, height];
        GenerateTexture();

    }
    void GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
                mapInFloat[x, y] = texture.GetPixel(x, y).r;
            }
        }
    }
    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x/width * scale;
        float yCoord = (float)y/width * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
    private void OnDrawGizmos()
    {
        if (mapInFloat != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float heightStrenght = Mathf.PerlinNoise(x * .3f, y * .3f) * hMultiplier;

                    float sample = mapInFloat[x, y];
                    //Gizmos.color = new Color(sample,sample,sample);

                    //Gizmos.color = (map[x, y] == 1) ? GenerateTexture().GetPixel(x,y) : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, height);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
