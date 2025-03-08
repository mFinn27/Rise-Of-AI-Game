using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] private GameObject energyObjects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(player != null)
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
        if(energyObjects != null)
        {
            GameObject energy = Instantiate(energyObjects, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }
        base.die();
    }
}
