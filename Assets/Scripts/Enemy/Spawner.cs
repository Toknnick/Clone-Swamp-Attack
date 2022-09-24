using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    public UnityAction OnAllSpawned;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _positionForSpawn;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Player _target;

    private Wave _currectWave;
    private Enemy _enemyScript;
    private int _currectWaveNumber;
    private int _spawned;
    private float _timeAfterLastSpawn;

    public void NextWave()
    {
        SetWave(++_currectWaveNumber);
        _spawned = 0;
    }

    private void Start()
    {
        Initialize(_enemyPrefabs);
        SetWave(_currectWaveNumber);
    }

    private void Update()
    {
        if (_currectWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currectWave.Delay && _spawned < _currectWave.CountOfEnemy)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _timeAfterLastSpawn = 0;
                enemy.SetActive(true);
                enemy.transform.position = _positionForSpawn.position;
                _enemyScript = enemy.GetComponent<Enemy>();
                _enemyScript.Init(_target, _currectWave.EnemyHealth, _currectWave.RewardForEnemy);
                _spawned++;
            }
        }

        if (_spawned >= _currectWave.CountOfEnemy)
        {
            if (_waves.Count > _currectWaveNumber + 1)
                OnAllSpawned?.Invoke();

            _currectWave = null;
        }
    }

    private void SetWave(int index)
    {
        _currectWave = _waves[index];
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private int _countOfEnemy;
    [SerializeField] private int _rewardForEnemy;
    [SerializeField] private int _enemyHealth = 3;
    [SerializeField] private float _delay;

    public int CountOfEnemy => _countOfEnemy;
    public int RewardForEnemy => _rewardForEnemy;
    public int EnemyHealth => _enemyHealth;
    public float Delay => _delay;
}