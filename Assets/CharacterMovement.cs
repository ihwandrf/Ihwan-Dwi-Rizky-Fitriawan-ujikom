using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform player;
    public CharacterController control;
    public Animator animator;


    public bool isGrounded;


    public float moveSpeed = 350;
    public 

    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);

        control.Move(moveDirection * moveSpeed * Time.deltaTime);

        Debug.Log(moveDirection.x);

        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f);



        if(moveDirection.x >= 0)
        {
            animator.SetTrigger("isMovingRight");
        }
        else if(moveDirection.x <= 0)
        {
            animator.SetTrigger("isMovingLeft");
        }
        else if(moveDirection == null)
        {
            animator.SetTrigger("isIdle");
        }

    }
}
