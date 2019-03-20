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
    public int health;
    //https://unity3d.com/learn/tutorials/projects/survival-shooter/enemy-one
    private bool foundPlayer;
    private Animator animator;
    public GameObject ragdoll;
    private bool isDead;

    private EnemyMovement enemy;
    void Awake()
    {
        // Set up the references.
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<EnemyMovement>();
        isDead = false;
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
        if(player != null && isDead == false)
        {
            nav.SetDestination(player.position);
            animator.SetBool("foundPlayer", true);
        }
            
        
    }

    IEnumerator attackingRoutine()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(1);
        
        //playerHealth.health--;
        hitbox.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill_env"))
        {
            //enemy.enabled = false;
            //animator.enabled = false;
            //nav.enabled = false;
            //Debug.Log("You have been hit");
            //ragdoll.SetActive(true);
            gameObject.SetActive(false);
        }




        if (other.gameObject.CompareTag("Player"))
        {
            if(isDead == false)
            {
                Debug.Log("start attack on player");
                animator.SetTrigger("Attacking");
                StartCoroutine(attackingRoutine());
            }
            
            //weapon.SetActive(true);
            //other.gameObject.SetActive(false);
            //haveWeapon = true;
            //animator.SetBool("hasWeapon", true);
            //Debug.Log(animator.GetBool("hasWeapon"));

        }

        if (other.gameObject.CompareTag("sword_hitbox"))
        {
            //ragdoll.SetActive(true);
            //Instantiate<>
            gameObject.SetActive(false);
            //enemy.enabled = false;
            //animator.enabled = false;
            //nav.enabled = false;
            //isDead = true;
            
        }
        


    }






}