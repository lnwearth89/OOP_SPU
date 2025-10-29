using System;
using UnityEngine;

public class GoodLExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public class Animal // คลาสพื้นฐานสำหรับสัตว์
    {
        public virtual void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    public interface IFlyable // Interface สำหรับสัตว์ที่บินได้
    {
        void Fly();
    }

    public class BirdAnimal : Animal // นกพื้นฐาน (อาจจะบินได้หรือไม่ก็ได้)
    {
        public override void Eat()
        {
            Console.WriteLine("Bird is eating seeds.");
        }
    }

    public class Eagle : BirdAnimal, IFlyable // นกอินทรีบินได้
    {
        public void Fly()
        {
            Console.WriteLine("Eagle is soaring high.");
        }
    }

    public class OstrichAnimal : BirdAnimal // นกกระจอกเทศบินไม่ได้
    {
        // ไม่ต้อง implement IFlyable
        public override void Eat()
        {
            Console.WriteLine("Ostrich is eating plants.");
        }
    }

    public class FlyableHandler // คลาสที่จัดการเฉพาะสิ่งที่บินได้
    {
        public void MakeSomethingFly(IFlyable flyableCreature)
        {
            flyableCreature.Fly();
        }
    }
}
