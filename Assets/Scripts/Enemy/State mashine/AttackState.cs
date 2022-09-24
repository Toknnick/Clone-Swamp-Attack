using UnityEngine;

[RequireComponent(typeof(AnimatorEnemy))]
[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;

    private AnimatorEnemy _animatorEnemy;
    private Animator _animator;
    private float _timeOfLastAttack;
    private float _timeToAttack = 0.4f;

    private void Start()
    {
        _animatorEnemy = GetComponent<AnimatorEnemy>();
        _animator = GetComponent<Animator>();
        _animator.SetBool(_animatorEnemy.Attack, true);
    }   

    private void Update()
    {
        if (_timeOfLastAttack > _timeToAttack)
            Attack(Target);

        _timeOfLastAttack += Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.SetTrigger(_animatorEnemy.Hit);
        _timeOfLastAttack = 0;
        target.ApplayDamage(_damage);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
