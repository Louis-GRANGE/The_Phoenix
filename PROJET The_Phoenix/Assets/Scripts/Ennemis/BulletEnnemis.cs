using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemis : MonoBehaviour
{
    Animator Explosion;
    public bool explode = false;
    Transform bullet;
    int lvl;
    public bool setlife = false;
    int rlife;

    private void Update()
    {
        rlife = GameObject.Find("DifficultyMenu").GetComponent<Difficulties>().rlife;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerInventory>().RemoveLife(rlife);
        if (collision.tag == "Player" || collision.tag == "Ground")
        {
            Explosion = GetComponent<Animator>();
            explode = true;
            Explosion.SetBool("Explode", true);
            Destroy(gameObject, 1);
        }
    }
}
