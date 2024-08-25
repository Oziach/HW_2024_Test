using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//growing and shrinking can also be done using animator quite easily,
//but doing it procedurally using state machines is cool.

public class Pulpit : MonoBehaviour
{
    public static int numberOfPulpits = 0; //this is surprisingly cleaner than using a manager class


    [SerializeField] private float scaleDuration; //time for pulpit to grow/shrink
    private float scaleSpeed;

    private float maxPulpitDuration;
    private float currDuration;
 

    [SerializeField] TextMeshProUGUI timerUI;

    enum PulpitState {
        Growing,
        Countdown,
        Shrinking
    }

    [SerializeField] PulpitState currentState;

    private void Awake() {
        numberOfPulpits++;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = PulpitState.Growing;
        scaleSpeed = 1/scaleDuration;
        maxPulpitDuration = GameData.Instance.GetMaxPulpitDestroyTime();
        currDuration = 0;

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
            Maintain();
        }
        //shrink
        else if(currentState == PulpitState.Shrinking){
            Shrink();
        }
    }

    private void Maintain() {
        currDuration += Time.deltaTime;

        if (currDuration >= maxPulpitDuration) {
            currentState = PulpitState.Shrinking;
            timerUI.enabled = false;
        }
        float remainingDuration = maxPulpitDuration - currDuration;
        timerUI.text = remainingDuration.ToString("f2");
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
            DestroyPulpit();
        }
    }

    private void DestroyPulpit() {
        Destroy(gameObject);
        gameObject.SetActive(false);
        numberOfPulpits--;
    }


    //getters and setters

    public void SetMaxDuration(float duration) {
        maxPulpitDuration = duration;
    }
    
}
