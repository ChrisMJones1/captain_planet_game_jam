using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {
    Bridge,
    Gate
}

public class ObstacleController : MonoBehaviour
{
    public ObstacleType obstacleType;
    public bool repaired;

    // Start is called before the first frame update
    void Start()
    {
        repaired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (obstacleType == ObstacleType.Bridge)
        {
            if (collision.gameObject.tag == "Projectle")
            {
                //Remove the hider object
                if (transform.childCount > 0)
                {
                    Destroy(transform.GetChild(0).gameObject);
                    repaired = true;
                }
            }
            else if (collision.gameObject.tag == "Player" && !repaired)
            {
                Destroy(this.GetComponent<Rigidbody2D>());
                Destroy(this.GetComponent<BoxCollider2D>());
            }
        }
        else if (obstacleType == ObstacleType.Gate)
        {
            if (collision.gameObject.tag == "Projectle")
            {
                //Remove the hider object
                if (transform.childCount > 0)
                {
                    Destroy(transform.GetChild(0).gameObject);
                    Destroy(this.GetComponent<BoxCollider2D>());
                    repaired = true;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (obstacleType == ObstacleType.Bridge)
        {
            if (collision.gameObject.tag == "Player" && !repaired)
            {
                this.gameObject.AddComponent<Rigidbody2D>();
                this.gameObject.AddComponent<BoxCollider2D>();
            }
        }
    }

}
