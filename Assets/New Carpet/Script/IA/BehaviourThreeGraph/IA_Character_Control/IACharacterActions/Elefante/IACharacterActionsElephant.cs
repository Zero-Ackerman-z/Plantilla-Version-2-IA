using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsElephant : IACharacterActions
{
    public float FrameRate = 0;
    public float Rate = 1;
    public int damageEnemy;
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {

        if (FrameRate > Rate)
        {
            FrameRate = 0;
            IAEyeElephantAttack _IAEyeElephantAttack = ((IAEyeElephantAttack)AIEye);

            if (_IAEyeElephantAttack != null &&
                _IAEyeElephantAttack.ViewEnemy != null)
            {

                _IAEyeElephantAttack.ViewEnemy.Damage(damageEnemy, health);
            }

        }
        FrameRate += Time.deltaTime;


    }
}
