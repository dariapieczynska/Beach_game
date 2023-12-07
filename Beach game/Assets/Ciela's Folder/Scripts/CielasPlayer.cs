using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ciela Parent, Daria 
//12/7/23
//Controls when player loses a life
public class CielasPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //player loses a life
    public void LoseALife() 
    {
       // if (time == 0) 
        {
            SceneManager.LoadScene(1);
        }
    }

}
