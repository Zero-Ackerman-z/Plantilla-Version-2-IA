using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZebra : IACharacterActions
{
    public float FrameRate = 0;
    public float Rate = 1;
    public int damageEnemy;
    public LayerMask maskItem;

    private void Start()
    {
        LoadComponent();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    private void OnTriggerEnter(Collider other)
    {
        AttemptPickUp(other);
        if ((maskItem.value & (1 << other.gameObject.layer)) != 0)
        {
            this.health.health += other.gameObject.GetComponent<HealthItem>().health;
            other.gameObject.GetComponent<HealthItem>().health = 0;
            Destroy(other.gameObject);
        }
    }
    public void AttemptPickUp(Collider other)
    {
        if ((maskItem.value & (1 << other.gameObject.layer)) != 0 &&
            other.gameObject.GetComponent<HealthItem>() != null)
        {
            HealthItem healthItem = other.gameObject.GetComponent<HealthItem>();
            this.health.health += healthItem.health;
            healthItem.health = 0;
            Destroy(other.gameObject);
        }
    }
}