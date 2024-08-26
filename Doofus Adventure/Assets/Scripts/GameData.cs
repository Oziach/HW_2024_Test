using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }


    [SerializeField] private string jsonURL = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";

    //if fetching fails, use these default values intead:
    [SerializeField] private float speed = 3f;
    [SerializeField] private float minPulpitDestroyTime = 4f;
    [SerializeField] private float maxPulpitDestroyTime = 5f;
    [SerializeField] private float pulpitSpawnTime = 2.5f;

    private void Awake() {

        if (Instance) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

        StartCoroutine(GrabJSON(jsonURL));    
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator GrabJSON(string jsonUrl) {
        UnityWebRequest gameDataJson = UnityWebRequest.Get(jsonURL);
        yield return gameDataJson.SendWebRequest();

        if(gameDataJson.result == UnityWebRequest.Result.Success) {
            LoadFromJSON(gameDataJson);
        }
        else {
            Debug.LogWarning("Data download failed");
        }
    }

    private void LoadFromJSON(UnityWebRequest gameDataJson) { 

        JSONInfo jsonInfo = JsonUtility.FromJson<JSONInfo>(gameDataJson.downloadHandler.text);

        if (jsonInfo != null) {
            speed = jsonInfo.player_data.speed;
            minPulpitDestroyTime = jsonInfo.pulpit_data.min_pulpit_destroy_time;
            maxPulpitDestroyTime = jsonInfo.pulpit_data.max_pulpit_destroy_time;
            pulpitSpawnTime = jsonInfo.pulpit_data.pulpit_spawn_time;
        }

    }

    //getters
    public float GetSpeed() {
        return speed; 
    }

    public float GetMinPulpitDestroyTime() {
        return minPulpitDestroyTime;
    }

    public float GetMaxPulpitDestroyTime() {
        return maxPulpitDestroyTime;
    }

    public float GetPulpitSpawnTime() {
        return pulpitSpawnTime; 
    }
}
