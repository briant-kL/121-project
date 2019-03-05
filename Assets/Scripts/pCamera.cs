using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // lateupdate Best for camera and procedural animations

    void LateUpdate()
    {
        float h = sensitivity * Input.GetAxis("Mouse X");
        float v = sensitivity * -Input.GetAxis("Mouse Y");

        x += Input.GetAxis("Mouse X") * sensitivity;
        y += Input.GetAxis("Mouse Y") * -sensitivity;

        Quaternion rotation = Quaternion.Euler(0, x, 0);
        Vector3 position = rotation * new Vector3(0f, 0f, -minDistance) + player.transform.position;
        Vector3 position2 = rotation * new Vector3(0f, 0f, -minDistance) + target.transform.position;
        transform.rotation = rotation;
        transform.position = position2;
        if (Input.GetAxis("Mouse X") != 0)
        {
            player.transform.Rotate(0, h, 0);
            target.transform.Rotate(0, h, 0);
        }
    }



    void Update()
    {

         

        
    }
}
