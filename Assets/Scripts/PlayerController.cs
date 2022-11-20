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
        RaycastHit hitResult = RaycastDown(transform.position);
        if (hitResult.transform)
        {
            return hitResult.transform.parent.gameObject;
        }
        else
        {
            return null;
        }
    }

    private RaycastHit RaycastDown(Vector3 pos)
    {
        Ray ray = new Ray(pos, Vector3.down);
        RaycastHit hitResult;
        Physics.Raycast(ray, out hitResult, 100.0f);
        return hitResult;
    }

    public void MoveForward()
    {
        Vector3 newPos = transform.position + (GameManager.instance.Terrain.MeshBounds.x * transform.forward);
        RaycastHit hitResult = RaycastDown(newPos);
        if (hitResult.transform)
        {
            transform.position = newPos;
        }
    }

    public void Rotate(float amount)
    {
        transform.Rotate(Vector3.up, amount);
    }
}
