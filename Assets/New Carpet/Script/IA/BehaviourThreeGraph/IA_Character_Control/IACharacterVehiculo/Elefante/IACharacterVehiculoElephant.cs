using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoElephant : IACharacterVehiculo
{
    void Start()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }

    public override void MoveToEnemy()
    {
        base.MoveToEnemy();
    }
    public override void MoveToAllied()
    {
        base.MoveToAllied();
    }
    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy();
    }
<<<<<<< Updated upstream
=======
    //public void MoveToItem()
    //{
    //    if (AIEye is IAEyeElephantAttack)
    //    {
    //        if (((IAEyeElephantAttack)AIEye).ViewItems != null)
    //        {
    //            MoveToPosition(((IAEyeElephantAttack)AIEye).ViewItems.transform.position);
    //        }
    //    }
    //}
    //public void LookToItem()
    //{
    //    if (AIEye is IAEyeElephantAttack)
    //    {
    //        if (((IAEyeElephantAttack)AIEye).ViewItems != null)
    //        {
    //            LookPosition(((IAEyeElephantAttack)AIEye).ViewItems.transform.position);
    //        }
    //    }
    //}
>>>>>>> Stashed changes
}
