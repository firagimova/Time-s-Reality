using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the object with speed10 with y axis
        transform.Rotate(Vector3.up * 2 * Time.deltaTime);
    }
}
