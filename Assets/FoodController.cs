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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Animal"))
        {
            Debug.Log("nabrak");
            other.gameObject.GetComponent<EnemyController>().fillAmount += fillAmount;
        }
    }
}
