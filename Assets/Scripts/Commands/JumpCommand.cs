using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : CommandBase
{
    public override void Execute()
    {
        base.Execute();
        PlayerController.instance.MoveForward(true);
    }
}
