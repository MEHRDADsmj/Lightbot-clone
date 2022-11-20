using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    private Dictionary<GameObject, bool> goalBlocks = new Dictionary<GameObject, bool>();
    [SerializeField] private Procedure main;
    [SerializeField] private Procedure proc1;

    private Procedure currentProc;

    public static GameManager instance;

    public Procedure CurrentProcedure
    {
        get { return currentProc; }
        set { currentProc = value; }
    }
    
    public TerrainGenerator Terrain
    {
        get { return terrainGenerator; }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        ResetGame();
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

    public void StartExecution()
    {
        main.Execute();
    }

    public void AddCommand(ICommand command)
    {
        CurrentProcedure.AddCommand(command);
    }

    private void ResetGame()
    {
        CleanupLevel();
        BeginTerrainGeneration();
        main.Empty();
        proc1.Empty();
        goalBlocks.Clear();
        CurrentProcedure = main;
    }

    private void CleanupLevel()
    {
        List<Block> blocks = FindObjectsOfType<Block>().ToList();
        for (int index = 0; index < blocks.Count; ++index)
        {
            Destroy(blocks[index].gameObject);
        }

        List<PlayerController> players = FindObjectsOfType<PlayerController>().ToList();
        for (int index = 0; index < players.Count; ++index)
        {
            Destroy(players[index].gameObject);
        }
    }
}
