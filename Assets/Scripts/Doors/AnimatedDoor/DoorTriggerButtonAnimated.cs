using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButtonAnimated : MonoBehaviour
{
    [SerializeField] private DoorAnimated door;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            door.CloseDoor();
        }
    }
}