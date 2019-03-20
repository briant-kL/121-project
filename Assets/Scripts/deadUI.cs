using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadUI : MonoBehaviour
{
    public GameObject player;
    private playerMovement hp;
    public GameObject retryButton;
    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        hp = player.GetComponent<playerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hp.health <= 0)
        {
            quitButton.SetActive(true);
            retryButton.SetActive(true);
        }
    }
}
