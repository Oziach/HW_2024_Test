using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{

    [SerializeField] string scoreTextFormat = "Score : ";
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetScore(int score) {
        scoreText.text = scoreTextFormat + score.ToString();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
