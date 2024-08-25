using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//growing and shrinking can also be done using animator quite easily,
//but doing it procedurally using state machines is cool.

public class Pulpit : MonoBehaviour
{
    [SerializeField] private float scaleDuration; //time for pulpit to grow or shrink when created or destroyed
    private float scaleSpeed;

    [SerializeField] private float pulpitDuration = 5f;

    [SerializeField] TextMeshProUGUI timerUI;

    enum PulpitState {
        Growing,
        Countdown,
        Shrinking
    }

    [SerializeField] PulpitState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PulpitState.Growing;
        scaleSpeed = 1/scaleDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //grow
        if (currentState == PulpitState.Growing) {
            Grow();
        }
        //maintain
        else if (currentState == PulpitState.Countdown) {

            pulpitDuration -= Time.deltaTime;

            if (pulpitDuration <= 0) {
                pulpitDuration = 0;
                currentState = PulpitState.Shrinking;
                timerUI.enabled = false;
            }

            timerUI.text = pulpitDuration.ToString("f2");
        }
        //shrink
        else {
            Shrink();
        }
    }

    public void Grow() {
        transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        if (transform.localScale.x > 1) { transform.localScale = Vector3.one; }

        if (transform.localScale == Vector3.one) { 
            currentState = PulpitState.Countdown;
            timerUI.enabled = true;
        }
    }

    public void Shrink() {
        transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        if (transform.localScale.x < 0) { transform.localScale = Vector3.zero; }

        if (transform.localScale == Vector3.zero) {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    
}
