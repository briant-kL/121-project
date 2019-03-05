using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    


    //Public variables
    public float speed;
    public float Gravity = -9.8f;
    public Vector3 drag;
    public float sprint;
    public float _jumpheight;
    public GameObject ragdoll;
    public GameObject _liteAtk_Hitbox;
    public GameObject _hvyAtk_Hitbox;
    public int health;

    public float distToGround = 1.0f;




    //inventory
    public GameObject weapon;
    public bool haveWeapon = false;
    public bool key1 = false;
    public bool key2 = false;
    public bool key3 = false;

    //private variables
    private CharacterController playerController;
    private Animator animator;
    private Vector3 velocity;
    private Vector2 movement;
    private Vector3 movement_direction = Vector3.zero;
    
    private ParticleSystem particles;
    private float _defaultSpeed;

    private float _heavyFrame;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        
        _defaultSpeed = speed;


        //Debug.Log(animator.GetLayerIndex("WK_heavy_infantry_08_attack_B"));
        

    }

    // Update is called once per frame
    void Update()
    {
        

        PlayerMovement();

        LightAttack();
        HeavyAttack();

       
        
        Roll();

    }




    void LightAttack()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetBool("attacking", true);
            //animator.SetInteger("condition", 4);

            StartCoroutine(liteAttackRoutine());

        }

        
    }

    void HeavyAttack()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //animator.SetBool("attacking", true);
            //animator.SetInteger("condition", 4);

            StartCoroutine(hvyAttackRoutine());

        }
        


    }


    private int leftTotal;

    void Roll()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = new Vector2(h, v);
        //These lines of code change the rotation of the player object so that it can walk in the right the direction according to the orientation of the camera
        Vector3 moveInput = transform.forward * movement.y + transform.right * movement.x;
        movement_direction.x = moveInput.x * speed;
        movement_direction.z = moveInput.z * speed;
        playerController.Move(movement_direction * Time.deltaTime);



        if (Input.GetKeyDown("c"))
        {
            StartCoroutine(RollRoutine());
        }



    }


    IEnumerator hvyAttackRoutine()
    {
        Debug.Log("heavy Attack");
        _hvyAtk_Hitbox.SetActive(true);
        yield return new WaitForSeconds(2);
        _hvyAtk_Hitbox.SetActive(false);
        Debug.Log("done");
    }

    IEnumerator liteAttackRoutine()
    {
        Debug.Log("lite Attack");
        _liteAtk_Hitbox.SetActive(true);
        yield return new WaitForSeconds(1);
        _liteAtk_Hitbox.SetActive(false);
        Debug.Log("done");
    }



    IEnumerator RollRoutine()
    {
        Debug.Log("Rolling");
        yield return new WaitForSeconds(1);
        Debug.Log("done Rolling");
    }



    void PlayerMovement()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = new Vector2(h, v);
        //These lines of code change the rotation of the player object so that it can walk in the right the direction according to the orientation of the camera
        Vector3 moveInput = transform.forward * movement.y + transform.right * movement.x;
        movement_direction.x = moveInput.x * speed;
        movement_direction.z = moveInput.z * speed;
        playerController.Move(movement_direction * Time.deltaTime);

        
        //Walking Animations


        //Walking Forward
        if (Input.GetKey("w"))
        {
            //Debug.Log(v);
            //animator.SetBool("walking", true);
            //animator.SetInteger("condition", 1);

        }

        else if (Input.GetKeyUp("w"))
        {
            //animator.SetBool("walking", false);
            //animator.SetInteger("condition", 0);

        }

   
        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) )
        {
            //animator.SetBool("running", true);
            speed = sprint;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //animator.SetBool("running", false);
            speed = _defaultSpeed;
        }


        //walkbackwards
        if (Input.GetKey("s"))
        {
            //Debug.Log(v);
            //animator.SetBool("backwalking", true);

            //animator.SetInteger("condition", -1);
        }
        else if (Input.GetKeyUp("s"))
        {
            //animator.SetBool("backwalking", false);

            //animator.SetInteger("condition", 0);

        }


        if (Input.GetKey("a"))
        {
           // Debug.Log(v);

            //animator.SetInteger("condition", 1);

        }

        else if (Input.GetKeyUp("a"))
        {

            //animator.SetInteger("condition", 0);

        }

        if (Input.GetKey("d"))
        {
           // Debug.Log(v);

            //animator.SetInteger("condition", -1);

        }

        else if (Input.GetKeyUp("d"))
        {

            //animator.SetInteger("condition", 0);

        }



        if (Input.GetKeyDown("c"))
        {
            Debug.Log("Rolling");
            movement_direction.x = 10;
            //RollRoutine();
        }

        //Jumping
        //Using Raycast to check Grounded
        //Debug.Log(isGrounded());

        if (isGrounded() == true)
        {
            //Debug.Log("grounded");
            if (Input.GetKey("space"))
            {
                Debug.Log("jumping");
                velocity.y += Mathf.Sqrt(_jumpheight * -2f * Gravity);
            }

        }


        //Gravity and Drag physics
        velocity.y += Gravity * Time.deltaTime;
        velocity.x /= 1 + drag.x * Time.deltaTime;
        velocity.y /= 1 + drag.y * Time.deltaTime;
        velocity.z /= 1 + drag.z * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);

    }

    


    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill_env"))
        {
            //gameObject.SetActive(false);
            Debug.Log("You have been hit");
            health = health - 1;
            Debug.Log(health);
            //ragdoll.SetActive(true);
        }



        //Inventory collisions

        if (other.gameObject.CompareTag("weapon"))
        {
            Debug.Log("You have gotten a weapon");
            weapon.SetActive(true);
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("healthPack"))
        {
            Debug.Log("You gotten some health");
            health = health + 1;
            Debug.Log(health);
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("key1"))
        {
            Debug.Log("key1 acquired");
            key1 = true;
            other.gameObject.SetActive(false);

        }

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

    }

    

    

}
