using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public int NbPiouPiou;
    public bool FIN;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NbPiouPiou = 3;
        FIN = false;
    }
    private void Update()
    {
        GameObject.Find("Player").GetComponent<PlayerInventory>().PioupiouScore = NbPiouPiou;
    }
}
