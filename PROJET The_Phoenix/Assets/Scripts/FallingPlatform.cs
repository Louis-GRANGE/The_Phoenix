using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D rigid;
    public float fallDelay;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
            StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rigid.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
