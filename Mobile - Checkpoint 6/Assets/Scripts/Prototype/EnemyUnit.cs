using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public EnemyStats stats;

    private MeshRenderer meshRenderer;
    private Rigidbody rb;

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
    }

    void Update()
    {
        rb.linearVelocity = new Vector3(stats.speed, rb.linearVelocity.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            stats.speed *= -1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();
            playerScript.ApplyKnockback(transform.position);
            playerScript.StartBlink();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stomper") && !Player.isGrounded)
        {
            Destroy(gameObject);
        }
    }
}
