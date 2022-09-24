using UnityEngine;

public class AnimatorEnemy : MonoBehaviour
{
    public int Attack { get; private set; }
    public int Celebration { get; private set; }
    public int Hit { get; private set; }

    private void Start()
    {
        Attack = Animator.StringToHash("IsAttack");
        Hit = Animator.StringToHash("Hit");
        Celebration = Animator.StringToHash("IsCelebration");
    }
}
