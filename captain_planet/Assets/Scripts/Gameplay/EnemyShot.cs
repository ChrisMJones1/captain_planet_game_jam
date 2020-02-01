using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class EnemyShot : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {

                Debug.Log("hit");
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

        }
    }
}