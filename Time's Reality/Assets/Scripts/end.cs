using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //go to scene 0 after 5 seconds
        Invoke("GoToScene0", 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //go to scene no 0
    public void GoToScene0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }

}
