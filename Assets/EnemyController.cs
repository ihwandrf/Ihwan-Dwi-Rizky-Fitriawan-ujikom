using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameController gameController;

    public int fillAmount;
    public int fillMax;

    public float moveSpeed;

    public int scoreWorth;

    public CharacterController control;

    public Transform player;

    public GameObject fillMeter;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        control = gameObject.GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        /*Instantiate(fillMeter, transform.position, Quaternion.identity);
        fillMeter.GetComponent<FillMeterController>().hungerFullAmount = fillMax;*/
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, -0.01f);
        moveDirection.Normalize();

        control.Move(moveDirection * moveSpeed/50 * Time.deltaTime);

        fillMeter.GetComponent<FillMeterController>().hungerFillAmount = fillAmount;

        if (transform.position.z <= player.position.z)
        {
            Destroy(gameObject);
        }

        if(fillAmount >= fillMax)
        {
            Destroy(gameObject);
            gameController.scoreAmount += scoreWorth;
            gameController.PlaySFXDestroy();
        }
    }
}
