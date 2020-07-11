using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    public int lvl = 0;
    public int rlife;
    public static bool MenuChooseDif = true;

    private void Start()
    {

    }
    void Update()
    {
        if (MenuChooseDif == true)
        {
            Time.timeScale = 0;
            GameObject.Find("DifficultyMenu").GetComponent<Canvas>().enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            GameObject.Find("DifficultyMenu").GetComponent<Canvas>().enabled = false;
        }
        if (lvl == 0) rlife = 1;
        if (lvl == 1) rlife = 2;
        if (lvl == 2) rlife = 3;
    }

    public void facile()
    {
        lvl = 0;
        MenuChooseDif = false;
        GameObject.Find("Player").GetComponent<PlayerInventory>().setlife = true;
    }
    public void moyen()
    {
        lvl = 1;
        MenuChooseDif = false;
        GameObject.Find("Player").GetComponent<PlayerInventory>().setlife = true;
    }
    public void difficile()
    {
        lvl = 2;
        MenuChooseDif = false;
        GameObject.Find("Player").GetComponent<PlayerInventory>().setlife = true;
    }

    public void LVL1()
    {
        SceneManager.LoadScene("LVL1");
    }
    public void LVL2()
    {
        SceneManager.LoadScene("LVL2");
    }
}
