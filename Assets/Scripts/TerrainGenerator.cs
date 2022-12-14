using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private LevelData levelConfigData;
    [SerializeField] [Tooltip("Block with the default material")] private GameObject blockTemplate;
    [SerializeField]  private GameObject player;

    private Vector3 meshBounds;

    public void Generate()
    {
        CalculateMeshBounds();
        GenerateTerrain();
    }

    /// <summary>
    /// Fills the property "meshBounds" with the actual width(x), height(y), and depth(z) of the "blockTemplate"
    /// </summary>
    private void CalculateMeshBounds()
    {
        if (!blockTemplate)
        {
            Debug.LogError("TerrainGenerator - blockTemplate is not provided");
            return;
        }
        Renderer renderer = blockTemplate.GetComponentInChildren<Renderer>();
        Vector3 extents = renderer.bounds.extents;
        meshBounds.x = extents.x * 2.0f;
        meshBounds.y = extents.y * 2.0f;
        meshBounds.z = extents.z * 2.0f;
    }
    
    private void GenerateTerrain()
    {
        GameObject block = null;
        Vector3 spawnPos;
        foreach (var tileInfo in levelConfigData.Tiles)
        {
            for (int heightCount = 0; heightCount < tileInfo.Height; ++heightCount)
            {
                spawnPos = new Vector3(tileInfo.Coords.X * meshBounds.x, heightCount * meshBounds.y,
                    tileInfo.Coords.Z * meshBounds.z);
                block = Instantiate(blockTemplate, spawnPos, Quaternion.identity);
                if (tileInfo.IsGoal && heightCount == tileInfo.Height - 1)
                {
                    block.GetComponent<Block>().IsGoal = true;
                    GameManager.instance.AddGoalBlock(block);
                }
            }

            if (tileInfo.Coords.X == 0 && tileInfo.Coords.Z == 0)
            {
                spawnPos = new Vector3(tileInfo.Coords.X * meshBounds.x, (tileInfo.Height) * meshBounds.y,
                    tileInfo.Coords.Z * meshBounds.z);
                Instantiate(player, spawnPos, Quaternion.identity);
            }
        }
    }

    public Vector3 MeshBounds
    {
        get { return meshBounds; }
    }

    /// <summary>
    /// Returns the voxel coordinates of parameter "block"
    /// </summary>
    /// <param name="block"></param>
    /// <returns></returns>
    public Vector3 NormalizeBlockPosition(GameObject block)
    {
        Vector3 pos = block.transform.position;
        return new Vector3((int)(pos.x / meshBounds.x), (int)(pos.y / meshBounds.y), (int)(pos.z / meshBounds.z));
    }
}
