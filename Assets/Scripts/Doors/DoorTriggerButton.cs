using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }
    
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
