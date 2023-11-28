using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Pieczynska, Daria
// 11/16/2023
//Player moves forwared, backward and to the sides
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool canTurn = true;
    public bool isFast = false;
    public bool wasFast = false;
    public bool slowedDown = false;
    public bool flatTire = false;
    public bool hasTire = false; 
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
            if (!slowedDown)
            {
                if (!wasFast)
                {

                    other.gameObject.SetActive(false);
                    StartCoroutine(SpeedBoost());
                    StartCoroutine(CoolDown());
                }
            }

        }
        if(other.tag=="Mud")
        {
            if (!isFast)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(SlowDown());
            }
        }
        if(other.tag=="Spikes")
        {
            if(hasTire)
            {
                other.gameObject.SetActive(false);
                hasTire = false;
            }
            else 
            {
                
                other.gameObject.SetActive(false);
                StartCoroutine(Spikes());
            }
        }
        if(other.tag=="Tire")
        {
            hasTire = true;
            other.gameObject.SetActive(false);
            

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
    public IEnumerator SlowDown()
    {
        slowedDown = true;
        speed = 2f;
        yield return new WaitForSeconds(5f);
        speed = 10f;
        slowedDown = false;
    }
    public IEnumerator Spikes()
    {
        flatTire = true;
        speed = 3f;
        yield return new WaitForSeconds(5f);
        speed = 10f;
        flatTire = false; 
    }
}
