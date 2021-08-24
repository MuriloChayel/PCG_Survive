using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "GenerateTiles")]
public class GenerateTilesInMap : ScriptableObject
{
    public TileBase[] tileType;

    [Range(0,.5f)]
    public float sandAmount;
    // 
    public void FillMap(Vector3Int pos, int id, Tilemap targetTilemap)
    {
        targetTilemap.SetTile(pos, tileType[0]);
    }
    public TileBase GetTileBase(int id)
    {
        return tileType[id];
    }
}

