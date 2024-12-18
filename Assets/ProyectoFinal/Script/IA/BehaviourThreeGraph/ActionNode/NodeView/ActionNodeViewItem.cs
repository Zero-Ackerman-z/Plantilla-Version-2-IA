using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionNodeViewItem : ActionNodeView
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.AIEye is IAEyeCivil)
        {
            if (((IAEyeCivil)_IACharacterVehiculo.AIEye).ViewItems == null)
                return TaskStatus.Failure;
        }
        else if (_IACharacterVehiculo.AIEye is IAEyeZebra)
        {
            if (((IAEyeZebra)_IACharacterVehiculo.AIEye).ViewItems == null)
                return TaskStatus.Failure;
        }
        else if (_IACharacterVehiculo.AIEye is IAEyeElephantAttack)
        {
            if (((IAEyeElephantAttack)_IACharacterVehiculo.AIEye).ViewItems == null)
                return TaskStatus.Failure;
        }
        else if (_IACharacterVehiculo.AIEye is IAEyeLiontAttack)
        {
            if (((IAEyeLiontAttack)_IACharacterVehiculo.AIEye).ViewItems == null)
                return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }
}
