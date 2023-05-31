using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class DoorOpenInteractionController : MonoBehaviour, IPlayerInteraction
{
    public InteractionType interactionType = InteractionType.OpenDoor;
    Animator animator;
    bool isOpen = false;
    private float timer = 2f;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textObject => text;
    public string textUI = "Use E to open door";

    private void Start()
    {
        textObject.gameObject.SetActive(false);
    }

    public InteractionType GetInteractionType()
    {
        return interactionType;
    }

    public void HandleUi()
    {
        textObject.text = textUI;
        textObject.gameObject.SetActive(true);
    }

    public void OnInteraction(GameObject sender)
    {
        animator = GetComponent<Animator>();
        ToggleDoor();
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(DoorOpen());
        textObject.gameObject.SetActive(false);
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
