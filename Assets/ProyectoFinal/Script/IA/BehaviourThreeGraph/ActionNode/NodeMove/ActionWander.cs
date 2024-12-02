using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionWander : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Zombie:
                if(_IACharacterVehiculo is IACharacterVehiculoZombie)
                {
                    ((IACharacterVehiculoZombie)_IACharacterVehiculo).MoveToWander();
                    
                }

                break;
            case UnitGame.Soldier:
                if (_IACharacterVehiculo is IACharacterVehiculoSoldier)
                {
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).MoveToWander();

                }
                break;
            case UnitGame.Civil:
                if (_IACharacterVehiculo is IACharacterVehiculoCivil)
                {
                    ((IACharacterVehiculoCivil)_IACharacterVehiculo).MoveToWander();
                }
                break;
            case UnitGame.Zebra:
                if (_IACharacterVehiculo is IACharacterVehiculoZebra)
                {
                    ((IACharacterVehiculoZebra)_IACharacterVehiculo).MoveToWander();
                }
                break;
            case UnitGame.Lion:
                if (_IACharacterVehiculo is IACharacterVehiculoLion)
                {
                    ((IACharacterVehiculoLion)_IACharacterVehiculo).MoveToWander();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }

}