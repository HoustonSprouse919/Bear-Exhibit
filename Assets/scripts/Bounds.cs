using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform player;
    public float x,y,z;
    
    void OnTriggerEnter(Collider other)
    {
            player.position = new Vector3(x,y,z);
                    Debug.Log(player.position);

    }
}
