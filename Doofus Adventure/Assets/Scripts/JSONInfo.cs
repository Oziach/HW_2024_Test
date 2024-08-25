using System;
using System.Collections;
using System.Collections.Generic;

//struct to sore json data

[Serializable]
public class JSONInfo
{
    public PlayerInfo player_data;
    public PulpitInfo pulpit_data;
}

[Serializable]
public class PlayerInfo {
    public float speed;
}

[Serializable]
public class PulpitInfo {
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

