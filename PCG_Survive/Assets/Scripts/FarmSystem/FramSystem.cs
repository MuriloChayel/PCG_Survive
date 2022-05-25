using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FramSystem : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 mouseIntilePos;

    public Tilemap farmTilemap;
    public TileBase farmTile;
    public TileBase plantedTile;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            Dig(mousePos);
    }
    public void Dig(Vector2 mouseWorldPos)
    {
        Vector3Int mouseInCellTilemap = farmTilemap.WorldToCell(mouseWorldPos);
        //SE NAO TIVER CAVADO BURACOS
        if (GetCell(mouseInCellTilemap))
        {
            farmTilemap.SetTile(mouseInCellTilemap, farmTile);
            print("cavando");
        }
        //SE TIVER CAVADO UM BURACO
        else
            Plant(mouseInCellTilemap);
    }
    public bool GetCell(Vector3Int pos)
    {
        if (farmTilemap.GetTile(pos) == null)
            return true;
        return false;
    }
    public void Plant(Vector3Int pos)
    {
        if (!GetCell(pos)) //SE O BLOCO ESTIVER PREENCHIDO
        {
            Debug.Log("plantando");
            farmTilemap.SetTile(pos, plantedTile);
        }
        print("out");
    }
}
