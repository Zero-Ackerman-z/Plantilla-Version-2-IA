using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    // Rango de movimiento en Y
    public float rangoDeMovimiento = 1f;

    // Velocidad de movimiento suave
    public float velocidadDeMovimiento = 1f;

    // Velocidad de rotaci�n en Y
    public float velocidadDeRotacion = 100f;

    // Variable interna para saber si estamos subiendo o bajando
    private bool subiendo = true;

    // La posici�n de destino en Y
    private float objetivoY;

    void Start()
    {
        // Inicializa el objetivo Y en la posici�n actual + rangoDeMovimiento
        objetivoY = transform.position.y + rangoDeMovimiento;
    }

    void Update()
    {
        // Movimiento suave en el eje Y
        if (subiendo)
        {
            // Desacelera a medida que se acerca al objetivo
            transform.position = new Vector3(transform.position.x,
                Mathf.Lerp(transform.position.y, objetivoY, Time.deltaTime * velocidadDeMovimiento),
                transform.position.z);

            // Si el objeto est� cerca del objetivo, comienza a bajar
            if (Mathf.Abs(transform.position.y - objetivoY) < 0.01f)
            {
                subiendo = false;
                objetivoY = transform.position.y - rangoDeMovimiento;  // Cambia la direcci�n
            }
        }
        else
        {
            // Desacelera a medida que se acerca al objetivo
            transform.position = new Vector3(transform.position.x,
                Mathf.Lerp(transform.position.y, objetivoY, Time.deltaTime * velocidadDeMovimiento),
                transform.position.z);

            // Si el objeto est� cerca de la posici�n inicial, comienza a subir
            if (Mathf.Abs(transform.position.y - objetivoY) < 0.01f)
            {
                subiendo = true;
                objetivoY = transform.position.y + rangoDeMovimiento;  // Cambia la direcci�n
            }
        }

        // Rotaci�n r�pida en el eje Y
        transform.Rotate(0, velocidadDeRotacion * Time.deltaTime, 0);
    }
}