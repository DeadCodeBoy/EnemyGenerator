using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Transform[] _spawnPosition;

    private float _timeToWait = 2f;
    
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        var waitForSeconds = new WaitForSeconds(_timeToWait);

        while (_spawnPosition.Length > 0)
        {
            for (int i = 0; i < _spawnPosition.Length; i++)
            {
                var spawnPoint = Instantiate(_enemyTemplate, _spawnPosition[i].transform.position, Quaternion.identity);
                yield return waitForSeconds;
                Destroy(spawnPoint);
            }
        }
    }
}
