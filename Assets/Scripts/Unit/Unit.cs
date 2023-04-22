using Inventory.Item;
using UnityEngine;
using UnityEngine.AI;
using Gameplay.Quests;
using UnityEngine.Events;
using Inventory.Inventory;

public enum UnitState
{
    Idle,
    Move,
    MoveToEnemy,
    Attack
}

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject selectionVisual;
    [SerializeField] private UnitState _state;

    [SerializeField] private int _pv;
    [SerializeField] private int _maxPv;
    [SerializeField] private int _shield;
    [SerializeField] private int _maxShield;
    [SerializeField] private int _minAttackDamage;
    [SerializeField] private int _maxAttackDamage;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _attackDistance;
    [SerializeField] private UnitBar bar;
    [SerializeField] private Player _player = null;

    private float lastAttackTime;
    private float pathUpdateRate = 1.0f;
    private float lastPathUpdateTime;
    private Unit _curEnemyTarget;

    private NavMeshAgent _navAgent = null;

    public UnitState State { get => _state; set => _state = value; }
    public Player Player { get => _player;}

    [System.Serializable]
    public class StateChangeEvent : UnityEvent<UnitState> { }
    public StateChangeEvent onStateChange;

    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        SetState(UnitState.Idle);
    }

    private void Update()
    {
        switch (_state)
        {
            case UnitState.Idle:
                break;
            case UnitState.Move:
                MoveUpdate();
                break;
            case UnitState.MoveToEnemy:
                MoveToEnemyUpdate();
                break;
            case UnitState.Attack:
                AttackUpdate();
                break;
            default:
                break;
        }
    }

    private void MoveToEnemyUpdate()
    {
        if (_curEnemyTarget == null)
        {
            SetState(UnitState.Idle);
            return;
        }

        if (Time.time - lastPathUpdateTime > pathUpdateRate)
        {
            lastPathUpdateTime = Time.time;
            _navAgent.isStopped = false;
            _navAgent.SetDestination(_curEnemyTarget.transform.position);
        }

        if (Vector3.Distance(transform.position, _navAgent.destination) <= _attackDistance)
        {
            SetState(UnitState.Attack);
        }
    }

    private void AttackUpdate()
    {
        if (_curEnemyTarget == null)
        {
            SetState(UnitState.Idle);
            return;
        }

        if (!_navAgent.isStopped)
        {
            _navAgent.isStopped = true;
        }

        if (Time.time - lastAttackTime > _attackRate)
        {
            lastAttackTime = Time.time;
            _curEnemyTarget.TakeDamage(Random.Range(_minAttackDamage, _maxAttackDamage + 1));
        }

        if (Vector3.Distance(transform.position, _curEnemyTarget.transform.position) > _attackDistance)
        {
            SetState(UnitState.MoveToEnemy);
        }
    }

    public void TakeDamage(int damage)
    {
        _shield -= damage;
        if (_shield < 0)
        {
            _pv -= Mathf.Abs(_shield);
            _shield = 0;
        }

        if (_shield <= 0 && _pv <= 0)
        {
            Die();
        }

        bar.UpdateShieldBar(_shield, _maxShield);
        bar.UpdatePvBar(_pv, _maxPv);
    }

    private void Die()
    {
        _player.GetComponent<InventorySystem>().RemoveUnit(this);
        Destroy(gameObject);
    }

    private void SetState(UnitState toState)
    {
        _state = toState;

        if (onStateChange != null)
            onStateChange.Invoke(_state);

        if (toState == UnitState.Idle)
        {
            _navAgent.isStopped = true;
            _navAgent.ResetPath();
        }
    }

    public void SetData(UnitTemplate unitTemplate)
    {
        _pv = unitTemplate.Pv;
        _maxPv = _pv;
        _shield = unitTemplate.Shield;
        _maxShield = _shield;
        _minAttackDamage = unitTemplate.MinAttackDamage;
        _maxAttackDamage = unitTemplate.MaxAttackDamage;
        _attackRate = unitTemplate.AttackRate;
        _attackDistance = unitTemplate.AttackDistance;
    }

    public void AttackUnit(Unit target)
    {
        _curEnemyTarget = target;
        SetState(UnitState.MoveToEnemy);
    }

    public void ToggleSelectionVisual(bool selected)
    {
        selectionVisual.SetActive(selected);
        QuestCompletion questCompletion = null;
        if (TryGetComponent<QuestCompletion>(out questCompletion))
        {
            questCompletion.CompleteObjective();
        }
    }

    public void MoveToPosition(Vector3 pos)
    {
        SetState(UnitState.Move);
        _navAgent.isStopped = false;
        _navAgent.SetDestination(pos);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    private void MoveUpdate()
    {
        if (Vector3.Distance(transform.position, _navAgent.destination) == 0.0f)
            SetState(UnitState.Idle);
    }
}
