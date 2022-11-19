using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Renderer renderer = new Renderer();
    private bool isGoal;
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material lightOffMat;
    [SerializeField] private Material lightOnMat;

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();
        renderer.material = defaultMat;
    }

    public void SetGoalMat()
    {
        if (isGoal)
        {
            renderer.material = lightOffMat;
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

        if (renderer.sharedMaterial == lightOffMat)
        {
            renderer.sharedMaterial = lightOnMat;
        }
        else if(renderer.sharedMaterial == lightOnMat)
        {
            renderer.sharedMaterial = lightOffMat;
        }
    }
}
