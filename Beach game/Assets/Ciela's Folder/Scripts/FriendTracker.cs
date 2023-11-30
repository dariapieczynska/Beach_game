using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FriendTracker : MonoBehaviour
{
    //how much a friend is worth:
    private float friendPointValue = 1f;

    //lives start at 0 and go up when you drop of friends
    public int lives = 0;
    public GameObject friend1;
    public GameObject friend2;
    public GameObject friend3;

    public TimeController Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainALife() 
    {
        //send player to next level
        //if player is already in level 2, send them to you win UI
        lives++;

        if (lives == 3) 
        {
            if (SceneManager.GetActiveScene().buildIndex == 3) 
            {
                SceneManager.LoadScene(4); 
            }
            if (SceneManager.GetActiveScene().buildIndex == 4) 
            {
                SceneManager.LoadScene(5);
            }
        }

        //sends play to end game screen
        if (lives < 3 && Timer.elapsedTime >= 180) //when time runs out
        {
            SceneManager.LoadScene(1);
        }
    }
}
