using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : Identity
{
    // ตัวแปรสำหรับเก็บสถานะ
    public IState currentState;

    // สถานะต่างๆ ที่เป็นไปได้
    public BossIdleState idleState;
    public BossChaseState chaseState;
    public BossMeleeAttackState meleeAttackState;

    // ตัวแปรอ้างอิง
    public Transform playerTransform;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float chaseRange = 10f;
    public float attackRange = 2f;

    private void Awake()
    {
        // สร้าง Object ของแต่ละสถานะขึ้นมา
        idleState = new BossIdleState(this);
        chaseState = new BossChaseState(this);
        meleeAttackState = new BossMeleeAttackState(this);

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // กำหนดสถานะเริ่มต้น
        ChangeState(idleState);
    }

    private void Update()
    {
        if (currentState != null)
        {
            // เรียกใช้คำสั่งของสถานะปัจจุบันทุกเฟรม
            currentState.UpdateState();
        }
    }

    public void ChangeState(IState newState)
    {
        // ตรวจสอบว่ามีสถานะปัจจุบันหรือไม่
        if (currentState != null)
        {
            // ออกจากสถานะเดิม
            currentState.ExitState();
        }

        // กำหนดสถานะใหม่
        currentState = newState;

        // เข้าสู่สถานะใหม่
        currentState.EnterState();
    }
}