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
        Debug.Log("Boss: เข้าสู่สถานะ Idle");
        // ถ้าต้องการให้บอสหยุดเคลื่อนที่
        boss.rb.velocity = Vector3.zero;
    }

    public void UpdateState()
    {
        // ตรวจสอบระยะห่างจากผู้เล่น
        float distance = Vector3.Distance(boss.transform.position, boss.playerTransform.position);

        if (distance <= boss.chaseRange)
        {
            // ถ้าผู้เล่นเข้ามาในระยะไล่ตาม ให้เปลี่ยนสถานะ
            boss.ChangeState(boss.chaseState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: ออกจากสถานะ Idle");
    }
}