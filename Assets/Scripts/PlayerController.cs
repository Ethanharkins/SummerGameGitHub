using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int health = 3;
    public TMP_Text healthText;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameManager gameManager;
    private bool canMove = false;
    private bool slowTimeUsed = false;
    private bool teleportUsed = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateHealthUI();
    }

    void Update()
    {
        if (!canMove) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("SlowTime") && !slowTimeUsed)
        {
            SlowTime();
        }

        if (Input.GetButtonDown("Teleport") && !teleportUsed)
        {
            Teleport();
        }
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void SlowTime()
    {
        slowTimeUsed = true;
        animator.SetTrigger("SlowTime");
        // Implement slow time effect
    }

    void Teleport()
    {
        teleportUsed = true;
        animator.SetTrigger("Teleport");
        // Implement teleportation logic
    }

    public void TakeDamage()
    {
        health--;
        UpdateHealthUI();
        if (health <= 0)
        {
            gameManager.PlayerLost();
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = "Health: " + health;
    }

    public void EnableControls()
    {
        canMove = true;
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
