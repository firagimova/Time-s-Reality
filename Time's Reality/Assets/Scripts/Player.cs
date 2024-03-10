using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collision with the ground
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            //restart this level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    
}
