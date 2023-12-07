using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*
 * Author: [Pieczynska, Daria & Parent, Ciela]
 * Last Updated: [12/072023]
 * [Tracks friend UI]
 */
public class FriendTracker : MonoBehaviour
{
    //how much a friend is worth:
    private float friendPointValue = 1f;

    //lives start at 0 and go up when you drop of friends
    public int lives = 0;
    public FriendsCar friend1;
    public FriendsCar friend2;
    public FriendsCar friend3;
    public FriendsCar friend4;


    public TimeController Timer;
    public TMP_Text FriendsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (friend1 != null)
            {
                FriendsText.text = "Friends: 1/3";
            }
            if (friend2 != null)
            {
                FriendsText.text = "Friends: 2/3";
            }
            if (friend3 != null)
            {
                FriendsText.text = "Friends: 3/3";

                SceneManager.LoadScene(3);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (friend1 != null)
            {
                FriendsText.text = "Friends: 1/4";
            }
            if (friend2 != null)
            {
                FriendsText.text = "Friends: 2/4";
            }
            if (friend3 != null)
            {
                FriendsText.text = "Friends: 3/4";
            }
            if (friend4 != null)
            {
                FriendsText.text = "Friends: 4/4";

                SceneManager.LoadScene(4);
            }

        }

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
