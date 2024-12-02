using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("MyAI/Action")]
public class ActionNodePickUp : ActionNodeAction
{
    public LayerMask maskItem;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        if (TryPickUpItem())
        {
            return TaskStatus.Success; 
        }
        return TaskStatus.Failure; 
    }

    private bool TryPickUpItem()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(transform.position, 2f, maskItem);
        foreach (Collider item in itemsInRange)
        {
            ((IACharacterActionsElephant)_IACharacterActions).AttemptPickUp(item);
            ((IACharacterActionsLion)_IACharacterActions).AttemptPickUp(item);
            ((IACharacterActionsZebra)_IACharacterActions).AttemptPickUp(item);

            return true; 
        }
        return false; 
    }
}
