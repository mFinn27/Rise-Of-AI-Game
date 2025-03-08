using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
        transform.position += movementDirection * Time.deltaTime;
    }

    public void setMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}
