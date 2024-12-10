using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval = 10f;
    public Vector2 xRange = new Vector2(40f, 350f);
    public Vector2 zRange = new Vector2(-350f, 160f);

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(xRange.x, xRange.y);
        float randomZ = Random.Range(zRange.x, zRange.y);
        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
