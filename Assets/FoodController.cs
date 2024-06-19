using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public CharacterController control;

    public int fillAmount;
    public float moveSpeed;
    public static float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 3;
        control = gameObject.GetComponent<CharacterController>();
        StartCoroutine(FoodLifetime());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0.01f);
        moveDirection.Normalize();

        control.Move(moveDirection * moveSpeed / 50 * Time.deltaTime);

    }

    IEnumerator FoodLifetime()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.gameObject.CompareTag("Animal"))
        {
            Debug.Log("nabrak");
            collision.gameObject.GetComponent<EnemyController>().fillAmount += fillAmount;
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Debug.Log(hit.gameObject);
    }
}
