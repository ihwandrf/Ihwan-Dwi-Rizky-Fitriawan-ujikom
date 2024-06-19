using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform player;
    public CharacterController control;
    public Animator animator;

    public GameObject foodPrefab;

    public bool isGrounded;
    public Vector3 velocity;
    public float gravityValue = -9.81f;


    public float moveSpeed = 350;
    public SFXController sfxController;

    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        sfxController = GameObject.FindGameObjectWithTag("SFX Controller").GetComponent<SFXController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        moveDirection.Normalize();

        control.Move(moveDirection * moveSpeed * Time.deltaTime);


        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f);
        velocity.y += gravityValue * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("isMovingRight");
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("isMovingLeft");
        }
        else
        {
            animator.SetTrigger("isIdle");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            ThrowFood();
        }

    }

    public void ThrowFood()
    {
        animator.SetTrigger("isThrowing");
        Instantiate(foodPrefab, transform.position + new Vector3(0,2,3), Quaternion.identity);
        sfxController.Throw();
    }
}
