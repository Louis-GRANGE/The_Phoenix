using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumps : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            coll.GetComponent<PlayerController>().canDoubleJumps = true;
            Destroy(gameObject);
    }
}
