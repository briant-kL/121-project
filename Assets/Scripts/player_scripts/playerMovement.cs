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

    public float distToGround = 1.0f;
    public bool isDead;


    public Text healthText;



    //inventory
    public GameObject weapon;
    public bool haveWeapon = false;
    public int health;

    //private variables
    private CharacterController playerController;
    private Animator animator;
    private Vector3 velocity;
    private Vector2 movement;
    private Vector3 movement_direction = Vector3.zero;

    private ParticleSystem particles;
    private float _defaultSpeed;

    private float _heavyFrame;

    public bool _lowHealth = false;

    private playerMovement controls;
    private Animator dead;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        controls = GetComponent<playerMovement>();
        _defaultSpeed = speed;
        //_lowHealth = false;
        Debug.Log(animator.GetBool("hasWeapon"));
        //Debug.Log(animator.GetLayerIndex("WK_heavy_infantry_08_attack_B"));
        dead = ragdoll.GetComponent<Animator>();
        isDead = false;

        SetCountText();
        Debug.Log(health);

    }

    // Update is called once per frame
    void Update()
    {


        PlayerMovement();

        LightAttack();
        HeavyAttack();
        Roll();
        SetCountText();
    }


    void SetCountText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "DEAD";
        }
    }


    void LightAttack()
    {

        if (Input.GetMouseButtonDown(0) && haveWeapon == true)
        {
            //animator.SetBool("attacking", true);
            //animator.SetInteger("condition", 4);
            animator.SetTrigger("liteAttack");
            StartCoroutine(liteAttackRoutine());

        }


    }

    void HeavyAttack()
    {

        if (Input.GetMouseButtonDown(1) && haveWeapon == true)
        {
            //animator.SetBool("attacking", true);
            //animator.SetInteger("condition", 4);
            animator.SetTrigger("heavyAttack");
            StartCoroutine(hvyAttackRoutine());

        }



    }


    private int leftTotal;

    void Roll()
    {
        if (Input.GetKeyDown("c"))
        {
            animator.SetTrigger("roll");
            RollRoutine();
        }



    }


    IEnumerator hvyAttackRoutine()
    {
        Debug.Log("heavy Attack");
        _hvyAtk_Hitbox.SetActive(true);
        yield return new WaitForSeconds(1);
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
        //Debug.Log("Rolling");
        yield return new WaitForSeconds(0);
        Debug.Log("done backstep");
    }

    IEnumerator swordRoutine()
    {
        //Debug.Log("Rolling");
        yield return new WaitForSeconds(1);
        Debug.Log("picked up Sword");
        speed = _defaultSpeed;
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


        // Animations


        //Walking Forward
        if (Input.GetKey("w"))
        {
            //Debug.Log(v);
            animator.SetBool("walking", true);
            //animator.SetInteger("condition", 1);

        }

        else if (Input.GetKeyUp("w"))
        {
            animator.SetBool("walking", false);
            //animator.SetInteger("condition", 0);

        }


        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("running", true);
            speed = sprint;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("running", false);
            speed = _defaultSpeed;
        }


        //walkbackwards
        if (Input.GetKey("s"))
        {
            speed = _defaultSpeed / 2;
            //animator.SetBool("walking_backwards", true);
            //Debug.Log(animator.GetBool("walking_backwards"));
            animator.SetInteger("condition", -1);
        }
        else if (Input.GetKeyUp("s"))
        {
            //animator.SetBool("walking_backwards", false);
            speed = _defaultSpeed;
            animator.SetInteger("condition", 0);

        }


        if (Input.GetKey("a"))
        {
            // Debug.Log(v);
            speed = _defaultSpeed;
            animator.SetBool("strafeLeft", true);
            //animator.SetInteger("condition", 1);

        }

        else if (Input.GetKeyUp("a"))
        {

            animator.SetBool("strafeLeft", false);
            //animator.SetInteger("condition", 0);

        }

        if (Input.GetKey("d"))
        {
            // Debug.Log(v);
            speed = _defaultSpeed;
            animator.SetBool("strafeRight", true);
            //animator.SetInteger("condition", -1);

        }

        else if (Input.GetKeyUp("d"))
        {
            animator.SetBool("strafeRight", false);
            //animator.SetInteger("condition", 0);

        }

        /*
        if (Input.GetKeyDown("e"))
        {
            // Debug.Log(v);
            //animator.SetBool("isDead", true);
            Debug.Log("You have Died");
            //gameObject.SetActive(false);

            gameObject.SetActive(false);
            ragdoll.SetActive(true);
          

        }

        */

        if (Input.GetKeyUp("space"))
        {
            animator.SetTrigger("jump");
            velocity.y += Mathf.Sqrt(_jumpheight * -2f * Gravity);
        }




        ////    CHECKS IF DEAD

        if (isDead == true || health <= 0)
        {
            //animator.enabled = false;
            //controls.enabled = false;
            gameObject.SetActive(false);
            ragdoll.SetActive(true);
            
        }







        //Jumping
        //Using Raycast to check Grounded
        //Debug.Log(isGrounded());
        /*
        if (isGrounded() == true)
        {
            //Debug.Log("grounded");
            if (Input.GetKey("space"))
            {
                Debug.Log("jumping");
                velocity.y += Mathf.Sqrt(_jumpheight * -2f * Gravity);
            }

        }
        */
        

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

        if (other.gameObject.CompareTag("weapon"))
        {
            Debug.Log("You have gotten a weapon");
            weapon.SetActive(true);
            other.gameObject.SetActive(false);
            haveWeapon = true;
            animator.SetBool("hasWeapon", true);
            Debug.Log(animator.GetBool("hasWeapon"));

        }

        

        

    }

    

    

}
