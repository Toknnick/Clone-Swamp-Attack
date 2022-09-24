public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target.isActiveAndEnabled == false)
        {
            IsNeedTransit = true;
        }
    }
}
