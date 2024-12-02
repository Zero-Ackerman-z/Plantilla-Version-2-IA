using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/Move")]
public class ActionFollowItem : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
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
            case UnitGame.Civil:
                if (_IACharacterVehiculo is IACharacterVehiculoCivil)
                {
                    // Moverse al ítem
                    ((IACharacterVehiculoCivil)_IACharacterVehiculo).MoveToItem();
                    // Mirar hacia el ítem
                    ((IACharacterVehiculoCivil)_IACharacterVehiculo).LookToItem();
                }
                break;
            case UnitGame.Elephant:
                if (_IACharacterVehiculo is IACharacterVehiculoElephant)
                {
                    ((IACharacterVehiculoElephant)_IACharacterVehiculo).MoveToItem();
                    ((IACharacterVehiculoElephant)_IACharacterVehiculo).LookToItem();
                }
                break;
            case UnitGame.Lion:
                if (_IACharacterVehiculo is IACharacterVehiculoLion)
                {
                    ((IACharacterVehiculoLion)_IACharacterVehiculo).MoveToItem();
                    ((IACharacterVehiculoLion)_IACharacterVehiculo).LookToItem();
                }
                break;
            case UnitGame.Zebra:
                if (_IACharacterVehiculo is IACharacterVehiculoZebra)
                {
                    ((IACharacterVehiculoZebra)_IACharacterVehiculo).MoveToItem();
                    ((IACharacterVehiculoZebra)_IACharacterVehiculo).LookToItem();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }
    }
}
