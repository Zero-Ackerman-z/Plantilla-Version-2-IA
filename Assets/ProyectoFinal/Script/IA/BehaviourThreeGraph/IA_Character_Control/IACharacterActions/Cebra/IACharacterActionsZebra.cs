using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZebra : IACharacterActions
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

            // Verifica si necesita salud
            if (this.health.health < this.health.healthMax)
            {
                int healthToAdd = Mathf.Min(healthItem.health, this.health.healthMax - this.health.health);
                this.health.health += healthToAdd;

                // Destruye solo si se usó parte o toda la salud del objeto
                if (healthToAdd > 0)
                {
                    healthItem.health -= healthToAdd;
                    Destroy(other.gameObject);
                }
            }
        }
    }
}




