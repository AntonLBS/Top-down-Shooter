using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject ollePrefab;
    [SerializeField] GameObject upgradePrefab;
    [SerializeField] GameObject ryukPrefab;
    [SerializeField] float minSpawnTime = 1.0f;
    [SerializeField] float maxSpawnTime = 3.0f;
    [SerializeField] float minOlleSpawnTime = 1.0f;
    [SerializeField] float maxOlleSpawnTime = 3.0f;
    [SerializeField] float minUpgradeSpawnTime = 10.0f;
    [SerializeField] float maxUpgradeSpawnTime = 15.0f;




    [SerializeField] float spawnDistance = 10f;
    Vector2 screenBounds;
    Vector2 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnEnemy();
        spawnOlle();
        spawnUpgrade();
        spawnRyuk();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(screenBounds.x + spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBounds.x - spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;

        }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Invoke("spawnEnemy", spawnTime);
    }

    void spawnOlle()
    {
        float spawnTime = Random.Range(minOlleSpawnTime, maxOlleSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(screenBounds.x + spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBounds.x - spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;

        }
        Instantiate(ollePrefab, spawnPos, transform.rotation);
        Invoke("spawnOlle", spawnTime);
    }

    void spawnUpgrade()
    {
        float spawnTime = Random.Range(minUpgradeSpawnTime, maxUpgradeSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);  
        Instantiate(upgradePrefab, spawnPos, transform.rotation);
        Invoke("spawnUpgrade", spawnTime);
    }

    void spawnRyuk()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(screenBounds.x + spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBounds.x - spawnDistance, Random.Range(-screenBounds.y, screenBounds.y));
                break;

        }
        Instantiate(ryukPrefab, spawnPos, transform.rotation);
        Invoke("spawnRyuk", spawnTime);
    }
}
