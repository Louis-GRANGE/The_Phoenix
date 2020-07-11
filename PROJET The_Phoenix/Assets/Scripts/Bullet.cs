using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float targetTime = 0.2f;
    Animator Explosion;
    public bool explode = false;
    bool canexplode = false;
    Transform bullet;
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canexplode = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Ennemis" || collision.tag == "Ground")
        {
            Explosion = GetComponent<Animator>();
            //if (canexplode == true)
                explode = true;
                Explosion.SetBool("Explode", true);
                Destroy(gameObject, 1);
        }
    }
}
