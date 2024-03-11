using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;


    // Start is called before the first frame update
    void Start()
    {
        //if it exists, get the health text
        if (healthText != null)
        {
            healthText.text = health + "/100";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the health is less than or equal to 0, the boss will die
        if (health <= 0)
        {
            //load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (healthText != null)
        {
            healthText.text = health + "/100";
        }
    }
}
