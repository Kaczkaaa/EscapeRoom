using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerOpen : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private bool isOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            isOpen = true;
            door.transform.position += new Vector3(0, 2, 0);    
        }
        else
        {
            isOpen = false;
            door.transform.position -= new Vector3(0, 2, 0);
        }
    }
}