using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject enemyBulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedNormalBullet = 20f;
    [SerializeField] private float speedCirleBullet = 10f;
    [SerializeField] private float hpValue = 20f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    [SerializeField] private float nextSkillTime = 0f;
    [SerializeField] private GameObject usbObject;
    protected override void Update()
    {
        base.Update();
        if(Time.time >= nextSkillTime)
        {
            UseSkill();
        }
    }

    protected override void die()
    {
        Instantiate(usbObject, transform.position, Quaternion.identity);
        base.die();
    }
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
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }

    private void NormalBullet()
    {
        if(player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(enemyBulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.setMovementDirection(directionToPlayer * speedNormalBullet);
        }
    }

    private void CircleBullet()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(enemyBulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.setMovementDirection(bulletDirection * speedCirleBullet);
        }
    }

    private void Heal(float HpAmount)
    {
        currentHP = Mathf.Min(currentHP + HpAmount, maxHP);
        updateHpBar();
    }

    private void SpawnMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void Teleport()
    {
        if(player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void FollowBullet()
    {

    }

    private void RandomSkill()
    {
        int randomSkill = Random.Range(0, 5);
        switch(randomSkill)
        {
            case 0:
                NormalBullet();
                break;
            case 1:
                CircleBullet();
                break;
            case 2:
                Heal(hpValue);
                break;
            case 3:
                SpawnMiniEnemy();
                break;
            case 4:
                Teleport();
                break;
        }
    }

    private void UseSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        RandomSkill();
    }
}
