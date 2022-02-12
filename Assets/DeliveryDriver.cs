using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDriver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 5f;
    //Serialize allows you to access this variable in the inspector and change it
    //steerSpeed controls the speed at which the car rotates
    [SerializeField]float moveSpeed = 20f;
    //Serialize allows you to access this variabe in the inspector and change it
    //moveSpeed controls the speed at which the car moves up, down

    [SerializeField] float slowSpeed = 10f;
     float initialMoveSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    float maxSpeed = 100f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            if(moveSpeed < initialMoveSpeed)
            {
                moveSpeed = initialMoveSpeed;
            }

            if(moveSpeed < maxSpeed)
            { 
                boostSpeed = moveSpeed + 10f;
                moveSpeed = boostSpeed;
                Debug.Log(moveSpeed);
            }
            else 
            {
                moveSpeed = maxSpeed;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
        boostSpeed = initialMoveSpeed + 10f;
        Debug.Log(boostSpeed);
    }

    void Update()
    {
        //old input system
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //grabs a value either -1 or 1 based on users left or right button press
        //Time.deltaTime creates frame rate independce - the car/object is going to move the same on each computer
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //grabs a value either -1 or 1 based on users up or down button press
        transform.Rotate(0, 0, -steerAmount);
         //rotation on the z-axis
        transform.Translate(0,moveAmount,0);
         //translation on the y axis
        
    }
}
