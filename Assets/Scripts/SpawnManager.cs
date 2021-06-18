using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject _enemyPrefabs;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private bool _stopSpawing = false;
    [SerializeField]
    private GameObject[] powerUps;
    // Start is called before the first
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawing == false)
        {
            float time = Random.Range(3.0f, 5.0f);
            Vector3 posToSpawn = new Vector3(Random.Range(-5.0f, 5.0f), 10, 0);
            GameObject newEnemy = Instantiate(_enemyPrefabs, posToSpawn ,Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(time);
        }   
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawing == false)
        {
             int randPowerUp = Random.Range(0, 3);
             float time = Random.Range(3.0f, 7.0f);
             Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
             Instantiate(powerUps[randPowerUp], posToSpawn, Quaternion.identity);
             yield return new WaitForSeconds(time);
        }   
    }

    public void OnPlayerDead()
    {
        _stopSpawing = true;
    }
} 
