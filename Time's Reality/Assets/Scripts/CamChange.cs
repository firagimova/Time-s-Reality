using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    bool isCam1 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    //when it trigger with Player, it will change the camera
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isCam1 = !isCam1;
            cam1.SetActive(isCam1);
            cam2.SetActive(!isCam1);
        }
    }
}
