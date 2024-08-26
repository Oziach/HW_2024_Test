using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctionalities : MonoBehaviour
{

    public void StartGame() {
        SceneLoader.LoadGameScene();
    }

    public void QuitToMenu() {
        SceneLoader.LoadMainMenuScene();
    }

    public void QuitGame() {
        SceneLoader.QuitGame();
    }
}
