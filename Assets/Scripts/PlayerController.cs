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

    public bool GetForwardBlock(out GameObject block)
    {
        block = null;
        Vector3 newPos = transform.position + (GameManager.instance.Terrain.MeshBounds.x * transform.forward);
        RaycastHit hitResult = RaycastDown(newPos + new Vector3(0.0f, 20.0f, 0.0f));
        if (hitResult.transform)
        {
            block = hitResult.transform.parent.gameObject;
            return true;
        }

        return false;
    }

    public void MoveForward(bool jumpMode = false)
    {
        GameObject forwardBlock;
        if (GetForwardBlock(out forwardBlock))
        {
            bool haveDifferentHeight = GameManager.instance.HaveDifferentHeight(GetCurrentBlock(), forwardBlock);
            if (jumpMode && haveDifferentHeight)
            {
                transform.position = forwardBlock.transform.position + new Vector3(0.0f, GameManager.instance.Terrain.MeshBounds.y, 0.0f);
            }
            else if (!jumpMode && !haveDifferentHeight)
            {
                transform.position = forwardBlock.transform.position + new Vector3(0.0f, GameManager.instance.Terrain.MeshBounds.y, 0.0f);
            }
        }
    }

    public void Rotate(float amount)
    {
        transform.Rotate(Vector3.up, amount);
    }
}
