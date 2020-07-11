using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            coll.GetComponent<PlayerInventory>().AddLife(1);
            Destroy(gameObject);
        }
    }
}
