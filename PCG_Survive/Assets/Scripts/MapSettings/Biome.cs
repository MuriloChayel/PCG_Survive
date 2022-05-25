using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu (menuName = "Biome")]
public class Biome : ScriptableObject
{

    //public float sandSpread;

    //ground types
    /// <summary>
    /// 0 - > grass
    /// 1 - > sand
    /// 2 - > water
    /// </summary
    /// >
    private float intensity, forcaGrass, forcaSand, forcaWater, bordaWater;
    private bool randomize;

    public void Setup(float intensity, float forcaGrass, float forcaSand, float forcaWater, float bordaWater, bool randomize)
    {
        this.intensity = intensity;
        this.forcaGrass = forcaGrass;
        this.forcaSand = forcaSand;
        this.forcaWater = forcaWater; 
        this.bordaWater = bordaWater;
        this.randomize = randomize;
    }
    public GenerateTilesInMap[] tileDatas;

    public void GenerateTileMap(Tilemap[] tilemaps, int width, int height, float[,] map)
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3Int p = new Vector3Int((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);//((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);
                    ///
                    ///0 - grass
                    ///1 - sand
                    ///2 - water
                    ///
                    //AREIA
                    if (map[x, y] < intensity)
                    {
                        
                        if (map[x, y] < forcaGrass)
                            tileDatas[0].FillMap(p, GetTile(p, tilemaps[0]), tilemaps[0]);
                        else
                            ClearTiles(p, tilemaps, 0);
                        //GRASS
                        if (map[x, y] < forcaSand)
                            tileDatas[1].FillMap(p, GetTile(p, tilemaps[1]), tilemaps[1]);
                        else
                            ClearTiles(p, tilemaps, 1);
                        if (map[x, y] > forcaWater)
                        {
                            tileDatas[2].FillMap(p, GetTile(p, tilemaps[2]), tilemaps[2]);
                        }
                        else
                            ClearTiles(p, tilemaps, 2);
                        if (map[x, y] > bordaWater)
                        {
                            tileDatas[3].FillMap(p, GetTile(p, tilemaps[3]), tilemaps[3]);
                        }
                        else
                            ClearTiles(p, tilemaps, 3);
                    }
                    else
                    {
                        for(int a = 0; a < tilemaps.Length; a++)
                        {
                            ClearTiles(p, tilemaps, a);
                        }
                    }

                    #region
                    /* if (map[x, y] < intensity)
                     {
                         //GRASS TILEMAP
                         if (map[x, y] < forcaGrass)
                         {
                             tileDatas[0].FillMap(p, GetTile(p, tilemaps[0]), tilemaps[0]);
                             ClearTiles(p, tilemaps, 2);
                         }
                         else
                         {
                             ClearTiles(p, tilemaps, 0);

                         }//SAND TILEMAP\
                         if (map[x, y] < forcaSand)
                         {
                             tileDatas[1].FillMap(p, GetTile(p, tilemaps[1]), tilemaps[1]);
                             ClearTiles(p, tilemaps, 2);
                             //ClearWaterTiles(p, tilemaps);
                         }
                         else
                         {
                             ClearTiles(p, tilemaps, 1);
                         }//WATER BORDA

                     }
                     else
                     {
                         for(int  a = 0; a < tilemaps.Length; a++)
                         {
                             ClearTiles(p, tilemaps, a);
                         }
                         if (map[x, y] < forcaWater)
                         {
                             tileDatas[2].FillMap(p, GetTile(p, tilemaps[2]), tilemaps[2]);
                         }
                         else
                         {
                             ClearTiles(p, tilemaps, 3);
                         }
                         if(map[x,y] < bordaWater)
                         {
                             tileDatas[3].FillMap(p, GetTile(p, tilemaps[3]), tilemaps[3]);
                         }
                         else
                         {
                             ClearTiles(p, tilemaps, 3);
                         }

                     }*/
                    #endregion
                }
            }
            OrganizeTilemap(tilemaps, width, height, map);
        }
    }
    public void ClearTiles(Vector3Int pos, Tilemap[] tilemaps, int id)
    {
        if (tilemaps[id].GetTile(pos) != null)
            tilemaps[id].SetTile(pos, null); 
    }
    public void OrganizeTilemap(Tilemap[] tilemaps, int width, int height, float[,] map)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int p = new Vector3Int((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);//new Vector3Int(x, y, 0);//((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);
                for (int a = 0; a < tilemaps.Length; a++)
                {
                    if (tilemaps[a].GetTile(p) != null)
                        tilemaps[a].SetTile(p, tileDatas[a].GetTileBase(GetTile(p, tilemaps[a])));
                }
            }
        }
    }
    public int GetTile(Vector3Int pos, Tilemap tilemap)
    {
        
        int mask = GetInThisPos(pos + new Vector3Int(0, 1, 0), tilemap) ? 1 : 0; // cima
        mask += GetInThisPos(pos + new Vector3Int(1, 0, 0), tilemap) ? 2 : 0; // direita
        mask += GetInThisPos(pos + new Vector3Int(0, -1, 0), tilemap) ? 4 : 0; // baixo
        mask += GetInThisPos(pos + new Vector3Int(-1, 0, 0), tilemap) ? 8 : 0; //esquerda
        return Soma(mask);

    }
    public int Soma(int soma)
    {
        switch (soma)
        {
            case 6: return 0;

            case 14: return 1;
            case 12: return 2;
            case 4: return 3;

            case 13: return 6;
            case 15: return RetRandom(5,15, randomize);
            case 7: return 4;

            case 5: return 7;
            case 3: return 8;
            case 11: return 9;

            case 9: return 10;
            case 1: return 11;
            case 2: return 12;

            case 10: return 13;
            case 8: return 14;
            case 0: return 15;

        }
        return -1;
    }
    public int RetRandom(int num1, int num2, bool randomize)
    {
        if (randomize)
        {
            int a = Random.Range(0, 2);
            return a == 0 ? num1 : num2;
        }
        else return num1;
    }
    public bool GetInThisPos(Vector3Int pos, Tilemap tilemap)
    {
        return (tilemap.GetTile(pos));
    }
}
