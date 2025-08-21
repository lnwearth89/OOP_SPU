using UnityEngine;

public class BossMeleeAttackState : IState
{
    private BossStateMachine boss;
    private float attackDuration = 1.0f; // ��������㹡������
    private float timer;

    public BossMeleeAttackState(BossStateMachine bossStateMachine)
    {
        this.boss = bossStateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Boss: ������ʶҹ� MeleeAttack");
        timer = 0f;
        // ��ش����͹��袳�����
        boss.rb.velocity = Vector3.zero;

        // **TODO: ����������Ѻ Animation ������� ���͡�����ҧ Hitbox �����**
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer >= attackDuration)
        {
            // ������������դú��˹� �������¹��Ѻ�ʶҹ������
            boss.ChangeState(boss.chaseState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: �͡�ҡʶҹ� MeleeAttack");
    }
}