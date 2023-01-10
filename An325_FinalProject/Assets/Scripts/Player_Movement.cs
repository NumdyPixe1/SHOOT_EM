using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player_Movement : MonoBehaviour
{
    //Joystick Movement
    public FloatingJoystick floatingJoystick;
    public float horizontalMove = 0f;

    //public ParticleSystem dust;
    //[SerializeField] private bool grounded = true;

    //Jump
    public float gravityScale = 5;
    public float fallingGravityScale = 20;
    [SerializeField] private float jumpSpeed = 20f;
    //[SerializeField] private bool jump = false;
    [SerializeField] private float jumpRate = 0.7f;
    [SerializeField] private float nextJumpTime;//

    [SerializeField] private float speed = 10f;
    public GameObject fireprefab;
    public Transform firePoint;
    Animator animator;
    Rigidbody2D rb;
    public AudioSource[] audioSource;
    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PressFire();
        PressJump();
        //Joystick Movement
        if (floatingJoystick.Horizontal != 0)
        {
            horizontalMove = floatingJoystick.Horizontal * speed;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        }

        // animator.SetBool("Isgrounded", true);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Walk
        if (horizontalMove < -0.1f)//ไปขวา
        {
            animator.SetBool("IsWalk", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);

        }
        else if (horizontalMove > 0.1f)//ไปซ้าย
        {
            animator.SetBool("IsWalk", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);

        }
        if (horizontalMove == 0f)
        {
            animator.SetBool("IsWalk", false);
        }
    }

    public void Jump()
    {
        //Jump
        if (Time.time >= nextJumpTime)
        {
            audioSource[0].Play();
            rb.velocity = Vector2.up * jumpSpeed;//โดด
                                                 //jump = true;
                                                 // crouch = false;
            nextJumpTime = Time.time + jumpRate;
            animator.SetBool("IsJump", true);
            StartCoroutine(secondJump(0.5f));
            if (rb.velocity.y >= 0)//ระหว่างโดด = velocity มากกว่าหรือเท่ากับ 0
            {
                rb.gravityScale = gravityScale;
            }
            else if (rb.velocity.y < 0)//ระหว่างหล่น
            {
                rb.gravityScale = fallingGravityScale;
            }
        }
    }
    private void PressJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= nextJumpTime)
            {
                audioSource[0].Play();
                rb.velocity = Vector2.up * jumpSpeed;//โดด
                                                     //jump = true;
                                                     // crouch = false;
                nextJumpTime = Time.time + jumpRate;
                animator.SetBool("IsJump", true);
                StartCoroutine(secondJump(0.5f));
                if (rb.velocity.y >= 0)//ระหว่างโดด = velocity มากกว่าหรือเท่ากับ 0
                {
                    rb.gravityScale = gravityScale;
                }
                else if (rb.velocity.y < 0)//ระหว่างหล่น
                {
                    rb.gravityScale = fallingGravityScale;
                }
            }
        }
    }
    IEnumerator secondJump(float secondJump)
    {
        yield return new WaitForSeconds(secondJump);
        //this.GetComponent<Enemy_Movement>().enabled = true;
        animator.SetBool("IsJump", false);
    }

    public void Fire()
    {
        audioSource[1].Play();
        Instantiate(fireprefab, firePoint.position, firePoint.rotation);
        animator.SetBool("IsFire", true);
        StartCoroutine(secondAttack(0.2f));
    }
    private void PressFire()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource[1].Play();
            Instantiate(fireprefab, firePoint.position, firePoint.rotation);
            animator.SetBool("IsFire", true);
            StartCoroutine(secondAttack(0.2f));
        }

    }

    IEnumerator secondAttack(float secondAttack)
    {
        yield return new WaitForSeconds(secondAttack);
        animator.SetBool("IsFire", false);
    }





}
































