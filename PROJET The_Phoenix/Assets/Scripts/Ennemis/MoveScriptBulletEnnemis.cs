using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptBulletEnnemis : MonoBehaviour {
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(1, 0);//-1,0
    private Vector2 movement;
    private bool moveBullet;

    void Update()
    {
        moveBullet = GetComponent<BulletEnnemis>().explode;
        if (moveBullet == false)
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        else
            movement = new Vector2(0, 0);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
