using UnityEngine;

public class EnemyRange : Enemy
{
    public float attackRange = 5f; // Range within which the enemy can attack

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        ChackDistanAndLockPlayer();
        if (distan < attackRange)
        {
            Attack(player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
}
