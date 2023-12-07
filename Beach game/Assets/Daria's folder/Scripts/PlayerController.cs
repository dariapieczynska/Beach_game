using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Pieczynska, Daria & Parent, Ciela
// 12/07/2023
//Player moves forwared, backward and to the sides
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public bool canTurn = true;
    public bool isFast = false;
    public bool wasFast = false;
    public bool slowedDown = false;
    public bool flatTire = false;
    public bool hasTire = false;
    public bool dropOff = false;
    public bool carFollowing = false; 
    public List<Vector3> positionHistory;
    public List<Quaternion> rotationHistory;
    public GameObject tireOnTheCar;
    public FriendsCar FriendsCar;
    public FriendTracker FriendTracker;
    private void Start()
    {
        tireOnTheCar.SetActive(false);
        positionHistory = new List<Vector3>();
        rotationHistory = new List<Quaternion>();
    }
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
        if (positionHistory.Count < 100)
        {
            positionHistory.Add(transform.position);
            rotationHistory.Add(transform.rotation);
        }
        else
        {
            if (transform.position != positionHistory[positionHistory.Count-1])
            {
                positionHistory.RemoveAt(0);
                positionHistory.Add(transform.position);
                rotationHistory.RemoveAt(0);
                rotationHistory.Add(transform.rotation);
            }
            
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
                Debug.Log("Spikes with a tire");
                other.gameObject.SetActive(false);
                hasTire = false;
                tireOnTheCar.SetActive(false);
            }
            else 
            {
                Debug.Log("Spikes with no tire");
                other.gameObject.SetActive(false);
                StartCoroutine(Spikes());
            }
        }
        if(other.tag=="Tire")
        {
            hasTire = true;
            tireOnTheCar.SetActive(true);
            other.gameObject.SetActive(false);
            

        }
        if(other.tag=="Parking")
        {
            if (carFollowing == true)
            {
                FriendsCar.droppedOff = true;
                carFollowing = false;
                if(!FriendTracker.friend1)
                {
                    FriendTracker.friend1 = FriendsCar;
                }
                else if(!FriendTracker.friend2)
                {
                    FriendTracker.friend2 = FriendsCar;
                }
                else if (!FriendTracker.friend3)
                {
                    FriendTracker.friend3 = FriendsCar;
                }
                FriendsCar = null;
            }
            
        }
    }
    public IEnumerator SpeedBoost()
    {
        isFast = true;
        speed = 10f;
        yield return new WaitForSeconds(5f);
        speed = 6f;
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
        speed = 6f;
        slowedDown = false;
    }
    public IEnumerator Spikes()
    {
        flatTire = true;
        speed = 3f;
        yield return new WaitForSeconds(5f);
        speed = 6f;
        flatTire = false; 
    }
}
