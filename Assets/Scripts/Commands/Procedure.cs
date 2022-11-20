using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedure : CommandBase
{
    private List<ICommand> commands = new List<ICommand>();

    public override void Execute()
    {
        base.Execute();
        StartCoroutine(StartExecution());
    }

    private IEnumerator StartExecution()
    {
        for (int index = 0; index < commands.Count; ++index)
        {
            commands[index].Execute();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void AddCommand(ICommand newCommand)
    {
        commands.Add(newCommand);
    }

    public void RemoveCommand(int index)
    {
        commands.RemoveAt(index);
    }
}
