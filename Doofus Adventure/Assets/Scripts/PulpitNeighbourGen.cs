using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i considered making a seperate manager class for this, but it makes things unnecessarily convoluted.
public class PulpitNeighbourGen : MonoBehaviour
{
    private Pulpit pulpit;
    private float generationCountdown;

    [SerializeField] GameObject pulpitPrefab; //very very slightly unoptimal, since only 2 puplpits exist at a time.
    [SerializeField] float spawnDistance = 9f;

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
        generationCountdown = GameData.Instance.GetPulpitSpawnTime();
    }

    void Update() {
        if (currentState == GenerationState.Generated) { return; }

        else if (currentState == GenerationState.Idle) {

            generationCountdown -= Time.deltaTime;
            if (generationCountdown <= 0) {
                currentState = GenerationState.Generating;
            }

        }

        else if (currentState == GenerationState.Generating) {

            if (Pulpit.numberOfPulpits >= 2) { return; } //wait in queue. This is what i gleaned from the demo vid at least.
            GeneratePulpit();
        }
    }

    private void GeneratePulpit() {

        //once there's only one pulpit left, generate and clear queue
        Vector3 spawnPos = transform.position + (GetRandomDirection() * spawnDistance);
        GameObject newPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity, null);

        Pulpit pulpit = newPulpit.GetComponent<Pulpit>();
        if (pulpit) { pulpit.SetState(Pulpit.PulpitState.Growing); }

        pulpit.transform.localScale = Vector3.zero;

        currentState = GenerationState.Generated;
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
