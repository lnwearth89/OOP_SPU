using System;
using UnityEngine;

public class GoodLExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public class Animal // ���ʾ�鹰ҹ����Ѻ�ѵ��
    {
        public virtual void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    public interface IFlyable // Interface ����Ѻ�ѵ����Թ��
    {
        void Fly();
    }

    public class BirdAnimal : Animal // ����鹰ҹ (�Ҩ�кԹ������������)
    {
        public override void Eat()
        {
            Console.WriteLine("Bird is eating seeds.");
        }
    }

    public class Eagle : BirdAnimal, IFlyable // ���Թ��պԹ��
    {
        public void Fly()
        {
            Console.WriteLine("Eagle is soaring high.");
        }
    }

    public class OstrichAnimal : BirdAnimal // ����Ш͡�ȺԹ�����
    {
        // ����ͧ implement IFlyable
        public override void Eat()
        {
            Console.WriteLine("Ostrich is eating plants.");
        }
    }

    public class FlyableHandler // ���ʷ��Ѵ���੾����觷��Թ��
    {
        public void MakeSomethingFly(IFlyable flyableCreature)
        {
            flyableCreature.Fly();
        }
    }
}
