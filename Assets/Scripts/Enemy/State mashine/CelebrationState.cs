using UnityEngine;

[RequireComponent(typeof(AnimatorEnemy))]
[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private AnimatorEnemy _animatorEnemy;
    private Animator _animator;

    private void Awake()
    {
        _animatorEnemy = GetComponent<AnimatorEnemy>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_animatorEnemy.Celebration, true);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
