using UnityEngine;

public class Weapon : ObjectPool
{
    [SerializeField] private GameObject _prefabOfBullet;

    public void Shoot(Transform shootPoint)
    {
        if (TryGetObject(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.transform.position = shootPoint.position;
        }
    }

    private void Start()
    {
        Initialize(_prefabOfBullet);
    }
}
