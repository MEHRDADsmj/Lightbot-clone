using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    private List<GameObject> goalBlocks = new List<GameObject>();

    public static GameManager instance;
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        BeginTerrainGeneration();
    }

    public void BeginTerrainGeneration()
    {
        if (terrainGenerator)
        {
            terrainGenerator.Generate();
        }
    }

    public void AddGoalBlock(ref GameObject block)
    {
        if (block && block.CompareTag("block"))
        {
            goalBlocks.Add(block);
        }
    }
}
