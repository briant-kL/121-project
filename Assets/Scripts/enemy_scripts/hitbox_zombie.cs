using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox_zombie : MonoBehaviour
{
    public GameObject player;
    private Inventory playerInv;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        playerInv = player.GetComponent<Inventory>();
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
            //Debug.Log("You have been hit");
            //ragdoll.SetActive(true);
            playerInv.health--;
            Debug.Log(playerInv.health);
        }

    }

}
