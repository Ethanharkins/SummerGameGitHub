using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameManager gameManager;
    private bool canMove = false;
    private bool invisibilityUsed = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove) return;

        // Implement AI behavior for shooting and using abilities
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    public void UseInvisibility()
    {
        if (invisibilityUsed) return;

        invisibilityUsed = true;
        animator.SetTrigger("Invisibility");
        // Implement invisibility logic
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            gameManager.EnemyLost();
        }
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
