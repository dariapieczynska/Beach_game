using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Pieczynska, Daria
// 11/16/2023
//Player moves forwared, backward and to the sides
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool canTurn = true; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            canTurn = true;
            TurnRight();
           
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            canTurn = true;
            TurnLeft();
           
        }
        if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }


    }
    public void TurnRight()
    {
        if (canTurn)
        {


            if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
            {

                transform.Rotate(Vector3.up * 90);
                canTurn = false;
            }
        }
    }
    public void TurnLeft()
    {
        if (canTurn)
        {


            if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                transform.Rotate(Vector3.up * -90);
                canTurn = false;
            }
        }
    }
    
}
