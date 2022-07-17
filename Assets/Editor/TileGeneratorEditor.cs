using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileGenerator))]
public class TileGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("GenerateBoard")) {
            GenerateBoard();
        }
        if (GUILayout.Button("ClearBoard")) {
            ClearBoard((TileGenerator)target);
        }
    }

    void GenerateBoard() {
        TileGenerator tg = (TileGenerator)target;

        ClearBoard(tg);

        for (int i = 0; i < tg.worldSize.x; i++)
        {
            for (int j = 0; j < tg.worldSize.y; j++)
            {
                int rdmIndex = Random.Range(0, tg.worldTiles.Length);
                GameObject newTile = PrefabUtility.InstantiatePrefab(tg.worldTiles[rdmIndex]) as GameObject;
                newTile.transform.SetParent(tg.transform);
                newTile.transform.position = new Vector3(i * tg.tileSize, 0, j * tg.tileSize);
                newTile.name = $"Tile_{i*tg.tileSize}_{j*tg.tileSize}";
            }
        }
    }

    void ClearBoard(TileGenerator tg) {
        for (int i = tg.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(tg.transform.GetChild(i).gameObject);
        }
    }


}

