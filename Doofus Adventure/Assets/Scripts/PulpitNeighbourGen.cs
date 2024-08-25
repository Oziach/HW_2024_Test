using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i considered making a seperate manager class for this, but it makes things unnecessarily convoluted.
public class PulpitNeighbourGen : MonoBehaviour
{
    private Pulpit pulpit;

    [SerializeField] GameObject pulpitPrefab; //very very slightly unoptimal, since only 2 puplpits exist at a time.
    [SerializeField] float spawnDistance = 9f;

    [SerializeField] float generationCountdown;
    enum GenerationState {
        Idle,
        Generating,
        Generated
    }

    GenerationState currentState;

    private void Awake() {
        pulpit = GetComponent<Pulpit>();
    }

    void Start() {
        currentState = GenerationState.Idle;
    }

    void Update() {
        if (currentState == GenerationState.Generated) { return; }

        else if (currentState == GenerationState.Idle) {

            generationCountdown -= Time.deltaTime;
            Debug.Log("cding");
            if (generationCountdown <= 0) {
                Debug.Log("generating time");
                currentState = GenerationState.Generating;
            }

        }
        /////////////// HARD CODING THIS FOR NOW CHANGE IT LATER//////////////////////////
        else if (currentState == GenerationState.Generating) {

            if (Pulpit.numberOfPulpits >= 2) { return; } //wait in queue

            //once there's only one pulpit left, generate and clear queue
            Vector3 spawnPos = transform.position + (GetRandomDirection() * spawnDistance);
            GameObject newPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity, null);
            //newPulpit.GetComponent<Pulpit>().SetRemainingDuration(10f);

            currentState = GenerationState.Generated;
        }
    }

    private Vector3 GetRandomDirection() {
        
        int directionIndex = Random.Range(0, 3);

        switch (directionIndex) {
            case 0:
                return Vector3.forward;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.back;
            case 3:
                return Vector3.left;
        }
        return Vector3.right;
    }

}
