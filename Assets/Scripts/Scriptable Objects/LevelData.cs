using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData", fileName = "Level ")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<TileInfo> tiles;

    public List<TileInfo> Tiles
    {
        get { return tiles; }
    }
}

[Serializable]
public struct TileInfo
{
    [SerializeField] [Tooltip("Voxel coordinates of the tile stack. Player always starts at (0, 0)")]
    private TileCoord coords;
    [SerializeField] [Range(1, 16)] [Tooltip("A value of 1 means base height")] private int height;
    [SerializeField] private bool isGoal;

    public TileCoord Coords
    {
        get { return coords;  }
    }

    public int Height
    {
        get { return height; }
    }

    public bool IsGoal
    {
        get { return isGoal; }
    }
}

[Serializable]
public struct TileCoord
{
    [SerializeField] private int x;
    [SerializeField] private int z;

    public int X
    {
        get { return x; }
    }

    public int Z
    {
        get { return z; }
    }
}