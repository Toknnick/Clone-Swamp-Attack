using UnityEngine;

[RequireComponent(typeof(EnemyStateMashine))]
public class Enemy : MonoBehaviour
{
    private EnemyStateMashine _enemyStateMashine;
    private Player _target;
    private int _health;
    private int _reward;

    public Player Target => _target;

    public void Init(Player target, int health, int reward)
    {
        _target = target;
        _health = health;
        _reward = reward;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Start()
    {
        _enemyStateMashine = GetComponent<EnemyStateMashine>();
    }

    private void Die()
    {
        _target.AddMoney(_reward);
        _enemyStateMashine.ResetStateMashine();
        gameObject.SetActive(false);
    }

}
