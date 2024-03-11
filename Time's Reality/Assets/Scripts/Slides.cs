using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slides : MonoBehaviour
{
    public GameObject[] slides;

    private float changeTime = 3f; // Time to wait before changing slides
    private float timer;
    private int currentSlideIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;

        // Initially, deactivate all slides except the first one
        foreach (GameObject slide in slides)
        {
            slide.SetActive(false);
        }
        if (slides.Length > 0)
        {
            slides[0].SetActive(true); // Activate the first slide
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            // Deactivate the current slide
            slides[currentSlideIndex].SetActive(false);

            // Move to the next slide or loop around
            currentSlideIndex++;

            // Check if all slides have been shown
            if (currentSlideIndex >= slides.Length)
            {
                // Load the next scene
                LoadNextScene();
                return; // Exit to avoid further execution after loading the scene
            }

            // Activate the next slide
            slides[currentSlideIndex].SetActive(true);

            // Reset the timer
            timer = 0f;
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; // Loop back to the first scene if this is the last one
        SceneManager.LoadScene(nextSceneIndex);
    }

}
