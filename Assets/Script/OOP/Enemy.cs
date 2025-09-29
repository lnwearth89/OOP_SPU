using UnityEngine;

public class Enemy : Character 
{
    [SerializeField]
    private float TimeToAttack = 3f;

    protected float distan;
    float timer = 0f;
    private void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        ChackDistanAndLockPlayer();
        if (distan < 1.5)
        {
            Attack(player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    protected void ChackDistanAndLockPlayer()
    {
        distan = Vector3.Distance(transform.position, player.transform.position);
        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
    protected virtual void Attack(Player _player) {
        if (timer <= 0)
        {
            _player.TakeDamage(Damage);
            animator.SetBool("Attack", true);
            Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }
        
    }
}
