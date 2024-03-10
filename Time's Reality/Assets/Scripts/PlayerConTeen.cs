using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConTeen : MonoBehaviour
{
    float moveSpeed = 18f;
    float rotationSpeed = 130f;
    float jumpForce = 9f;

    float horizontalInput;
    float verticalInput;
    bool isRunning = false;
    bool isAttacking = false;
    bool isGrounded = false;


    Rigidbody rb;
    Animator anim;

    public GameObject enemy;

    float attackCooldown = 2f; // Cooldown time in seconds between attacks
    float lastAttackTime = -2f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = Vector2.zero;

    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        Vector3 movement = (horizontalInput * transform.right + verticalInput * transform.forward) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (horizontalInput != 0)
        {
            float rotationAmount = rotationSpeed * horizontalInput * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

        // When I press shift, the character will run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 25f;
            isRunning = true;
        }
        else
        {
            isRunning = false;
            moveSpeed = 18f;
        }

        //get distance between the player and the enemy
        float distance = Vector3.Distance(transform.position, enemy.transform.position);




        //if we press the left click, the character will attack
        if (Input.GetMouseButton(0) )
        {
            isAttacking = true;
            
        }
        else
        {
            isAttacking = false;
        }

        
        

        //when we press space, the character will jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
            isGrounded = false;
        }


        anim.SetFloat("vertical", verticalInput);
        anim.SetFloat("horizontal", horizontalInput);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isGrounded", isGrounded);



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if you collide with the enemy, the enemy will take damage
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isAttacking && Time.time - lastAttackTime >= attackCooldown)
            {
                isAttacking = false;
                print("Enemy hit");
                enemy.GetComponent<Boss>().health -= 50;
                lastAttackTime = Time.time;
            }
        }
    }
}
