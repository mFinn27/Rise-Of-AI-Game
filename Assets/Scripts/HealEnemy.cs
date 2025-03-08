using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 15f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(enterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }

    protected override void die()
    {
        if(player != null)
        {
            player.Heal(healValue);
        }
        base.die();
    }
}
