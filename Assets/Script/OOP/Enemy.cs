using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float TimeToAttack = 1f;
    [SerializeField]
    private float attackRange = 1f;
    float distan;
    float timer = 0f;
    private void Update()
    {
        if (player==null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        distan = Vector3.Distance(transform.position, player.transform.position);
        Turn(player.transform.position - transform.position);
        if (distan < attackRange)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Attack(player);
                timer = TimeToAttack;
            }
        }
        else {
            animator.SetBool("Attack", false);
        }
    }
    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
    private void Attack(Player _player) {
        _player.TakeDamage(Damage);
        animator.SetBool("Attack",true);
        Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
    }
}
