using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public static bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        TogglePause();
    }

    private void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        UnFreezeTime();         
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);  
        FreezeTime();       
        isPaused = true;
    }

    public void QuitGame()
    {
        UnFreezeTime();
        SceneManager.LoadScene(Scene.MAIN_MENU_SCENE);
    }
    private void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    private void UnFreezeTime()
    {
        Time.timeScale = 1f;
    }
}
