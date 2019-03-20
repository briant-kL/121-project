using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public bool key1 = false;
    public bool key2 = false;
    public bool key3 = false;
    //public int health;
    public Text text1;
    public Text text2;
    public Text text3;
    

    private Animator animator;
    private playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<playerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetKeyText1()
    {
        text1.text = "Key1 acquired";
    }
    void SetKeyText2()
    {
        text2.text = "Key2 aqcuired";
    }
    void SetKeyText3()
    {
        text3.text = "Key3 acquired";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key1"))
        {
            Debug.Log("key1 acquired");
            key1 = true;
            other.gameObject.SetActive(false);
            SetKeyText1();
        }
        
        if (other.gameObject.CompareTag("key2"))
        {
            Debug.Log("key2 acquired");
            key2 = true;
            other.gameObject.SetActive(false);
            SetKeyText2();
        }

        if (other.gameObject.CompareTag("key3"))
        {
            Debug.Log("key3 acquired");
            key3 = true;
            other.gameObject.SetActive(false);
            SetKeyText3();
        }
        


        if (other.gameObject.CompareTag("healthPack"))
        {
            Debug.Log("You gotten some health");
            player.health = player.health + 1;
            Debug.Log(player.health);
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("kill_env"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You have been hit");
            player.health = 0;
            Debug.Log(player.health);
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

        
        if (other.gameObject.CompareTag("door2"))
        {
            if (key2 == true)
            {
                other.gameObject.SetActive(false);
                Debug.Log("Door Unlocked");
            }
            else
                Debug.Log("You dont have the key");
        }



        if (other.gameObject.CompareTag("door3"))
        {
            if (key3 == true)
            {
                other.gameObject.SetActive(false);
                Debug.Log("Door Unlocked");
                SceneManager.LoadScene(0);

            }
            else
                Debug.Log("You dont have the key");

        }
        
    }
}
