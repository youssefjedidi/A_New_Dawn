using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject normalUI;
    public GameObject OverUI;
    public GameObject WinUI;

    public Transform Manager;


    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
         {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
         }
         if (Manager.GetComponent<LifeSystem>().lost)
         {
            Over();
         }
    }

    public void Over()
    {
        pauseMenuUI.SetActive(false);
        normalUI.SetActive(false);
        Time.timeScale = 0f;
        //GameIsPaused = true;
        OverUI.SetActive(true);
    }
    public void Win()
    {
        pauseMenuUI.SetActive(false);
        normalUI.SetActive(false);
        Time.timeScale = 0f;
        //GameIsPaused = true;
        WinUI.SetActive(true);
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        normalUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        OverUI.SetActive(false);
        SceneManager.LoadScene("GameMode1Scene");
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        normalUI.SetActive(true);
        Time.timeScale =1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        normalUI.SetActive(false);
        Time.timeScale =0f;
        GameIsPaused = true;
    }
}
