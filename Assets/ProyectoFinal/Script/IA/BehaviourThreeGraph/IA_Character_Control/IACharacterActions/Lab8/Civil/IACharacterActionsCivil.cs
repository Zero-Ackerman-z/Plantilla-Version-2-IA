using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsCivil : IACharacterActions
{
    public LayerMask maskItem;

    private void Awake()
    {
        this.LoadComponent();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    private void OnTriggerEnter(Collider other)
    {
        AttemptPickUp(other);
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

