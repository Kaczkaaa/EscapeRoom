using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject) //if the object we collided with is ourselves then we return and do nothing
            return;

        playerController.SetGrounded(true); //if not
    } //when we hit the ground, grounded = true

   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.gameObject) 

        playerController.SetGrounded(false); 
    } //when we leave the ground, grounded = false*/
   
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerController.gameObject) 
            return;

        playerController.SetGrounded(true); 
    } //while on the ground, grounded = true
}
