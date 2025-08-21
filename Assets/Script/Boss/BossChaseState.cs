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
        Debug.Log("Boss: เข้าสู่สถานะ Chase");
    }

    public void UpdateState()
    {
        // เคลื่อนที่เข้าหาผู้เล่น
        Vector3 direction = (boss.playerTransform.position - boss.transform.position).normalized;
        boss.rb.velocity = direction * boss.moveSpeed;

        // ตรวจสอบระยะห่างเพื่อเปลี่ยนสถานะ
        float distance = Vector3.Distance(boss.transform.position, boss.playerTransform.position);
        if (distance <= boss.attackRange)
        {
            // ถ้าผู้เล่นอยู่ในระยะโจมตี ให้เปลี่ยนสถานะ
            boss.ChangeState(boss.meleeAttackState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: ออกจากสถานะ Chase");
    }
}