using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Interactions : MonoBehaviour,IPlayerInteraction
{
    bool isOpen = false;
    Animator animator;
    [FormerlySerializedAs("dropZoneInteractionType")]
    public InteractionType interactionType;

    private float timer = 2f;

    public void OnInteraction()
    {
        switch (interactionType)
        {
            case InteractionType.PickUp:
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case InteractionType.PutOff:
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                break;
            case InteractionType.OpenDoor:
                animator = GetComponent<Animator>();
                ToggleDoor();
                gameObject.GetComponent<Collider>().enabled = false;
                StartCoroutine(DoorOpen());
                break;
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
}
