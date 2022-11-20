using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCommand : CommandBase
{
    public override void Execute()
    {
        base.Execute();
        GameManager.instance.LightBlock(PlayerController.instance.GetCurrentBlock());
    }
}
