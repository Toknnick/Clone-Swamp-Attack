using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 1, transform.position.y), _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.GetDamage(_damage);

        gameObject.SetActive(false);
    }
}
