using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour
{
    public GameObject pinePrefabs;
    public GameObject pine;
    private float countdown;
    public float timeDuration;
    public bool enable;// cho phep sinh ra ong khi di chuyen may bay
    // Start is called before the first frame update
 private void Awake()
    {
        countdown = timeDuration;
        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable == true)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                Instantiate(pinePrefabs, new Vector3(9, Random.Range(-3.7f, 1.7f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "death")
        {
            Destroy(gameObject);
        }
    }
}
