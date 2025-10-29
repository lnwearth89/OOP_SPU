using UnityEngine;

public class GoodIExample : MonoBehaviour
{
    // 1. Interface สำหรับสกิลทางกายภาพ
    public interface IPhysicalAttacker
    {
        void PhysicalAttack();
        void UseShield();
    }

    // 2. Interface สำหรับสกิลเวทมนตร์
    public interface IMagicalUser
    {
        void CastSpell(string spellName);
        void CheckMana();
    }

    // 3. Interface สำหรับสกิลสนับสนุน
    public interface ISupport
    {
        void Heal(int amount);
        void ApplyBuff();
    }

    // คลาส นักรบ (Warrior) - Implement เฉพาะสิ่งที่ต้องการ
    public class GoodMeleeFighter : IPhysicalAttacker, ISupport // นักรบ implement เฉพาะ IPhysicalAttacker และ ISupport (เช่น Buff ตัวเอง)
    {
        public void PhysicalAttack()
        {
            Debug.Log("Good Fighter swings a powerful sword.");
        }

        public void UseShield()
        {
            Debug.Log("Good Fighter uses the shield.");
        }

        // นักรบมีการสนับสนุนตัวเอง
        public void Heal(int amount)
        {
            Debug.Log($"Good Fighter drinks a potion and heals for {amount} HP.");
        }

        public void ApplyBuff()
        {
            Debug.Log("Good Fighter roars, applying self-buff (Attack Up).");
        }
    }

    // คลาส นักเวท (Mage) - Implement เฉพาะสิ่งที่ต้องการ
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

        // นักเวทอาจมีความสามารถสนับสนุน (เช่น Heal เพื่อน)
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
