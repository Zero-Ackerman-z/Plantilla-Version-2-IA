using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/Move")]
public class ActionEvadeEnemy : ActionNodeVehicle
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure; 

        SwitchUnit();

        return TaskStatus.Success; 
    }

    void SwitchUnit()
    {
        switch (_UnitGame)
        {
            case UnitGame.Zombie:
                if (_IACharacterVehiculo is IACharacterVehiculoZombie)
                {
                    ((IACharacterVehiculoZombie)_IACharacterVehiculo).MoveToEvadEnemy();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }
    }
}

   

