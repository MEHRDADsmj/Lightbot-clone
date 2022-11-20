using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : CommandBase
{
    [SerializeField] private float rotation = 90.0f;
    
    public override void Execute()
    {
        base.Execute();
        PlayerController.instance.Rotate(rotation);
    }
}
