using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        // Collision other => containing information about the other object, this gameobject did hit. 
        // Check https://docs.unity3d.com/ScriptReference/Collision.html
        // Whenever a gameobject with this script enter a valid collision it will destroy itself.
        Destroy(gameObject);
    }
}
