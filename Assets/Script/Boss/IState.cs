public interface IState
{
    void EnterState(); // เมื่อเข้าสู่สถานะ
    void UpdateState(); // ทำงานทุกเฟรมในสถานะ
    void ExitState(); // เมื่อออกจากสถานะ
}