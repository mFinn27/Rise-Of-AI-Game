using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.takeDamage(15f);
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("USB"))
        {
            Debug.Log("You Are Winner!!!");
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Energy"))
        {
            gameManager.addEnergy();
            Destroy(collision.gameObject);
            audioManager.playEnergySound();
        }
    }
}
