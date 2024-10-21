using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoCivil : IACharacterVehiculo
{
    Vector3 normales = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
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
    public void MoveToItem()
    {
        if (AIEye is IAEyeCivil)
        {
            if (((IAEyeCivil)AIEye).ViewItem != null)
            {
                MoveToPosition(((IAEyeCivil)AIEye).ViewItem.transform.position);
            }
        }
    }
    public void LookToItem()
    {
        if (AIEye is IAEyeCivil)
        {
            if (((IAEyeCivil)AIEye).ViewItem != null)
            {
                LookPosition(((IAEyeCivil)AIEye).ViewItem.transform.position);
            }
        }

    }
    public void MoveToStrategy()
    {

        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = Vector3.zero;
        normales = ColliderWall();
        if (normales != Vector3.zero)
            dir = normales;
        else
        {
            dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        }
        Vector3 newPosition = transform.position + dir * 2;
        MoveToPosition(newPosition);


    }
    Vector3 ColliderWall()
    {
        normales = Vector3.zero;
        Ray[] arrayRay = new Ray[3];
        arrayRay[0] = new Ray(health.AimOffset.position, health.AimOffset.right);
        arrayRay[1] = new Ray(health.AimOffset.position, -health.AimOffset.forward);
        arrayRay[2] = new Ray(health.AimOffset.position, -health.AimOffset.right);
        for (int i = 0; i < 2; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(arrayRay[i], out hit, 3, AIEye.mainDataView.occlusionlayers))
            {
                normales += hit.normal;
            }
        }
        return normales;
    }

    private void OnDrawGizmos()
    {
        if (health == null) return;

        Ray[] arrayRay = new Ray[3];
        arrayRay[0] = new Ray(health.AimOffset.position, health.AimOffset.right);
        arrayRay[1] = new Ray(health.AimOffset.position, -health.AimOffset.forward);
        arrayRay[2] = new Ray(health.AimOffset.position, -health.AimOffset.right);
        for (int i = 0; i < arrayRay.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(arrayRay[i], out hit, 3, AIEye.mainDataView.occlusionlayers))
            {
                Gizmos.color = Color.red;

            }
            else
            {
                Gizmos.color = Color.blue;
            }

            Gizmos.DrawLine(arrayRay[i].origin, arrayRay[i].origin + arrayRay[i].direction * 3f);
            Gizmos.DrawSphere(arrayRay[i].origin + arrayRay[i].direction * 3f, 0.7f);
        }


        Gizmos.color = Color.yellow;
        if (normales != Vector3.zero)
        {
            Gizmos.DrawLine(health.AimOffset.position, health.AimOffset.position + normales * 2f);
            Gizmos.DrawSphere(health.AimOffset.position + normales * 2f, 0.5f);
        }


        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, positionWander);
        Gizmos.DrawSphere(positionWander, 0.5f);

    }
}