using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator anim;
    [SerializeField] private float maxHP = 50f;
    protected float currentHP;
    [SerializeField] private Image HpBar;

    [SerializeField] private GameManager gameManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHP = maxHP;
        updateHpBar();
    }
    void Update()
    {
        handleMovement();
        pauseGame();
    }

    void handleMovement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput.normalized * moveSpeed;
        if (moveInput.x < 0)
        {
            rbSprite.flipX = true;
        }
        else if(moveInput.x > 0)
        {
            rbSprite.flipX = false;
        }
        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void takeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        updateHpBar();
        if(currentHP <= 0)
        {
            die();
        }
    }

    public void Heal(float healValue)
    {
        if (currentHP < maxHP)
        {
            currentHP += healValue;
            currentHP = Mathf.Min(currentHP, maxHP);
            updateHpBar();
        }
    }
    private void die()
    {
        gameManager.GameOverMenu();
    }

    private void updateHpBar()
    {
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHP / maxHP;
        }
    }

    private void pauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseGameMenu();
        }
    }
}
