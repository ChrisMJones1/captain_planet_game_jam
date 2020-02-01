using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    public static int zAxisPos = 0; //Static because other scripts may need to get this.
    private float yAxisPos = 0;
    public float xAxisBoundry = 7.5f;
    public float speed = 10f;
    public GameObject Triangle;

    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        this.gameObject.transform.position = new Vector3(mouse.x, mouse.y, zAxisPos);

        if (Input.GetButtonDown("Fire1"))
        {//when the left mouse button is clicked

            print("1");//print a message to act as a debug

            FireBullet();//look for and use the fire bullet operation

        }

    }

    public void FireBullet()
    {
        Vector3 playervector = player.transform.position;
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        Vector3 shootvector = mouse - playervector;
        shootvector.Normalize();
        shootvector *= 200;

        //playervector = Camera.main.ScreenToWorldPoint(playervector);

        //Clone of the bullet
        GameObject Clone;

        player = GameObject.FindWithTag("NewPlayer");
        Debug.Log(player.transform.position.x);  

        //spawning the bullet at position
        Clone = (Instantiate(Triangle, new Vector3(player.transform.position.x, player.transform.position.y, 1), transform.rotation)) as GameObject;
        Debug.Log("Bullet is found");
        Vector3 cursorangle = new Vector3(mouse.x, mouse.y, 1);
        Vector3 playerangle = new Vector3(player.transform.position.x, player.transform.position.y, 1);

        float angle = Vector3.Angle(playerangle, cursorangle);

        
      
        //add force to the spawned objected
        Clone.GetComponent<Rigidbody2D>().gravityScale = 0;
        Clone.GetComponent<Rigidbody2D>().AddForce(shootvector);
    

    }
}
