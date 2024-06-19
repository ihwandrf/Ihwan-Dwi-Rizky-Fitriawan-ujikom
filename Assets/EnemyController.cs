using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int fillAmount;
    public int fillMax;

    public float moveSpeed;

    public CharacterController control;


    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, -1f);

        control.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
