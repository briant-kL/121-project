using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool key1 = false;
    public bool key2 = false;
    public bool key3 = false;
    public int health;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key1"))
        {
            Debug.Log("key1 acquired");
            key1 = true;
            other.gameObject.SetActive(false);

        }
        /*
        if (other.gameObject.CompareTag("key2"))
        {
            Debug.Log("key2 acquired");
            key2 = true;
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("key3"))
        {
            Debug.Log("key3 acquired");
            key3 = true;
            other.gameObject.SetActive(false);

        }
        */


        if (other.gameObject.CompareTag("healthPack"))
        {
            Debug.Log("You gotten some health");
            health = health + 1;
            Debug.Log(health);
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("kill_env"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You have been hit");
            health = health - 1;
            Debug.Log(health);
            //ragdoll.SetActive(true);
        }


        if (other.gameObject.CompareTag("door1"))
        {
            //gameObject.SetActive(false);
            if(key1 == true)
            {
                other.gameObject.SetActive(false);
                Debug.Log("Door Unlocked");
            }
            else
                Debug.Log("You dont have the key");
            

            
        }

        /*
        if (other.gameObject.CompareTag("door2"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You dont have the key");

        }
        if (other.gameObject.CompareTag("door3"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You dont have the key");

        }
        */
    }
}
