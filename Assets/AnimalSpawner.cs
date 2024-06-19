using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject cowPrefab;
    public GameObject deerPrefab;
    public GameObject dogPrefab;
    public GameObject horsePrefab;

    public GameObject spawnPrefab;

    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(0, 0, 21);
        StartCoroutine(SpawnAnimal());
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void RandomizeSpawner()
    {
        spawnPoint.x = Random.Range(-20, 20);

        int idSpawned = Random.Range(0, 3);
        if(idSpawned == 0)
        {
            spawnPrefab = cowPrefab;
        }
        else if(idSpawned == 1)
        {
            spawnPrefab = deerPrefab;
        }
        else if(idSpawned == 2)
        {
            spawnPrefab = dogPrefab;
        }
        else if(idSpawned == 3)
        {
            spawnPrefab = horsePrefab;
        }


    }

    public IEnumerator SpawnAnimal()
    {
        yield return new WaitForSecondsRealtime(2);
        RandomizeSpawner();
        Instantiate(spawnPrefab, spawnPoint, Quaternion.EulerAngles(0,135,0));

        StartCoroutine(SpawnAnimal());
    }
}
