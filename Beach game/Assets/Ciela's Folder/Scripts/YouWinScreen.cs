using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScreen : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
    /// 
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Changes the current scene to the scene with a matching index
    /// </summary>
    /// <param> name="sceneIndex" > The index of the scene to switch to  </param>

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(2);
    }
}
