using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDiffuse : MonoBehaviour
{
    // Funciones de membresía para distancia y velocidad de rotación
    public FuzzyFunction cerca = new FuzzyFunction();
    public FuzzyFunction medio = new FuzzyFunction();
    public FuzzyFunction lejos = new FuzzyFunction();

    // Funciones de membresía para velocidad
    public FuzzyFunction rapido = new FuzzyFunction();
    public FuzzyFunction normal = new FuzzyFunction();
    public FuzzyFunction lento = new FuzzyFunction();

    public float speedRotation;  
    public float speedFactor;    
    public float distanceFactor; 
    public float distanceSpeed;  

    public float DistanceRay;  
    public Transform pointSensor;
    public LayerMask mask;

    public RaycastHit hit;
    public bool Collider { get; set; }

    public bool IsGizmos;
    public Color ColorGizmos;

    void Update()
    {
        if (Physics.Raycast(pointSensor.position, pointSensor.forward, out hit, DistanceRay, mask))
        {
            Collider = true;
            float front = hit.distance;  

            CalculateDistance(front);
            CalculateSpeed(front);     
            CalculateAngle(front);     
        }
        else
        {
            speedRotation = 0;
            Collider = false;
        }
    }

    // Calcula el ángulo de rotación basado en los factores de distancia y velocidad
    void CalculateAngle(float front)
    {
        float distanceSum = cerca.F_y + medio.F_y + lejos.F_y;
        if (distanceSum == 0)
        {
            Debug.LogWarning("División por cero en las funciones de distancia.");
            distanceFactor = 0;
        }
        else
        {
            distanceFactor = (cerca.Evaluate(front) * cerca.Singleton +
                              medio.Evaluate(front) * medio.Singleton +
                              lejos.Evaluate(front) * lejos.Singleton) / distanceSum;
        }

        float speedSum = rapido.F_y + normal.F_y + lento.F_y;
        if (speedSum == 0)
        {
            Debug.LogWarning("División por cero en las funciones de velocidad.");
            speedFactor = 0;
        }
        else
        {
            speedFactor = (rapido.F_y * rapido.Singleton +
                           normal.F_y * normal.Singleton +
                           lento.F_y * lento.Singleton) / speedSum;
        }

        speedRotation = distanceFactor * speedFactor;
    }

    public void CalculateDistance(float front)
    {
        cerca.Evaluate(front);
        medio.Evaluate(front);
        lejos.Evaluate(front);
    }

    public void CalculateSpeed(float front)
    {
        distanceSpeed = front / Time.deltaTime; 

        rapido.Evaluate(distanceSpeed);
        normal.Evaluate(distanceSpeed);
        lento.Evaluate(distanceSpeed);
    }

    private void OnDrawGizmos()
    {
        if (!IsGizmos) return;

        Gizmos.color = ColorGizmos;
        Vector3 pos = pointSensor.position + pointSensor.forward * DistanceRay;
        Gizmos.DrawSphere(pos, 0.2f);
        Gizmos.DrawLine(pointSensor.position, pos);

        if (Collider)
        {
            Vector3 posNormal = hit.point + hit.normal * 2;
            Gizmos.DrawSphere(posNormal, 0.2f);
            Gizmos.DrawLine(hit.point, posNormal);
        }
    }
}

