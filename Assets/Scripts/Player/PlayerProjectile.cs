using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float damage;
    public float projectileSpeed = 10f;
    private Vector3 targetPosition;
    public Rigidbody2D rb;
    // public ProjectileEffect effects; // Placeholder for future effects implementation


    public void Initialize(float dmg, float speed)
    {
        damage = dmg;
        projectileSpeed = speed;
        Destroy(this.gameObject, 5f); // Destroy projectile after 5 seconds if it doesn't hit anything
    }
    public void SetTarget(Vector3 targetPos)
    {
        targetPosition = targetPos;
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        rb.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                // Apply effects here in the future
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
