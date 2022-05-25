using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "GenerateTiles")]
public class GenerateTilesInMap : ScriptableObject
{
    public TileBase[] tiles;

    //ID = tipo do bloco
    public void FillMap(Vector3Int pos, int id, Tilemap targetTilemap)
    {
        targetTilemap.SetTile(pos, tiles[id]);
    }
    public TileBase GetTileBase(int id)
    {
        return tiles[id];
    }
}

