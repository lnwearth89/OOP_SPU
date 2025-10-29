using UnityEngine;

namespace Theory.Week10
{
    public class Bow : IBonusWeapon
    {
        public int Damage = 6;
        public int GetDamage()
        {
            return Damage + 3;
        }
    }
}
