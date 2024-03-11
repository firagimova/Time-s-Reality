using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //load next scene after 5 seconds
        Invoke("GoToNextScene", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //go to next scene
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
