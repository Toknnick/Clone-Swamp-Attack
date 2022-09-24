using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHero : MonoBehaviour
{
    public int Shoot { get; private set; }
    public int Reaload { get; private set; }
    public int Die { get; private set; }

    private void Start()
    {
        Shoot = Animator.StringToHash("Shoot");
        Reaload = Animator.StringToHash("IsReaload");
        Die = Animator.StringToHash("Die");
    }
}
