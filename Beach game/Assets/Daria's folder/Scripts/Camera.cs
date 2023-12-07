using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Pieczynska, Daria & Parent, Ciela]
 * Last Updated: [12/07/2023]
 * [Makes the camera follow the player]
 */
public class Camera : MonoBehaviour
{
    public GameObject player;




    /// <summary>
    /// this function makes the camera follow the player
    /// </summary>
    private void LateUpdate()
    {
        Vector3 tempPos = transform.position;
        tempPos.x = player.transform.position.x;
        tempPos.z = player.transform.position.z;
        transform.position = tempPos;
    }
}