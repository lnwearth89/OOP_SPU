using System;
using UnityEngine;

namespace Theory.Week10
{

    public class GoodDExample : MonoBehaviour
    {
        private Enemy _enemy;

        // Dependency Injection (DI): GameManager �Ѻ IEnemy ��ҹ Constructor
        // GameManager ����������� Goblin ���� Orc
        public GoodDExample(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void StartWave()
        {
            Debug.Log("--- Game Manager Starts Wave ---");
            _enemy.Spawn();       // ���¡���ҹ Interface
            _enemy.PerformAction(); // ���¡���ҹ Interface
        }

        public abstract class Enemy
        {
            public virtual void Spawn()
            {
                Debug.Log("Enemy Spawned");
            }
            public virtual void PerformAction()
            {
                Debug.Log("Enemy Action Performed");
            }
        }


        // 2. ������дѺ���: Goblin (��觾� Abstraction IEnemy)
        public class Goblin : Enemy
        {
            public void Spawn()
            {
                Console.WriteLine("[Goblin] A swift Goblin appears!");
                Console.ResetColor();
            }

            public void PerformAction()
            {
                Console.WriteLine("[Goblin] Goblin tries to stab the player.");
            }
        }

        // 3. ������дѺ���: Orc (����ö��᷹ Goblin �� ���� Implement IEnemy)
        public class Orc : Enemy
        {
            public void Spawn()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[Orc] A massive Orc marches in!");
                Console.ResetColor();
            }

            public void PerformAction()
            {
                Console.WriteLine("[Orc] Orc charges and smashes the player.");
            }
        }
    }
}

  
