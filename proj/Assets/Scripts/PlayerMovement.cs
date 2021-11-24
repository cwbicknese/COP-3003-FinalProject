using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class contains the actions and movements the player can perform
// it is a subclass of CharacterStats

// For movement and direction, referenced:
// Brackeys - Third Person Movement in Unity
// https://www.youtube.com/watch?v=4HpC--2iowE

// For gravity and jumping, referenced:
// Brackeys - First Person Movement in Unity - FPS Controller
// https://youtu.be/_QajrabyTJc?t=898

public class PlayerMovement : CharacterStats
{
    //movement fields
    public CharacterController controller;
    public Transform cam;

    public float moveSpeed = 25f;
    public float turnSmoothTime = .1f;
    public float turnSmoothVelocity;

    //jumping and gravity fields
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 6f;
    public float gravity = -9.81f*3;

    //gliding fields
    public float airTime = 0f;
    public float gliding = 1f;
    public GameObject paraglider;

    public float fireMpCost = 10f;
    public float iceMpCost = 20f;

    // Update is called once per frame
    void Update()
    {
        //checks if the player is colliding with ground beneath them
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //stops gravity from continuously increasing if player is grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown("t"))
        {

            attack.incValue();
            Debug.Log("Attack: " + attack);

        }

        //paraglide
        if (!isGrounded) //counts time in air so that you don't start gliding immediately from the jump
        {
            airTime++;
        }
        else
        {
            airTime = 0f;
        }
        if (gliding == 1f && Input.GetButtonDown("Jump")) // when glide starts, halves downward velocity
        {
            velocity.y /= 2f;
        }
        if (Input.GetButtonDown("Jump") && !isGrounded && airTime > 30f) //starts gliding only after player has been in the air for 30 frames
        {
            gliding = 3f;
            paraglider.SetActive(true);
        }
        else if (!Input.GetButton("Jump")) // not gliding
        {
            gliding = 1f;
            paraglider.SetActive(false);
        }

        //horizontal movement and direction https://www.youtube.com/watch?v=4HpC--2iowE
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= .1f)
        {
            if (gameObject.GetComponent<GeneralFunctions>().able)   //checks if player is able to move
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (isGrounded)
                {
                    controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
                }
                else if (gliding == 1f)
                {
                    controller.Move(moveDir.normalized * (moveSpeed*.75f) * Time.deltaTime);
                }
                else
                {
                    controller.Move(moveDir.normalized * moveSpeed * gliding/2f * Time.deltaTime);
                }
            }
        }

        //vertical movement https://www.youtube.com/watch?v=_QajrabyTJc
        if (Input.GetButtonDown("Jump") && isGrounded && gameObject.GetComponent<GeneralFunctions>().able)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity/gliding * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //shoot fireball
        if (Input.GetKeyDown("f"))
        {
            if (mp >= fireMpCost && gameObject.GetComponent<GeneralFunctions>().able)
            {
                gameObject.GetComponent<ProjectileShooter>().shootProjectile(attack.getValue(), 15f, 120);
                mp -= fireMpCost;
            }
        }

        //cast ice
        if (Input.GetKeyDown("i"))
        {
            if (mp >= iceMpCost && gameObject.GetComponent<GeneralFunctions>().able)
            {
                gameObject.GetComponent<ProjectileShooter>().castIce(attack.getValue(), 200);
                mp -= iceMpCost;
            }
        }

    }

    //collision
    void OnTriggerEnter(Collider other)
    {
        //checkpoint
        if (other.gameObject.CompareTag("checkpoint"))
        {
            hp = hpMax; // restore all hp
            mp = mpMax; // restore all mp
        }

        //gold
        if (other.gameObject.CompareTag("gold"))
        {
            gold += pickUpGold<int>(5);
            Destroy(other.gameObject);
        }
    }

    // this function is a generic (same thing as a template in C++)
    // it can use any type in place of T
    // generics are good for when different types might be needed for a function, and can be used as an alternative to a bunch of overloaded functions
    // they can also pass classes as a type
    // in this instance however, I am only using integers when calling the function
    public T pickUpGold<T>(T goldAmount)
    {
        return goldAmount;
    }





}
