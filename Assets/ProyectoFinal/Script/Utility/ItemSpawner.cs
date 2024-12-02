using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Lista de objetos que representar�n las posiciones de generaci�n
    public GameObject[] objetosPosiciones;

    // Prefab que se va a instanciar
    public GameObject itemPrefab;

    // Tiempo entre cada aparici�n (en segundos)
    public float intervaloDeGeneracion = 25f;

    void Start()
    {
        // Inicia la rutina que genera los objetos
        StartCoroutine(GenerarItemCadaIntervalo());
    }

    // Corrutina para generar el objeto cada cierto tiempo
    private IEnumerator GenerarItemCadaIntervalo()
    {
        while (true)
        {
            // Espera por el intervalo de tiempo
            yield return new WaitForSeconds(intervaloDeGeneracion);

            // Selecciona una posici�n aleatoria de los objetos en la escena
            GameObject objetoPosicionAleatoria = objetosPosiciones[Random.Range(0, objetosPosiciones.Length)];

            // Obtiene la posici�n de ese objeto (su transform)
            Vector3 posicionAleatoria = objetoPosicionAleatoria.transform.position;

            // Instancia el prefab en la posici�n aleatoria seleccionada
            Instantiate(itemPrefab, posicionAleatoria, Quaternion.identity);
        }
    }
}