using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpitScore : MonoBehaviour
{
    bool scored = false; //for foolproofing.

    //collision matrix is set so only the player can interact with these.
    private void OnTriggerEnter(Collider other) {
        
        if (scored) { return; }

        SessionManager.Instance.AddScore();
        scored = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
