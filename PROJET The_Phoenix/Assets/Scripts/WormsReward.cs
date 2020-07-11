using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormsReward : MonoBehaviour
{
    public GameObject Worms;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") // Nous recuperons le tag de l'objet en colision
        { 
            Destroy(gameObject.transform.root.gameObject); // On detruit la hierarchie complete de l'objet
            Destroy(GetComponent<Rigidbody>());
            coll.gameObject.GetComponent<PlayerInventory>().AddWorms();
            //Instantiate(Worms, transform.position, Quaternion.identity); // transform.position nous permet de recuperer la position de l'objet actuel
        }
    }
}
