using System;
using UnityEngine;

public class BadLExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BirdHandler handler = new BirdHandler();
        handler.MakeBirdFly(new Bird()); // OK
        try
        {
            handler.MakeBirdFly(new Ostrich()); // ERROR! Program crashes
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"LSP Violation: {ex.Message}");
        }
    }

    public class Bird // �������: ��
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying.");
        }

        public virtual void LayEggs()
        {
            Console.WriteLine("Bird is laying eggs.");
        }
    }

    public class Ostrich : Bird // ����Ш͡���繹� ��Թ�����
    {
        public override void Fly()
        {
            // �ѭ��: ����Ш͡�ȺԹ����� ���ͧ implement ���ʹ���
            // �Ҩ���¹ Exception ���ͷ����÷��Դ����
            throw new InvalidOperationException("Ostrich cannot fly!");
            // Console.WriteLine("Ostrich waddles instead of flying.");
        }
    }

    public class BirdHandler
    {
        public void MakeBirdFly(Bird bird)
        {
            bird.Fly(); // ����� Ostrich �ҵç���оѧ
        }
    }

}
