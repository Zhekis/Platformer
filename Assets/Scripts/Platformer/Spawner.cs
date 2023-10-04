using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pathEnemy;
    [SerializeField] private Transform _pathCoin;
    [SerializeField] private Enemy _templateEnemy;
    [SerializeField] private Coin _templateCoin;

    private Transform[] _points;

    private void Start()
    {
        var addEnemyJob = StartCoroutine(AddEnemy());
        var addCoinJob = StartCoroutine(AddCoin());
    }

    private IEnumerator AddEnemy()
    {
        _points = new Transform[_pathEnemy.childCount];
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _pathEnemy.childCount; i++)
        {
            _points[i] = _pathEnemy.GetChild(i);
            var spawnedCoin = Instantiate(_templateEnemy, _points[i].position, Quaternion.identity);

            yield return waitForTwoSeconds;
        }
    }

    private IEnumerator AddCoin()
    {
        _points = new Transform[_pathCoin.childCount];
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _pathCoin.childCount; i++)
        {
            _points[i] = _pathCoin.GetChild(i);
            var spawnedCoin = Instantiate(_templateCoin, _points[i].position, Quaternion.identity);

            yield return waitForTwoSeconds;
        }
    }
}