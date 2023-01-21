using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public Collider2D myCollider2D;
    public bool birdIsAlive = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myCollider2D = GameObject.FindGameObjectWithTag("Collider2D").GetComponent<Collider2D>();
        animator = GameObject.FindGameObjectWithTag("winganimation").GetComponent<Animator>();

        animator.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (myRigidbody.velocity.y > 0)
        {
            animator.speed = 1;
        }
        else
        {
            animator.speed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == myCollider2D)
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }

}
