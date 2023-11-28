using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    /// <summary>
    /// Starts the game
    /// </summary>
    
    
    /// <summary>
    /// <param> Changes the current scene to the scene to switch to </param>
    /// </summary>
    
    public void SwitchScene(int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
