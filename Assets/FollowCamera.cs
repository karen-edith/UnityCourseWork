using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //This thing's position (camera) should be the same as the car's position
    //serializeField gives acces in the inspector - you can select the object to follow in the inspector
    [SerializeField] GameObject thingToFollow;
    
    // Update is called once per frame
    // LateUpdate is going to ensure that smooth camera follow 
    // Camera can move before car causing camera jitteriness (has to to with execution order)
    void LateUpdate()
    {
        // Position is a vector, which is why when you add space to it to keep the camera from being directly on top
        // of the car, you need to add a space by adding a vector
        // position of the camera = position of the car (thingToFollow) + 10 on the z axis
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
    }
}
