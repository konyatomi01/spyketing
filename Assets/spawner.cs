using UnityEngine;
using System.Collections.Generic;

public class CombinedSpawner : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs;
    public GameObject foodPrefab;
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int maxBacteriaItems = 100;
    public int maxFoodItems = 100;
    public float minDistance = 5f;
    public float minDistance_food = 2f;
    public settings Settings;
    public GameObject enemiesObject;

    private Transform playerTransform;
    private List<GameObject> bacteriaItems = new List<GameObject>();
    private List<GameObject> foodItems = new List<GameObject>();

    void Start()
    {
        InitializeSpawner();
    }

    void InitializeSpawner()
    {
        Settings = GameObject.FindWithTag("settings")?.GetComponent<settings>();

        if (Settings == null)
        {
            Debug.LogError("Settings not found. Make sure there is an object with the 'settings' tag.");
            return;
        }

        switch (Settings.difficulty)
        {
            case 1:
                maxBacteriaItems = 20;
                break;
            case 2:
                maxBacteriaItems = 30;
                break;
            case 3:
                maxBacteriaItems = 40;
                break;
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (playerTransform == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        CheckAndSpawnItems();
    }

    void CheckAndSpawnItems()
    {
        SpawnBacteria();
        SpawnFood();
    }

    void SpawnBacteria()
    {
        while (bacteriaItems.Count < maxBacteriaItems)
        {
            Vector3 bacteriaPosition = GetRandomPositionAroundPlayer();

            while (IsTooCloseToOtherItems(bacteriaPosition, bacteriaItems))
            {
                bacteriaPosition = GetRandomPositionAroundPlayer();
            }

            GameObject randomBacteriaPrefab = bacteriaPrefabs[Random.Range(0, bacteriaPrefabs.Length)];
            GameObject spawnedBacteria = Instantiate(randomBacteriaPrefab, bacteriaPosition, Quaternion.identity);
            spawnedBacteria.transform.parent = enemiesObject.transform.parent;
            bacteriaItems.Add(spawnedBacteria);

            // Break out of the loop after successfully spawning an item
            break;
        }
    }

    void SpawnFood()
    {
        while (foodItems.Count < maxFoodItems)
        {
            Vector3 foodPosition = GetRandomPositionAroundPlayer();

            while (IsTooCloseToOtherItems(foodPosition, bacteriaItems) || IsTooCloseToOtherFood(foodPosition))
            {
                foodPosition = GetRandomPositionAroundPlayer();
            }

            GameObject spawnedFood = Instantiate(foodPrefab, foodPosition, Quaternion.identity);
            spawnedFood.transform.parent = enemiesObject.transform;
            foodItems.Add(spawnedFood);

            // Break out of the loop after successfully spawning an item
            break;
        }
    }


    Vector3 GetRandomPositionAroundPlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player transform is null. Make sure the player has the 'Player' tag.");
            return Vector3.zero;
        }

        float offsetX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
        float offsetY = Random.Range(-mapHeight / 2f, mapHeight / 2f);
        Vector3 itemPosition = playerTransform.position + new Vector3(offsetX, offsetY, 0);
        return itemPosition;
    }

    bool IsTooCloseToOtherItems(Vector3 position, List<GameObject> items)
    {
        foreach (var item in items)
        {
            if (item == null) continue; // Skip null references
            float distance = Vector3.Distance(position, item.transform.position);

            if (distance < minDistance)
            {
                if (item.transform.localScale != transform.localScale)
                {
                    if (item.GetComponent<Collider>().bounds.Intersects(transform.GetComponent<Collider>().bounds))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    bool IsTooCloseToOtherFood(Vector3 position)
    {
        foreach (var foodItem in foodItems)
        {
            if (foodItem == null) continue; // Skip null references
            float distance = Vector3.Distance(position, foodItem.transform.position);
            if (distance < minDistance_food)
            {
                return true;
            }
        }

        return false;
    }
}
