using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    const int MAIN_MENU_SCENE_INDEX = 0; 
    const int GAME_SCENE_INDEX = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadGameScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GAME_SCENE_INDEX);
    }

    public static void LoadMainMenuScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
    }

    public static void QuitGame() {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
