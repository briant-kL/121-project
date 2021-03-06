﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pCamera : MonoBehaviour
{
    //public float maxDistance;
    public float sensitivity;
    public GameObject target;
    public GameObject player;
    public float minDistance;

    private float x;
    private float y;

    private playerMovement controls;

    /*
    private RaycastHit ray;
    public Vector3 clipCheckOffset = new Vector3(0, 1, 0);
    */

    // Start is called before the first frame update
    void Start()
    {
        controls = player.GetComponent<playerMovement>();
        //Debug.Log(controls.isDead);
    }

    // lateupdate Best for camera and procedural animations

    void LateUpdate()
    {
        float h = sensitivity * Input.GetAxis("Mouse X");
        float v = sensitivity * -Input.GetAxis("Mouse Y");

        x += Input.GetAxis("Mouse X") * sensitivity;
        y += Input.GetAxis("Mouse Y") * -sensitivity;

        Quaternion rotation = Quaternion.Euler(2, x, 0);
        Vector3 position = rotation * new Vector3(0f, 0f, -minDistance) + player.transform.position;
        Vector3 position2 = rotation * new Vector3(0f, 0f, -minDistance) + target.transform.position;
        ///Vector3 position3 = rotation * new Vector3(0f, 0f, -minDistance) + target2.transform.position;
        transform.rotation = rotation;

        if(controls.isDead != true)
        {
            transform.position = position2;
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            player.transform.Rotate(0, h, 0);
            target.transform.Rotate(0, h, 0);
            //target2.transform.Rotate(0, h, 0);
        }





    }



    void Update()
    {

         

        
    }
}
