using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionManager : MonoBehaviour
{   
    public static SessionManager Instance { get; private set; }

    private float score = 0;

    [SerializeField] string scoreTextFormat = "Score : ";
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake() {
        if (Instance) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    public void AddScore() {
        score++;
        scoreText.text = scoreTextFormat + score.ToString();
    }
}
