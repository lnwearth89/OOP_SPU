using UnityEngine;

public class BadIExample : MonoBehaviour
{
    public interface ICharacterSkills // Interface ����˭�
    {
        // ʡ�ŷҧ����Ҿ
        void PhysicalAttack();
        void UseShield();

        // ʡ���Ƿ�����
        void CastSpell(string spellName);
        void CheckMana();

        // ʡ��ʹѺʹع
        void Heal(int amount);
        void ApplyBuff();
    }

    // ���� �ѡú (Warrior) - �鹡�õ�����ҧ����Ҿ
    public class MeleeFighter : ICharacterSkills
    {
        // ��ҹ��ԧ: ʡ�ŷҧ����Ҿ
        public void PhysicalAttack()
        {
            Debug.Log("Warrior swings sword for physical damage.");
        }

        public void UseShield()
        {
            Debug.Log("Warrior raises shield to block.");
        }

        // �鴷��١�ѧ�Ѻ�����: ʡ���Ƿ��������ʹѺʹع
        public void CastSpell(string spellName)
        {
            // �ѡú������Ƿ����� �֧�١�ѧ�Ѻ��������ʹ�����ҧ���������¹ Exception
            throw new System.Exception("A Melee Fighter cannot cast spells!");
        }

        public void CheckMana()
        {
            // �ѡú������ҹ� �֧�١�ѧ�Ѻ��������ʹ�������դ�������
        }

        public void Heal(int amount)
        {
            // �ѡú�������ö�ѡ�ҵ���ͧ��
            Debug.Log("Melee Fighter tries to heal... but fails.");
        }

        public void ApplyBuff()
        {
            // �ѧ�Ѻ����ͧ�����ʹ���
        }
    }
}
