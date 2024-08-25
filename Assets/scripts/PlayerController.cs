using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public float flyup;
    //public float flydown;
    private bool start;

    public float moveSpeed;
    float xDirection;

    public GameObject GameController;

    Rigidbody2D myBody;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        myBody = GetComponent<Rigidbody2D>();
        start = false;
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Vertical");
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        transform.position = transform.position + new Vector3(0, moveStep, 0);

        if (start == false)
        {
            start = true;
            GameController.GetComponent<pipeGenerator>().enable = true;
        }
    }

    // Update is called once per frame
  /*  void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (start == false)
            {
                start = true;
                GameController.GetComponent<pipeGenerator>().enable = true;
            }
            flaneMoveUp();
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (start == false)
            {
                start = true;
                GameController.GetComponent<pipeGenerator>().enable = true;
            }
            flaneMoveDown();
        }

    }
    private void flaneMoveUp()
    {
        myBody.velocity = Vector2.up * flyup;


    }

    private void flaneMoveDown()
    {
        myBody.velocity = Vector2.down * flydown;
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            gc.SetGameoverState(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       /* if (collider.CompareTag("wall"))
        {
            gc.SetGameoverState(true);
            Destroy(gameObject);

        }*/
        if (collider.gameObject.CompareTag("space"))
        {
            gc.IncrementScore();
        }
    }
}
