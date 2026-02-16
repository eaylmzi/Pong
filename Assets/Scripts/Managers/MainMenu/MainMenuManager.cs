using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Start()
    {
        AudioManager.instance.Play(SoundName.MAIN_MENU);
    }
    public void StartGame()
    {
        AudioManager.instance.Play(SoundName.HIT_PADDLE);
        SceneManager.LoadScene(Scene.PONG_SCENE);
    }
    public void StartSingleGame()
    {
        GameData.GAME_DATA = GameMode.SINGLE_PLAYER;
        AudioManager.instance.Play(SoundName.HIT_PADDLE);
        SceneManager.LoadScene(Scene.PONG_SCENE);
    }
    public void StartMultiplayerGame()
    {
        GameData.GAME_DATA = GameMode.MULTI_PLAYER;
        AudioManager.instance.Play(SoundName.HIT_PADDLE);
        SceneManager.LoadScene(Scene.PONG_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
