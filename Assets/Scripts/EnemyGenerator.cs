using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float generationRate = 0.5f;
    [SerializeField] private Vector2 forceRange;
    private Camera mainCamera;
    private float timer;
    void Start()
    {
        mainCamera = Camera.main;
    }    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GenerateEnemy();
            timer += generationRate;
        }
    }
    private void GenerateEnemy()
    {
        int side = Random.Range(0, 4);
        Vector2 generationPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;
        switch (side)
        {
            case 0:
                generationPoint.x = 0;
                generationPoint.y = Random.value;
                direction = new Vector2(1f , Random.Range(-1f , 1f));
                break;

            case 1:
                generationPoint.x = 1;
                generationPoint.y = Random.value;
                direction = new Vector2(-1f , Random.Range(-1f , 1f));
                break;
            case 2:
                generationPoint.x = Random.value;
                generationPoint.y = 0;
                direction = new Vector2(Random.Range(-1f , 1f), 1f);
                break;
            case 3:
                generationPoint.x =  Random.value;
                generationPoint.y = 0;
                direction = new Vector2(Random.Range(-1f , 1f), -1f);
                break;

        }
        Vector3 worldGenerationPoint = mainCamera.ViewportToWorldPoint(generationPoint);
        worldGenerationPoint.z = 0;
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemyInstance = Instantiate(
            selectedEnemy, worldGenerationPoint, 
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        Rigidbody rb = enemyInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);

    }
}
