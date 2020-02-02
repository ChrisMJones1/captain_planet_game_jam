using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderController : MonoBehaviour
{
    //Parent gameobject that is a Obstacle
    public GameObject parentObject;
    private float sleepTime;
    private bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(parentObject.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), true);
        sleepTime = 0;
        startTimer = false;
        parentObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        sleepTime += Time.deltaTime;
        if (startTimer && sleepTime > 1.0f) {
            Debug.Log("Add");
            parentObject.AddComponent<Rigidbody2D>();
            parentObject.AddComponent<BoxCollider2D>();
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<BoxCollider2D>();
            parentObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            startTimer = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !parentObject.GetComponent<ObstacleController>().repaired)
        {
            Debug.Log("Destroy");
            Destroy(parentObject.GetComponent<Rigidbody2D>());
            Destroy(parentObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            sleepTime = 0;
            startTimer = true;
        }
    }

    //Fix code due to when destroy the oncollision will not work anymore
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Add");
        if (collision.gameObject.tag == "Player" && !parentObject.GetComponent<ObstacleController>().repaired)
        {
            parentObject.AddComponent<Rigidbody2D>();
            parentObject.AddComponent<BoxCollider2D>();
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<BoxCollider2D>();
        }
    }
}
