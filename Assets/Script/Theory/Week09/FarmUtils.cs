using System;
using UnityEngine;

public static class FarmUtils 
{
    // 3A. const: ��Ҥ�������繢ͧ���� �١��˹� � Compile-Time
    public const int WoolCapacity = 2;
    public const float Gravity = 9.81f;

    // 3B. static readonly: ��Ҥ������Ѻ��͹ ��˹���� � Run-Time (����ͤ��ʶ١��Ŵ)
    public static readonly float DayTime = (DateTime.Now.Month >= 4)? 10:8;
    public static readonly float NightTime = (DateTime.Now.Month >= 4)? 4:6;

    // Static Method: ����Ѻ��äӹǳ����������Ǣ�ͧ�ѺʶҹТͧ Object ��
    public static int CalculateWoolCapacity(int Amount)
    {
        // ��ҹ const �����
        return WoolCapacity * Amount;
    }

    // Static Method: ����Ѻ�ʴ�������
    public static void DisplayCurrentStatus()
    {
        Debug.Log($"--- FARM STATUS (via Static Class) ---");
        // ��Ҷ֧ const ��� static readonly �µç��ҹ���ͤ���
        Debug.Log($"Default Pens (const): {WoolCapacity}");
        Debug.Log($"Gravity (static readonly): {Gravity}");

        // ��Ҷ֧ Static Property �ͧ Sheep
        Debug.Log($"Total Sheep Population: {Sheep.TotalSheepCount}");
        Debug.Log($"Max Capacity (per pen 5): {CalculateWoolCapacity(5)}");
    }
}
