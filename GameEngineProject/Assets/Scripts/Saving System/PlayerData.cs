using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public float[] position;
    public int health;

    public PlayerData(CharMove player)
    {
        //health = player.health;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
