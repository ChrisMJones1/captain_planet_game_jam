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

    // Start is called before the first frame update
    void Start()
    {
        
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
                }
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
                }
            }
        }
        

         
        

    }
}
