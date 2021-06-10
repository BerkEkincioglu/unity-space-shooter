using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefabs;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private bool _stopSpawing = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        {
            while (_stopSpawing == false)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
                GameObject newEnemy = Instantiate(_enemyPrefabs, posToSpawn ,Quaternion.identity);
                newEnemy.transform.parent = enemyContainer.transform;
                yield return new WaitForSeconds(5.0f);
            }
        }
    }

    public void OnPlayerDead()
    {
        _stopSpawing = true;
    }
} 
