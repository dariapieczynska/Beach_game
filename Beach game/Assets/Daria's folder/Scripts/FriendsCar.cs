using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsCar : MonoBehaviour
{
    public PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.positionHistory.Count > 10)
        {
            transform.position = PlayerController.positionHistory[10];
        }

    }
}
