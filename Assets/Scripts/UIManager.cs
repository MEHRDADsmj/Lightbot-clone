using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> availableCommands;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void InitUI()
    {
        foreach (var command in availableCommands)
        {
            command.SetActive(true);
        }
    }

    public void ResetUI()
    {
        foreach (var command in availableCommands)
        {
            command.SetActive(false);
        }
        InitUI();
    }
}
