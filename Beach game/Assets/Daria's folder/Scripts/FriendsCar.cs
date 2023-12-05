using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsCar : MonoBehaviour
{
    public PlayerController PlayerController;
    public GameObject pickupCar;
    public float xCoordinate;
    public float zCoordinate;
    public bool isFollowing = false;
    public bool droppedOff = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFollowing && !PlayerController.carFollowing)
        {
            if(Vector3.Distance(pickupCar.transform.position, this.transform.position) <= 2)
            {
                isFollowing = true;
                PlayerController.carFollowing = true;
                PlayerController.FriendsCar = this;
            }
        }
        
        Follow();

    }
    public void Follow()
    {
        if (!droppedOff)
        {
            if (isFollowing)
            {
                if (PlayerController.positionHistory.Count > 10)
                {
                    transform.position = PlayerController.positionHistory[10];
                }
                if (PlayerController.rotationHistory.Count > 10)
                {
                    transform.rotation = PlayerController.rotationHistory[10];
                }
            }
        }
    }
}

