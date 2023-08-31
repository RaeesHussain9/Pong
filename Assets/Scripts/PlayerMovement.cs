using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10;



    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * moveSpeed *Time.deltaTime);
        //} 
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    player.Translate(Vector3.right * moveSpeed *Time.deltaTime);
        //}

        // try doing a sperate script for the player1 and player 2 controls that call the move script
    }

    public void Move(Transform player, Vector3 _moveDirection)
    {
        player.Translate(_moveDirection * moveSpeed * Time.deltaTime);
    }
}
