using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public GameObject hitbox;
    //https://unity3d.com/learn/tutorials/projects/survival-shooter/enemy-one
    private bool foundPlayer;

    private Animator animator;

    void Awake()
    {
        // Set up the references.
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        /*
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
        */
        if(player != null)
        {
            nav.SetDestination(player.position);
            animator.SetBool("foundPlayer", true);
        }
            
        
    }

    IEnumerator attackingRoutine()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(1);
        hitbox.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill_env"))
        {
            gameObject.SetActive(false);
            //Debug.Log("You have been hit");
            //ragdoll.SetActive(true);
        }



        //Inventory collisions

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit player");
            animator.SetTrigger("Attacking");
            attackingRoutine();
            //weapon.SetActive(true);
            //other.gameObject.SetActive(false);
            //haveWeapon = true;
            //animator.SetBool("hasWeapon", true);
            //Debug.Log(animator.GetBool("hasWeapon"));

        }

        

    }






}