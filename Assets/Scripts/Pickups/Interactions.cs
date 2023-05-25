using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Interactions : MonoBehaviour
{
    bool isOpen = false;
    Animator animator;
    [FormerlySerializedAs("dropZoneInteractionType")]
    public InteractionType interactionType;

    private float timer = 2f;

    public void OnInteraction(GameObject sender)
    {
        switch (interactionType)
        {
            case InteractionType.OpenClosedDoor:
                gameObject.SetActive(false);
                break;
        }
    }
    void OpenDoor()
    {
        isOpen = true;   
        animator.SetBool("Open", true);
    }
    void CloseDoor()
    {
        isOpen = false;
        animator.SetBool("Open", false);    
    }
    void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
            OpenDoor();
        else
            CloseDoor();
    }

    private IEnumerator DoorOpen()
    {
            yield return new WaitForSeconds(timer);
            gameObject.GetComponent<Collider>().enabled = true;
    }

    public InteractionType GetInteractionType() => interactionType;
}
