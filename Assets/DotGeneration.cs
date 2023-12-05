using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int numFoodItems = 100;
    public float minDistance = 2f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
            return;
        }

        SpawnFood();
    }

    void SpawnFood()
    {
        for (int i = 0; i < numFoodItems; i++)
        {

            Vector3 foodPosition = GetRandomPositionAroundPlayer();


            while (IsTooCloseToOtherFood(foodPosition))
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


        Vector3 foodPosition = playerTransform.position + new Vector3(offsetX, offsetY, 0);

        return foodPosition;
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
