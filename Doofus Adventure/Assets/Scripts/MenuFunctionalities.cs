using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctionalities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
