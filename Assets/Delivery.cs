using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //bools in unity default to false
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(255,255,255,255);
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);
    [SerializeField] float destroyDelay = 1f;

//SrpiteRenderer is the type of variable spriteRenderer will be
    SpriteRenderer spriteRenderer;

   void Start() 
   {
    spriteRenderer = GetComponent<SpriteRenderer>();     
   }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
       Debug.Log("Ouch!!! That hurt!");
    }

    //something

    void OnTriggerEnter2D(Collider2D other) 
    //Other gives us information about the thing we're colliding into
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Packed picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            

        } else if (other.tag == "Customer" && hasPackage) 
        {

            Debug.Log("Package Delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

            
        }
    }
}
