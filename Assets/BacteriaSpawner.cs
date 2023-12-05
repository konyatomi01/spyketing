using UnityEngine;
using System.Collections.Generic;

public class BacteriaSpawner : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs; 
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int numBacteriaItems = 100;
    public float minDistance = 2f;

    private Transform playerTransform;
    private List<GameObject> bacteriaItems = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
            return;
        }

        SpawnBacteria();
    }

    void SpawnBacteria()
    {
        for (int i = 0; i < numBacteriaItems; i++)
        {
            Vector3 bacteriaPosition = GetRandomPositionAroundPlayer();

            while (IsTooCloseToOtherBacteria(bacteriaPosition))
            {
                bacteriaPosition = GetRandomPositionAroundPlayer();
            }

            
            GameObject randomBacteriaPrefab = bacteriaPrefabs[Random.Range(0, bacteriaPrefabs.Length)];

            
            GameObject spawnedBacteria = Instantiate(randomBacteriaPrefab, bacteriaPosition, Quaternion.identity);
            
            
            bacteriaItems.Add(spawnedBacteria);
        }
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        float offsetX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
        float offsetY = Random.Range(-mapHeight / 2f, mapHeight / 2f);

        Vector3 bacteriaPosition = playerTransform.position + new Vector3(offsetX, offsetY, 0);

        return bacteriaPosition;
    }

    bool IsTooCloseToOtherBacteria(Vector3 position)
    {
        foreach (var bacteriaItem in bacteriaItems)
        {
            float distance = Vector3.Distance(position, bacteriaItem.transform.position);
            if (distance < minDistance)
            {
                return true;
            }
        }

        return false;
    }
}
