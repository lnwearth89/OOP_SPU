using UnityEngine;

public class BossIdleState : IState
{
    private BossStateMachine boss;

    public BossIdleState(BossStateMachine bossStateMachine)
    {
        this.boss = bossStateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Boss: ������ʶҹ� Idle");
        // ��ҵ�ͧ����������ش����͹���
        boss.rb.velocity = Vector3.zero;
    }

    public void UpdateState()
    {
        // ��Ǩ�ͺ������ҧ�ҡ������
        float distance = Vector3.Distance(boss.transform.position, boss.playerTransform.position);

        if (distance <= boss.chaseRange)
        {
            // ��Ҽ�������������������� �������¹ʶҹ�
            boss.ChangeState(boss.chaseState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: �͡�ҡʶҹ� Idle");
    }
}