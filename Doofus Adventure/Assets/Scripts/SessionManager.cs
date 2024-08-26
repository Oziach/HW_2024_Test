using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionManager : MonoBehaviour
{   
    public static SessionManager Instance { get; private set; }

    private int score = 0;

    [SerializeField] GameSceneUI gameSceneUI;

    private void Awake() {
        if (Instance) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }


    public void AddScore() {
        gameSceneUI.SetScore(++score);
    }

    public void PlayerDeath() {
        gameSceneUI.GameOver();
    }
}
