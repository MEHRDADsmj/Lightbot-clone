using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData", fileName = "Level ")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<TileInfo> tiles;
}

[Serializable]
struct TileInfo
{
    [SerializeField] [Tooltip("Voxel coordinates of the tile stack. Player always starts at (0, 0)")]
    private TileCoord coords;
    [SerializeField] [Range(1, 16)] [Tooltip("A value of 1 means base height")] private int height;
    [SerializeField] private bool isGoal;
}

[Serializable]
struct TileCoord
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }
}