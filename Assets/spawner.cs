using UnityEngine;
using System.Collections.Generic;

public class CombinedSpawner : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs;
    public GameObject foodPrefab;
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int numBacteriaItems = 100;
    public int numFoodItems = 100;
    public float minDistance = 2f;
    public settings Settings;

    private Transform playerTransform;
    private List<GameObject> bacteriaItems = new List<GameObject>();

    void Start()
    {
        Settings = GameObject.FindWithTag("settings").GetComponent<settings>();
        
        switch (Settings.difficulty)
        {
            case 1:
                numBacteriaItems = 20;
                break;
            case 2:
                numBacteriaItems = 30;
                break;
            case 3:
                numBacteriaItems = 40;
                break;
        }
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
            return;
        }

        SpawnBacteria();
        SpawnFood();
    }

    void SpawnBacteria()
    {
        for (int i = 0; i < numBacteriaItems; i++)
        {
            Vector3 bacteriaPosition = GetRandomPositionAroundPlayer();

            while (IsTooCloseToOtherItems(bacteriaPosition))
            {
                bacteriaPosition = GetRandomPositionAroundPlayer();
            }

            GameObject randomBacteriaPrefab = bacteriaPrefabs[Random.Range(0, bacteriaPrefabs.Length)];
            GameObject spawnedBacteria = Instantiate(randomBacteriaPrefab, bacteriaPosition, Quaternion.identity);
            bacteriaItems.Add(spawnedBacteria);
        }
    }

    void SpawnFood()
    {
        for (int i = 0; i < numFoodItems; i++)
        {
            Vector3 foodPosition = GetRandomPositionAroundPlayer();

            while (IsTooCloseToOtherItems(foodPosition) || IsTooCloseToOtherFood(foodPosition))
            {
                foodPosition = GetRandomPositionAroundPlayer();
            }

            Instantiate(foodPrefab, foodPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        float offsetX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
        float offsetY = Random.Range(-mapHeight / 2f, mapHeight / 2f);
        Vector3 itemPosition = playerTransform.position + new Vector3(offsetX, offsetY, 0);
        return itemPosition;
    }

    bool IsTooCloseToOtherItems(Vector3 position)
    {
        foreach (var item in bacteriaItems)
        {
            float distance = Vector3.Distance(position, item.transform.position);
            if (distance < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    bool IsTooCloseToOtherFood(Vector3 position)
    {
        GameObject[] foodItems = GameObject.FindGameObjectsWithTag("Food");

        foreach (var foodItem in foodItems)
        {
            float distance = Vector3.Distance(position, foodItem.transform.position);
            if (distance < minDistance)
            {
                return true;
            }
        }

        return false;
    }
}
