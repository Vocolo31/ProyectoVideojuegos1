using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float startSpeed;
    public float JumpHeight;
    public Rigidbody2D rb;
    public bool isGrounded;
    public bool isCrouched;
    public float x;
    public LayerMask ground;
    public float longitudRaycast;

    public Vector3 initialPosition;
    public Vector3 initialScale;

    public int DeathCounter;
    public TextMeshProUGUI TriesText;

    private Vector3 crouchScale;
    public float startingGravity;
    public bool IsCrouched;
    public bool IsSprinting;
    public float startJumpingHeight;
    public Animator animator;
    public BoxCollider2D boxCollider;
    public PolygonCollider2D polygonCollider;
    public Spikes spikes;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
        //TriesCounter();
        crouchScale = new Vector3(initialScale.x, initialScale.y / 2, initialScale.z);
        startingGravity = rb.gravityScale;
        startSpeed = playerSpeed;
        startJumpingHeight = JumpHeight;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        
        Grounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        


        rb.velocity = new Vector2(x * playerSpeed, rb.velocity.y);


        Crouch();
        HeavyDrop();
        Run();
        //JumpBoost();
    }
    
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        playerSpeed = startSpeed;
        transform.localScale = initialScale;
    }

    private void OnDrawGizmos()
    {
        //color del raycast
        Gizmos.color = Color.red;

        // posicion del raycast y direccion del mismo
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

    public void Grounded()
    {
        // Raycast hacia el suelo 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, ground);

        isGrounded = hit.collider != null;
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Void"))
        {
            Respawn();
            DeathCounter++;
            //TriesCounter();
            playerSpeed = startSpeed;
        }
    }

    void Respawn()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
    }

    /*void TriesCounter()
    {
        TriesText.text = "Deaths: " + DeathCounter.ToString();
    }*/

    void HeavyDrop()
    {
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = startingGravity * 3;
            if (!IsCrouched)
            {
                animator.SetBool("Crawled", true);
                boxCollider.enabled = true;
                polygonCollider.enabled = false;
            }
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = startingGravity;
            if (!IsCrouched)
            {
                animator.SetBool("Crawled", false);
                boxCollider.enabled = false;
                polygonCollider.enabled = true;
            }
        }


    }

    void Run()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.LeftShift) && !IsCrouched)
        {
            playerSpeed = playerSpeed * 1.7f;
            IsSprinting = true;
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.LeftShift) && !IsCrouched)
        {
            playerSpeed = startSpeed;
            IsSprinting = false;
        }


    }

    void Crouch()
    {
        if (isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            if (!IsCrouched) // Solo cambia si no estaba ya agachado
            {
                IsCrouched = true;
                animator.SetBool("Crawled", true);
                boxCollider.enabled = true;
                polygonCollider.enabled = false;
                Debug.Log("Agachado 1");
            }
        }
        else if (IsCrouched)
        {
            IsCrouched = false;
            animator.SetBool("Crawled", false);
            boxCollider.enabled = false;
            polygonCollider.enabled = true;
            Debug.Log("Agachado 2");
        }
    }

    /*void JumpBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (JumpHeight >= startJumpingHeight * 1.6 && Isgrounded)
            {
                Jump();
                JumpHeight = startJumpingHeight;
            }

            else if (JumpHeight <= startJumpingHeight * 1.6 && Isgrounded)
            {
                JumpHeight = JumpHeight + 0.1f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
            JumpHeight = startJumpingHeight;
        }
    }*/
}
