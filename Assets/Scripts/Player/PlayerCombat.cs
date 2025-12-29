using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject cachedProjectilePrefab;
    public void SetProjectilePrefab(GameObject prefab)
    {
        cachedProjectilePrefab = prefab;
    }
    public void FireProjectile(Vector3 targetPosition, float damage, float speed)
    {
        Vector3 spawnPosition = transform.position;
        GameObject projectile = Instantiate(cachedProjectilePrefab, spawnPosition, Quaternion.identity);
        PlayerProjectile projScript = projectile.GetComponent<PlayerProjectile>();
        if (projScript != null)
        {
            projScript.Initialize(damage, speed);
            projScript.SetTarget(targetPosition);
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
