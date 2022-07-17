using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("World Settings")]
    public Vector2 worldSize;
    public float tileSize = 2.0f;
    public GameObject[] worldTiles;
}
