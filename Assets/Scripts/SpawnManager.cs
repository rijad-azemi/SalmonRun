using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public Transform start1, start2;

    [SerializeField]
    public GameObject[] prefabs;

    private Vector3 spawnPosition;

    [SerializeField]
    public GameObject sideLand;

    [SerializeField]
    public GameObject terrain;

    [SerializeField]
    public Transform playerPosition;

    [SerializeField]
    public GameObject Water;

    [SerializeField]
    public float timer;

    private float landSpawnPosition = -150.0f;

    private void Start()
    {
        spawnPosition = start1.transform.position;

        SpawnSideLand();
        SpawnSideLand();
        SpawnSideLand();

        timer = 0.1f;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {

            timer = 2f;
            for (int i = 0; i < 7; i++)
            {
                SpawnObstacle();
            }
            SpawnSideLand();

        }
    }
    public void SpawnObstacle()
    {
        spawnPosition += new Vector3(0, 0, 40.0f);

        int rand = Random.Range(1, 3);

        for(int i = 0; i < rand; i++)
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(Random.Range(start1.transform.position.x, start2.transform.position.x), start1.transform.position.y,spawnPosition.z), Quaternion.identity);
    }

    public void SpawnSideLand()
    {
        Instantiate(sideLand, new Vector3(0, 35, landSpawnPosition), Quaternion.identity);
        Instantiate(terrain, new Vector3(150, 10, landSpawnPosition), Quaternion.Euler(0f, 90f, 0f));

        landSpawnPosition += 150.0f;
    }
}