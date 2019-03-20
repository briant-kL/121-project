using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox_zombie : MonoBehaviour
{
    public GameObject player;
    private playerMovement playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You have been hit");
            //ragdoll.SetActive(true);
            playerHealth.health--;
            Debug.Log(playerHealth.health);
        }

    }

}
