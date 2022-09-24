using UnityEngine;

[RequireComponent(typeof(MoveState))]
[RequireComponent(typeof(DistanceTransition))]
[RequireComponent(typeof(AttackState))]
[RequireComponent(typeof(Enemy))]
public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private MoveState _moveState;
    private DistanceTransition _distanceTransition;
    private AttackState _attackState;
    private State _currectState;

    public State CurrectState => _currectState;

    public void ResetStateMashine()
    {
        _currectState = _firstState;
        _moveState.enabled = false;
        _distanceTransition.enabled = false;
        _attackState.enabled = false;

        if (_currectState != null)
            _currectState.Enter(_target);
    }

    private void Start()
    {
        _moveState = GetComponent<MoveState>();
        _distanceTransition = GetComponent<DistanceTransition>();
        _attackState = GetComponent<AttackState>();
        _target = GetComponent<Enemy>().Target;
        ResetStateMashine();
    }

    private void Update()
    {
        if (_currectState == null)
            return;

        var nextState = _currectState.GetNext();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currectState != null)
            _currectState.Exit();

        _currectState = nextState;

        if (_currectState != null)
            _currectState.Enter(_target);
    }
}
