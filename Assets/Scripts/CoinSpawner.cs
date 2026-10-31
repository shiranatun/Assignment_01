using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs;

    public float minX = -20f;
    public float maxX = 20f;
    public float minY = -20f;
    public float maxY = 20f;

    private void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, coinPrefabs.Length);

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(coinPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}