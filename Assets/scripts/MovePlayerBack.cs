using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBack : MonoBehaviour
{
    public Transform player;
    public float x,y,z;

public void movePlayer(){
    player.position = new Vector3(x,y,z);
}
}
