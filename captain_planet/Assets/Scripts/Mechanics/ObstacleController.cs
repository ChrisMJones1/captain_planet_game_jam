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
    public Canvas gameUI;

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
            if (collision.gameObject.tag == "projectile")
            {
                //Remove the hider object
                if (transform.childCount > 0)
                {
                    gameUI.GetComponent<GameUIController>().UpdateScore(100);
                    Destroy(transform.GetChild(0).gameObject);
                    repaired = true;
                }
            }
        }
        else if (obstacleType == ObstacleType.Gate)
        {
            if (collision.gameObject.tag == "projectile")
            {
                //Remove the hider object
                if (transform.childCount > 0)
                {
                    gameUI.GetComponent<GameUIController>().UpdateScore(100);
                    Destroy(transform.GetChild(0).gameObject);
                    Destroy(this.GetComponent<Rigidbody2D>());
                    Destroy(this.GetComponent<BoxCollider2D>());
                    repaired = true;
                }
            }
        }
    }
}
