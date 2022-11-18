using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private LevelData levelConfigData;
    [SerializeField] [Tooltip("Block with the default material")] private GameObject blockTemplate;
    [SerializeField] private Material goalMaterial;

    private Vector3 meshBounds;

    private void Start()
    {
        CalculateMeshBounds();
        GenerateTerrain();
    }

    /// <summary>
    /// Fills the property "meshBounds" with the actual width(x), height(y), and depth(z) of the "blockTemplate"
    /// </summary>
    private void CalculateMeshBounds()
    {
        Renderer renderer = blockTemplate.GetComponentInChildren<Renderer>();
        Vector3 extents = renderer.bounds.extents;
        meshBounds.x = extents.x * 2.0f;
        meshBounds.y = extents.y * 2.0f;
        meshBounds.z = extents.z * 2.0f;
    }
    
    private void GenerateTerrain()
    {
        
    }
}
