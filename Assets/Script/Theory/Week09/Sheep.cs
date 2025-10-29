using System;
using UnityEngine;

public class Sheep 
{
    // Instance Field
    private int _SheepNumber;
    // Static Field ที่ใช้เก็บค่ารวมของแกะ
    private static int _totalSheepCount;

    // Static Field เพื่อจำลองค่าเริ่มต้นที่โหลดจากไฟล์ตั้งค่า
    private static readonly int _initialPopulation;

    // 1. Static Constructor: ถูกเรียกครั้งเดียว ก่อนการสร้าง Object หรือการเข้าถึง Static Member แรก
    static Sheep()
    {
        Debug.Log("--- Sheep Class Loaded: Running Static Constructor ---");
        // สมมติว่านี่คือการโหลดค่าเริ่มต้นจากฐานข้อมูลหรือไฟล์
        _initialPopulation = 5;
        _totalSheepCount = _initialPopulation;
        Debug.Log($"Starting population set to: {_initialPopulation}");
    }

    public int SheepNumber
    {
        get { return _SheepNumber; }
        // ไม่มี 'set' เพราะต้องการให้เป็นแบบอ่านอย่างเดียวภายนอก
    }
    // 2. Static Property: ให้การเข้าถึงค่า Static Field อย่างปลอดภัยและควบคุมได้
    public static int TotalSheepCount
    {
        get { return _totalSheepCount; }
        // ไม่มี 'set' เพราะต้องการให้เป็นแบบอ่านอย่างเดียวภายนอก
    }
    // Instance Constructor
    public Sheep(int n)
    {
        this._SheepNumber = n;
        _totalSheepCount++; // ทุกครั้งที่สร้าง Object จะเพิ่มตัวนับ Static
        Debug.Log($"Sheep created in pen {_SheepNumber}.");
    }

    // Instance Method
    public int AskNumber()
    {
        return _SheepNumber;
    }
    public void SetNumber(int n)
    {
        _SheepNumber = n;
    }
    // Static Method (เหมือนเดิม)
    public static void RemoveSheep(int count)
    {
        _totalSheepCount -= count;
        Debug.Log($"{count} sheep removed. Current total: {_totalSheepCount}");
    }
    public static int GetAllSheep(int count)
    {
        return _totalSheepCount;
    }
    public void Jump()
    {
        Debug.Log($"Sheep {_SheepNumber} is jumping! Sheep got Gravity {FarmUtils.Gravity}");
    }
}
