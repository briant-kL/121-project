using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{

    public GameObject _player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _player.transform.position;
        transform.rotation = _player.transform.rotation;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = false;
    }
}
