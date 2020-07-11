using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Text endGameUIText;
    public string endTextWin = "You Win!!";
    public string endTextLoose = "GAME OVER";
    public int nlife;
    public int nWorms;
    int intermediaire;
    float timeDead = 1.0f;
    bool Out;
    public static int NbChildren;
    public int Need = 0;
    public bool FINISH = true;
    bool end;

    /*public void OnTriggerEnter2D(Collider2D coll)
    {
        //if(coll.tag == "Player")

    }
    /public void EndGame()
    {
        //endGameUIText.text = endTextWin.ToString();
    }

    public void HandleClick()
    {
    }*/
    private void Start()
    {
        NbChildren = GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().NbPiouPiou;
        end = GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().FIN;
        GameObject.Find("End").GetComponent<Canvas>().enabled = false;
    }
    private void Update()
    {
        if (NbChildren <= 0)
            FINISH = true;
        NbChildren = GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().NbPiouPiou;
        nWorms = GameObject.Find("Player").GetComponent<PlayerInventory>().Worms;
        end = GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().FIN;
    }
    public void MakeDead()
    {
        nlife = GameObject.Find("Player").GetComponent<PlayerInventory>().life;
        Out = GameObject.Find("BorderLine").GetComponent<BorderLine>().Out;//GetComponent<BorderLine>().fini;
        //NbChildren = GameObject.Find("Player").GetComponent<PlayerInventory>().PioupiouScore;
        print("SORTIE : "+ Out);
        if (nlife <= 0 || Out == true)
        {
            timeDead -= Time.deltaTime;
            if (timeDead <= 0 || Out == true)
            {
                FINISH = true;
                SceneManager.LoadScene("LVL1");
                
                //Destroy(GetComponent<Rigidbody>());
                if(gameObject.CompareTag("Player"))
                    nlife = 5;
                else
                    Destroy(gameObject.transform.root.gameObject); // On detruit la hierarchie complete de l'objet
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (nWorms < NbChildren)
            {
                NbChildren = nWorms;
                print("Nombre d'enfant : " + NbChildren);
            }
            if (NbChildren < 0)
            {
                NbChildren = 0;
            }
            GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().NbPiouPiou = NbChildren;
            print("Nombre d'enfant 2 : " + NbChildren);

            if (end == false)
            {
                GameObject.Find("Save").GetComponent<DontDestroyOnLoad>().FIN = true;
                SceneManager.LoadScene("LVL2");
            }
            else
            {
                GameObject.Find("End").GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
