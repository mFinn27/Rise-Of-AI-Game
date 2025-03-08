using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player player;
    [SerializeField] protected float maxHP = 30f;
    protected float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float enterDamage = 5f;
    [SerializeField] protected float stayDamage = 0.5f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHP = maxHP;
        updateHpBar();
    }

    protected virtual void Update()
    {
        moveToPlayer();
    }

    protected void moveToPlayer()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            flipEnemy();
        }
    }

    protected void flipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public virtual void takeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        updateHpBar();
        if (currentHP <= 0)
        {
            die();
        }
    }

    protected virtual void die()
    {
        Destroy(gameObject);
    }

    protected void updateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHP/maxHP;
        }
    }
}
