using UnityEngine;

public class MoveState : State
{
    [SerializeField] private int _minSpeed;
    [SerializeField] private int _maxSpeed;

    private int _speed;

    private void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
