using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    private Dictionary<GameObject, bool> goalBlocks = new Dictionary<GameObject, bool>();

    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        BeginTerrainGeneration();
    }

    public void BeginTerrainGeneration()
    {
        if (terrainGenerator)
        {
            terrainGenerator.Generate();
        }
    }

    public void LightBlock(GameObject block)
    {
        if (block && block.CompareTag("block") && goalBlocks.ContainsKey(block))
        {
            bool status;
            goalBlocks.TryGetValue(block, out status);
            goalBlocks[block] = !status;
            block.GetComponent<Block>().ToggleLight();
        }
    }

    public void AddGoalBlock(GameObject block)
    {
        if (block && block.CompareTag("block"))
        {
            goalBlocks.Add(block, false);
        }
    }
}
