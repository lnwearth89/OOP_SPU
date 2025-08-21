using UnityEngine;

public class BossChaseState : IState
{
    private BossStateMachine boss;

    public BossChaseState(BossStateMachine bossStateMachine)
    {
        this.boss = bossStateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Boss: ������ʶҹ� Chase");
    }

    public void UpdateState()
    {
        // ����͹�������Ҽ�����
        Vector3 direction = (boss.playerTransform.position - boss.transform.position).normalized;
        boss.rb.velocity = direction * boss.moveSpeed;

        // ��Ǩ�ͺ������ҧ��������¹ʶҹ�
        float distance = Vector3.Distance(boss.transform.position, boss.playerTransform.position);
        if (distance <= boss.attackRange)
        {
            // ��Ҽ������������������ �������¹ʶҹ�
            boss.ChangeState(boss.meleeAttackState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: �͡�ҡʶҹ� Chase");
    }
}