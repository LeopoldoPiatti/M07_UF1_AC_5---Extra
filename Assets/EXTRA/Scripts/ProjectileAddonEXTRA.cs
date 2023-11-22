using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddonEXTRA : MonoBehaviour
{
    public float delay;
    public float radius;
    public float force;
    float countdown;
    bool hasExploded = false;

    public int damage;
    
    public GameObject granadeExplosion;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true; 
        }
    }

    void  Explode ()
    {
        Instantiate(granadeExplosion, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObjects in colliders) 
        {
        Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
        if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}