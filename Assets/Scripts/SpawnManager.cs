using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _asteroid;
    [SerializeField] GameObject _asteroidContainer;
    [SerializeField] GameObject _alien;
    [SerializeField] GameObject _alienContainer;

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroidRoutine());
        StartCoroutine(SpawnAlienRoutine());
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnAsteroidRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawnAsteroid = new Vector3(Random.Range(-9.4f, 9.4f), 8, 0);
           
            GameObject newAsteroid = Instantiate(_asteroid, posToSpawnAsteroid, Quaternion.identity);

            newAsteroid.transform.parent = _asteroidContainer.transform;
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SpawnAlienRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawnAlien = new Vector3(Random.Range(-9.4f, 9.4f), 8, 0);
           
            GameObject newAlien = Instantiate(_alien, posToSpawnAlien, Quaternion.identity);

            newAlien.transform.parent = _alienContainer.transform;
            yield return new WaitForSeconds(1.0f);
        }
    }
}