using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private int _countOfPrefabs = 20;
    private List<GameObject> _pool = new();

    protected void Initialize(GameObject[] prefabs)
    {
        GameObject spawned;

        for (int i = 0; i < _countOfPrefabs; i++)
        {
            spawned = Instantiate(prefabs[Random.Range(0, prefabs.Length)], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned;

        for (int i = 0; i < _countOfPrefabs; i++)
        {
            spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
