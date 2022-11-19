using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject GetCurrentBlock()
    {
        Ray ray = new Ray(transform.position + new Vector3(0.0f, 10.0f, 0.0f), Vector3.down);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult, 100.0f))
        {
            return hitResult.transform.parent.gameObject;
        }
        else
        {
            return null;
        }
    }
}
