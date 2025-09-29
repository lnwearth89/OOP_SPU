using UnityEngine;
using TMPro;
public interface IInteractable
{
    // คุณสมบัติสำหรับชื่อวัตถุ
    string InteractionText { get; }
    // เมธอดที่ต้องมีเพื่อรองรับการโต้ตอบ
    void Interact(Player player);

}
