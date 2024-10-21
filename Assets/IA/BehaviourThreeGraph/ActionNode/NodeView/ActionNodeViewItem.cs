using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/View")]
public class ActionNodeViewItem : ActionNodeView
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.IAEyeCivil.ViewItems != null)
            return TaskStatus.Success; 

        return TaskStatus.Failure; 
    }
}
