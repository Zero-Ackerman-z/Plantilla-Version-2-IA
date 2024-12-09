using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoZebra : IACharacterVehiculo
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
    public void MoveToItem()
    {
        base.MoveToItem();
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
    public virtual void MoveToEvadEnemy()
    {
        if (AIEye.ViewEnemy == null) return;

        // Obtener la distancia al enemigo y calcular el valor difuso basado en esa distancia
        float distanceToEnemy = Vector3.Distance(transform.position, AIEye.ViewEnemy.transform.position);
        float fuzzyValue = _CalculateDiffuse.CalculateFuzzy(distanceToEnemy);

        // Definir la dirección básica de evasión
        Vector3 dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;

        // Determinar si debemos hacer un zig-zag o un movimiento más agresivo
        float zigZagFactor = Mathf.Sin(Time.time * fuzzyValue);  // Factor difuso aplicado para zig-zag

        // Modificar la dirección con el factor de zig-zag
        dir = new Vector3(dir.x + zigZagFactor, 0, dir.z).normalized;

        // Aplicar la lógica difusa para determinar la velocidad de evasión
        float evasionSpeed = Mathf.Lerp(3f, 6f, fuzzyValue); // La velocidad de evasión aumenta si el enemigo está cerca

        // Calculamos la nueva posición con el valor ajustado de evasión
        Vector3 newPosition = transform.position + dir * evasionSpeed;

        // Mover hacia la nueva posición calculada
        MoveToPosition(newPosition);
    }



    Vector3 ColliderWall()
    {
        normales = Vector3.zero;
        Ray[] arrayRay = new Ray[3];
        arrayRay[0] = new Ray(health.AimOffset.position, health.AimOffset.right);
        arrayRay[1] = new Ray(health.AimOffset.position, -health.AimOffset.forward);
        arrayRay[2] = new Ray(health.AimOffset.position, -health.AimOffset.right);

        for (int i = 0; i < arrayRay.Length; i++) // Corregido
        {
            RaycastHit hit;
            if (Physics.Raycast(arrayRay[i], out hit, 3, AIEye.mainDataView.occlusionlayers))
            {
                normales += hit.normal;
            }
        }
        return normales.normalized; // Normalización para evitar acumulación incorrecta
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
