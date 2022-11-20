using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Renderer blockRenderer = new Renderer();
    private bool isGoal;
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material lightOffMat;
    [SerializeField] private Material lightOnMat;

    private void Awake()
    {
        blockRenderer = GetComponentInChildren<Renderer>();
        blockRenderer.material = defaultMat;
    }

    public void SetGoalMat()
    {
        if (isGoal)
        {
            blockRenderer.material = lightOffMat;
        }
    }

    public bool IsGoal
    {
        get { return isGoal; }
        set
        {
            isGoal = value;
            SetGoalMat();
        }
    }

    public void ToggleLight()
    {
        if (!isGoal)
        {
            return;
        }

        if (blockRenderer.sharedMaterial == lightOffMat)
        {
            blockRenderer.sharedMaterial = lightOnMat;
        }
        else if(blockRenderer.sharedMaterial == lightOnMat)
        {
            blockRenderer.sharedMaterial = lightOffMat;
        }
    }
}
