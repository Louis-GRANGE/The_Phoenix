using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    private PlayerInventory player;
    int lvl;
    public bool setlife = false;
    int rlife;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }
    void Update()
    {
        rlife = GameObject.Find("DifficultyMenu").GetComponent<Difficulties>().rlife;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            player.RemoveLife(rlife + 1);
            StartCoroutine(player.Knockback(0.02f, -3000, player.transform.position));
        }
    }
}
