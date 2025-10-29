using UnityEngine;

namespace Theory.Week10 {
    public class Sword : IBonusWeapon
    {
        public int Damage = 10;
        public int GetDamage()
        {
            return Damage + 5;
        }
    }
}

