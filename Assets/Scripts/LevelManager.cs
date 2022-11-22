using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<LevelManager>().Length > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public void LoadNextLevel()
    {
        int levelBuildIndex = SceneManager.GetActiveScene().buildIndex;
        LoadLevelByIndex(levelBuildIndex + 1);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
