using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    Rigidbody rb;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        rb = GetComponent<Rigidbody>();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }

        if(enemyHealth.currentHealth <= 0)
        {
            KnockBack();
        }
    }

    void KnockBack()
    {
        Vector3 knockbackPos = transform.position - transform.forward;

        float knockbackForce = 0.025f;

        transform.position = Vector3.Lerp(transform.position, knockbackPos, knockbackForce);
    }
}
