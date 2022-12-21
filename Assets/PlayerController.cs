using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    Vector2 movement;

    float currentDirection;

    SpriteRenderer[] rendererChilds;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        rendererChilds = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
        float WalkDir = GetDirection();
        if (movement != Vector2.zero)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("Walking_Dir", WalkDir);
        } else
        {
            animator.SetBool("Walking", false);
        }

        //Player Flips when walk left
        if (WalkDir == 3)
            FlipAll(true);
        else
            FlipAll(false);
    }


    public float GetDirection()
    {

        if(movement.x >= 1)
            currentDirection = 2;
        else if(movement.x < 0)
            currentDirection = 3;

        if (movement.y >= 1)
            currentDirection = 1;
        else if(movement.y < 0)
            currentDirection = 0;
        
        return currentDirection;
    }

    void FlipAll(bool cond)
    {
        spriteRenderer.flipX = cond;
        foreach (SpriteRenderer sprR in rendererChilds)
        {
            sprR.flipX = cond;
        }
    }
}
