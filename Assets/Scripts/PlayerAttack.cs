using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float radius;
    public float cooldownTime = 2.0f; 
    public float fleeTime = 3.0f;
    public float resumeTime = 2.0f; 
    bool canAttack = true;
    public LayerMask enemyLayer;
    public GameObject attackWave;

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            Attack();
            StartCoroutine(Cooldown());
        }
    }

    void Attack()
    {
        GameObject waveInstance = Instantiate(attackWave, transform.position, transform.rotation);
        Destroy(waveInstance, 1.0f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider nearbyObjects in colliders)
        {
            NavMeshAgent navMeshAgent = nearbyObjects.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.isStopped = true;
                               
                StartCoroutine(FleeAndResume(navMeshAgent));
            }
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTime);
        canAttack = true;
    }

    IEnumerator FleeAndResume(NavMeshAgent navMeshAgent)
    {
        
        yield return new WaitForSeconds(fleeTime);
        yield return new WaitForSeconds(resumeTime);
        navMeshAgent.isStopped = false;
    }
}







