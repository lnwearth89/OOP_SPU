using System;
using UnityEngine;

public class Sheep 
{
    // Instance Field
    private int _SheepNumber;
    // Static Field ������纤������ͧ��
    private static int _totalSheepCount;

    // Static Field ���ͨ��ͧ���������鹷����Ŵ�ҡ����駤��
    private static readonly int _initialPopulation;

    // 1. Static Constructor: �١���¡�������� ��͹������ҧ Object ���͡����Ҷ֧ Static Member �á
    static Sheep()
    {
        Debug.Log("--- Sheep Class Loaded: Running Static Constructor ---");
        // �������ҹ���͡����Ŵ���������鹨ҡ�ҹ�������������
        _initialPopulation = 5;
        _totalSheepCount = _initialPopulation;
        Debug.Log($"Starting population set to: {_initialPopulation}");
    }

    public int SheepNumber
    {
        get { return _SheepNumber; }
        // ����� 'set' ���е�ͧ��������Ẻ��ҹ���ҧ������¹͡
    }
    // 2. Static Property: �������Ҷ֧��� Static Field ���ҧ��ʹ�����ФǺ�����
    public static int TotalSheepCount
    {
        get { return _totalSheepCount; }
        // ����� 'set' ���е�ͧ��������Ẻ��ҹ���ҧ������¹͡
    }
    // Instance Constructor
    public Sheep(int n)
    {
        this._SheepNumber = n;
        _totalSheepCount++; // �ء���駷�����ҧ Object ��������ǹѺ Static
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
    // Static Method (����͹���)
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
