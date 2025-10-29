using UnityEngine;

public class GoodIExample : MonoBehaviour
{
    // 1. Interface ����Ѻʡ�ŷҧ����Ҿ
    public interface IPhysicalAttacker
    {
        void PhysicalAttack();
        void UseShield();
    }

    // 2. Interface ����Ѻʡ���Ƿ�����
    public interface IMagicalUser
    {
        void CastSpell(string spellName);
        void CheckMana();
    }

    // 3. Interface ����Ѻʡ��ʹѺʹع
    public interface ISupport
    {
        void Heal(int amount);
        void ApplyBuff();
    }

    // ���� �ѡú (Warrior) - Implement ੾����觷���ͧ���
    public class GoodMeleeFighter : IPhysicalAttacker, ISupport // �ѡú implement ੾�� IPhysicalAttacker ��� ISupport (�� Buff ����ͧ)
    {
        public void PhysicalAttack()
        {
            Debug.Log("Good Fighter swings a powerful sword.");
        }

        public void UseShield()
        {
            Debug.Log("Good Fighter uses the shield.");
        }

        // �ѡú�ա��ʹѺʹع����ͧ
        public void Heal(int amount)
        {
            Debug.Log($"Good Fighter drinks a potion and heals for {amount} HP.");
        }

        public void ApplyBuff()
        {
            Debug.Log("Good Fighter roars, applying self-buff (Attack Up).");
        }
    }

    // ���� �ѡ�Ƿ (Mage) - Implement ੾����觷���ͧ���
    public class Mage : IMagicalUser, ISupport
    {
        public void CastSpell(string spellName)
        {
            Debug.Log($"Mage casts the {spellName} spell.");
        }

        public void CheckMana()
        {
            Debug.Log("Mage checks remaining Mana.");
        }

        // �ѡ�Ƿ�Ҩ�դ�������öʹѺʹع (�� Heal ���͹)
        public void Heal(int amount)
        {
            Debug.Log($"Mage casts a healing spell, recovering {amount} HP.");
        }

        public void ApplyBuff()
        {
            Debug.Log("Mage applies a party-wide buff (Magic Resist).");
        }
    }
}
