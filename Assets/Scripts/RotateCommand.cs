using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : ICommand
{
    private float rotation = 90.0f;
    
    public void Execute()
    {
        PlayerController.instance.Rotate(rotation);
    }
}
