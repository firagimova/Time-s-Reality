using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPClooking : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //look at player by changing the rotation y of the NPC
        transform.LookAt(player.transform);

        // Then, rotate the NPC 90 degrees around its up-axis to make its belly side face the player
        transform.Rotate(270, 0, 270, Space.Self);

    }
}
