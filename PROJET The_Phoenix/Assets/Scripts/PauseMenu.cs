using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool InPause = false;
    //public GameObject pauseMenuUI;

    private void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
        if (InPause == true)
        {
            Time.timeScale = 0;
            //GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            //GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }
    }
    public void Resume()
    {
        InPause = !InPause;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Boot");
    }
}
