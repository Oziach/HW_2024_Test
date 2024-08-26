using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Intance { get; private set; }
    private void Awake() {
        if(Intance == null) {  
            Intance = new MusicManager(); 
        }
        else {
            Intance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //camera.main is cahced in newer unity verisons. this is effecient.
        gameObject.transform.position = Camera.main.transform.position; 
    }
}
