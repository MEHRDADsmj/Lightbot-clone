using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : MonoBehaviour, ICommand
{
    public virtual void Execute()
    {
        
    }

    public virtual void Register()
    {
        GameManager.instance.AddCommand(this);
    }
}
