using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public EnemyStats stats;

    private MeshRenderer meshRenderer;
    private Rigidbody rb;

    private int currentHealth;
    private float currentSpeed;

    public void Setup(EnemyStats stats)
    {
        this.stats = stats;
        name = stats.name;
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        meshRenderer.material.color = stats.enemyColor;
        currentHealth = stats.health;
        currentSpeed = stats.speed;
    }

    void Update()
    {
        rb.linearVelocity = new Vector3(currentSpeed, rb.linearVelocity.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            currentSpeed *= -1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();
            playerScript.ApplyKnockback(transform.position);
            playerScript.StartBlink();
            UIManager.Instance.UpdateScore(-20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stomper") && !Player.isGrounded)
        {
            currentHealth--;
            Debug.Log("Damaged");

            if (currentHealth <= 0)
            {
                UIManager.Instance.UpdateScore(stats.scoreGiven);
                Destroy(gameObject);
            }
        }
    }
}
