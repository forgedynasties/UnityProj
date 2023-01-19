using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mad : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playUI;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void unPause()
    {
        pauseMenu.SetActive(false);
        playUI.SetActive(true);
        Time.timeScale = 1;

    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        playUI.SetActive(false);
        Time.timeScale = 0;
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
