using System;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // create Sheep instances
        // 1. �����Ҷ֧ Static Property (�з���� Static Constructor �ͧ Sheep �ӧҹ��͹)
        Debug.Log($"Initial Check - Sheep Count: {Sheep.TotalSheepCount}");

        // 2. ���ҧ Instance �ͧ Sheep
        Debug.Log("\n--- Creating Sheep Instances ---");
        Sheep alfred = new Sheep(1);
        Sheep bob = new Sheep(2);
        Sheep clara = new Sheep(3);
        Sheep dave = new Sheep(4);

        // check total number of sheep
        // note that this is a class method, not an object method.
        Debug.Log("Total number of sheep is " + Sheep.TotalSheepCount);

        // check which pen dave is in then move him to another pen
        Debug.Log("dave is in pen " + dave.AskNumber());
        dave.SetNumber(5);
        Debug.Log("moving dave ...");
        Debug.Log("dave is now in pen " + dave.AskNumber());

        // 3. ��Ҷ֧ const ������� Static Class
        Debug.Log($"Accessing const directly: The farm has {FarmUtils.WoolCapacity} default pens.");

        // 4. ���¡�� Static Class Methods
        FarmUtils.DisplayCurrentStatus();

        // 5. ���¡�� Static Method ��дټš�з���� Static Property
        Sheep.RemoveSheep(1);
        FarmUtils.DisplayCurrentStatus();
    }

   
}
