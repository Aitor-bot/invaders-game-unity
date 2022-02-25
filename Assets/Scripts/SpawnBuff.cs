using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuff : MonoBehaviour
{
    [SerializeField] GameObject _buff;
    [SerializeField] GameObject _buffContainer;

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBuffRoutine());
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnBuffRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawnBuff = new Vector3(Random.Range(-9.4f, 9.4f), 8, 0);
           
            GameObject newBuff = Instantiate(_buff, posToSpawnBuff, Quaternion.identity);

            newBuff.transform.parent = _buffContainer.transform;
            yield return new WaitForSeconds(10.0f);
        }
    }
}