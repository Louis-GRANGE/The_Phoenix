using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLine : MonoBehaviour
{
    Finish EndGame;
    public bool Out = false;
    void OnTriggerExit2D(Collider2D coll)
    {
        EndGame = FindObjectOfType<Finish>();
        if (coll.tag == "Player") // Nous recuperons le tag de l'objet en colision
        {
            Out = true;
            EndGame.MakeDead();
        }
        else
            Destroy(coll.transform.root.gameObject);
    }
}