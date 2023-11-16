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
    public bool isFast = false;
    public bool wasFast = false; 
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
    /// <summary>
    /// This function lets the car turn 90 degrees to its right
    /// </summary>
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
    /// <summary>
    /// this function lets the car turn 90 degrees to its left
    /// </summary>
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Speed")
        {
            if (!wasFast)
            {
                
                other.gameObject.SetActive(false);
                StartCoroutine(SpeedBoost());
                StartCoroutine(CoolDown());
            }

        }
    }
    public IEnumerator SpeedBoost()
    {
        isFast = true;
        speed = 20f;
        yield return new WaitForSeconds(5f);
        speed = 10f;
        isFast = false;
    }
    public IEnumerator CoolDown()
    {
        wasFast = true;
        yield return new WaitForSeconds(15f);
        wasFast = false;
    }

}
