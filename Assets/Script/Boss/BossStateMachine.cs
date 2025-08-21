using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : Identity
{
    // ���������Ѻ��ʶҹ�
    public IState currentState;

    // ʶҹе�ҧ� ��������
    public BossIdleState idleState;
    public BossChaseState chaseState;
    public BossMeleeAttackState meleeAttackState;

    // �������ҧ�ԧ
    public Transform playerTransform;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float chaseRange = 10f;
    public float attackRange = 2f;

    private void Awake()
    {
        // ���ҧ Object �ͧ����ʶҹТ����
        idleState = new BossIdleState(this);
        chaseState = new BossChaseState(this);
        meleeAttackState = new BossMeleeAttackState(this);

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // ��˹�ʶҹ��������
        ChangeState(idleState);
    }

    private void Update()
    {
        if (currentState != null)
        {
            // ���¡�����觢ͧʶҹлѨ�غѹ�ء���
            currentState.UpdateState();
        }
    }

    public void ChangeState(IState newState)
    {
        // ��Ǩ�ͺ�����ʶҹлѨ�غѹ�������
        if (currentState != null)
        {
            // �͡�ҡʶҹ����
            currentState.ExitState();
        }

        // ��˹�ʶҹ�����
        currentState = newState;

        // ������ʶҹ�����
        currentState.EnterState();
    }
}