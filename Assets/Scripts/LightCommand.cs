using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCommand : ICommand
{
    public void Execute()
    {
        GameManager.instance.LightBlock(PlayerController.instance.GetCurrentBlock());
    }
}
