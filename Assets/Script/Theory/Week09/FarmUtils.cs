using System;
using UnityEngine;

public static class FarmUtils 
{
    // 3A. const: ค่าคงที่ที่เป็นของคลาส ถูกกำหนด ณ Compile-Time
    public const int WoolCapacity = 2;
    public const float Gravity = 9.81f;

    // 3B. static readonly: ค่าคงที่ที่ซับซ้อน กำหนดค่า ณ Run-Time (เมื่อคลาสถูกโหลด)
    public static readonly float DayTime = (DateTime.Now.Month >= 4)? 10:8;
    public static readonly float NightTime = (DateTime.Now.Month >= 4)? 4:6;

    // Static Method: สำหรับการคำนวณที่ไม่เกี่ยวข้องกับสถานะของ Object ใดๆ
    public static int CalculateWoolCapacity(int Amount)
    {
        // ใช้งาน const ที่นี่
        return WoolCapacity * Amount;
    }

    // Static Method: สำหรับแสดงข้อมูล
    public static void DisplayCurrentStatus()
    {
        Debug.Log($"--- FARM STATUS (via Static Class) ---");
        // เข้าถึง const และ static readonly โดยตรงผ่านชื่อคลาส
        Debug.Log($"Default Pens (const): {WoolCapacity}");
        Debug.Log($"Gravity (static readonly): {Gravity}");

        // เข้าถึง Static Property ของ Sheep
        Debug.Log($"Total Sheep Population: {Sheep.TotalSheepCount}");
        Debug.Log($"Max Capacity (per pen 5): {CalculateWoolCapacity(5)}");
    }
}
