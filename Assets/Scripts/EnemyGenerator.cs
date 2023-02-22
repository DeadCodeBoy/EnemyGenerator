using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPosition;
    
    private void Start()
    {
        StartCoroutine(_enemySpawn());
    }

    private IEnumerator _enemySpawn()
    {
        for (int i = 0; i < _spawnPosition.Length; i++)
        {
            var enemy = Instantiate(_enemy, _spawnPosition[i].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(enemy);
        }
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(_enemySpawn());
    }
}
