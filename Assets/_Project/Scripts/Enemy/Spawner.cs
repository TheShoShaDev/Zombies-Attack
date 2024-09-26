using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private float _timeToSpawnEnemy = 2f;
    [SerializeField] private Transform[] StartPoints;
    [SerializeField] private float _timeToIncreseSpawnRate = 10f;
    [SerializeField] private float _timeToSpawnEnemyThreshold = 0.5f;

    [Header("References")]
    [SerializeField] private List<EnemySpawnData> Enemies = new List<EnemySpawnData>();
    [SerializeField] private Transform _target;

    [Header("Some Var")]
    [SerializeField] private float _timeSinceLastSpawn;


    private float _timeToIncreseSpawnRatePast = 0;

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        _timeToIncreseSpawnRatePast += Time.deltaTime;

        if (_timeSinceLastSpawn >= _timeToSpawnEnemy)
        {
            SpawnEnemy();
            _timeSinceLastSpawn = 0;
        }

        if (_timeToIncreseSpawnRatePast >= _timeToIncreseSpawnRate
            && _timeToSpawnEnemy > _timeToSpawnEnemyThreshold)
        {
            _timeToSpawnEnemy -= 0.1f;
            _timeToIncreseSpawnRatePast = 0;
        }
    }

    private void SpawnEnemy()
    {
        float randomValue = Random.value;

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (randomValue < Enemies[i].SpawnChance)
            {
                GameObject _prefabToSpawn = Enemies[i].EnemyPrefab;
                Enemy enemy = Instantiate(_prefabToSpawn, GetStartPoint(), Quaternion.identity).GetComponent<Enemy>();
                enemy.Target = _target;
                return;
            }
        }
    }

    private Vector3 GetStartPoint()
    {
        int _index = UnityEngine.Random.Range(0, StartPoints.Length);
        return StartPoints[_index].position;
    }

}
