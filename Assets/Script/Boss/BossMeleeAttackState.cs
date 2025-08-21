using UnityEngine;

public class BossMeleeAttackState : IState
{
    private BossStateMachine boss;
    private float attackDuration = 1.0f; // ระยะเวลาในการโจมตี
    private float timer;

    public BossMeleeAttackState(BossStateMachine bossStateMachine)
    {
        this.boss = bossStateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Boss: เข้าสู่สถานะ MeleeAttack");
        timer = 0f;
        // หยุดเคลื่อนที่ขณะโจมตี
        boss.rb.velocity = Vector3.zero;

        // **TODO: เพิ่มโค้ดสำหรับ Animation การโจมตี หรือการสร้าง Hitbox ที่นี่**
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer >= attackDuration)
        {
            // เมื่อเวลาโจมตีครบกำหนด ให้เปลี่ยนกลับไปสถานะไล่ตาม
            boss.ChangeState(boss.chaseState);
        }
    }

    public void ExitState()
    {
        Debug.Log("Boss: ออกจากสถานะ MeleeAttack");
    }
}