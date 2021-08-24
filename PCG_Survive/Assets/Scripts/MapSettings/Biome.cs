using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu (menuName = "Biome")]
public class Biome : ScriptableObject
{

    [Range(0,1)]
    public float sandSpread;

    //ground types
    public GenerateTilesInMap[] generateTiles;



    [Header("Bioma Propriedades")]
    [Range(0, 1)]
    public float intensity;
 
    public void GenerateTileMap(Tilemap tilemap, int width, int height, float[,] map)
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
                    ///

                    if (map[x, y] < intensity) 
                    { 
                        if(map[x,y] < sandSpread)
                            generateTiles[0].FillMap(p, GetTile(p, tilemap), tilemap);
                        else
                            generateTiles[1].FillMap(p, GetTile(p, tilemap), tilemap);

                    }
                    else
                        ClearTiles(p,tilemap);
                        //OrganizeTilemap();
                }
            }
        }
        OrganizeTilemap(tilemap,width,height,map);
    }
    public void ClearTiles(Vector3Int pos, Tilemap targetTilemap)
    {
        if (targetTilemap.GetTile(pos) != null)
            targetTilemap.SetTile(pos, null);
    }
    public void OrganizeTilemap(Tilemap tilemap, int width, int height, float[,] map)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int p = new Vector3Int((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);//new Vector3Int(x, y, 0);//((int)(-width / 2 + x + .5f), (int)(-height / 2 + y + .5f), 0);
                if (tilemap.GetTile(p) != null)
                    if(map[x,y] < sandSpread)
                        tilemap.SetTile(p, generateTiles[0].GetTileBase(GetTile(p, tilemap)));
                    else
                        tilemap.SetTile(p, generateTiles[1].GetTileBase(GetTile(p, tilemap)));
            }
        }
    }
    public int GetTile(Vector3Int pos, Tilemap tilemap)
    {
        int mask = GetInThisPos(pos + new Vector3Int(0, 1, 0), tilemap) ? 1 : 0;
        mask += GetInThisPos(pos + new Vector3Int(1, 0, 0), tilemap) ? 2 : 0;
        mask += GetInThisPos(pos + new Vector3Int(0, -1, 0), tilemap) ? 4 : 0;
        mask += GetInThisPos(pos + new Vector3Int(-1, 0, 0), tilemap) ? 8 : 0;

        return Soma(mask);
    }
    public int Soma(int soma)
    {
        switch (soma)
        {
            case 10: return 0;
            case 14: return 1;
            case 12: return 2;

            case 11: return 4;
            case 15: return 5;
            case 13: return 6;

            case 3: return 8;
            case 7: return 9;
            case 5: return 10;

            case 8: return 3;
            case 9: return 7;
            case 1: return 11;

            case 2: return 12;
            case 6: return 13;
            case 4: return 14;

            case 0: return 15;

        }
        return -1;
    }
    public bool GetInThisPos(Vector3Int pos, Tilemap tilemap)
    {
        return (tilemap.GetTile(pos));
    }
}
