using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
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
        //Must change the name the Projectle
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Hello");
            //Remove the hider object
            if (transform.childCount > 0) {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
        

    }
}
