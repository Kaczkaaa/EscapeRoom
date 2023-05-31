using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenClosedDoorInteraction : MonoBehaviour, IPlayerInteraction
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textObject => text;
    public string textUI = "Click E to open door";

    public InteractionType GetInteractionType() => InteractionType.OpenClosedDoor;
    public void HandleUi()
    {
        textObject.text = textUI;
        textObject.gameObject.SetActive(true);
    }

    [SerializeField] ScriptableObjectINT itemsPlacedAlready;
    [SerializeField] int itemsNeededToPlace;

    private void Start()
    {
        itemsPlacedAlready.value = 0;
        textObject.gameObject.SetActive(false);
    }

    public void OnInteraction(GameObject sender)
    {
        if (itemsPlacedAlready.value == itemsNeededToPlace)
        {
            textObject.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        Debug.Log(itemsPlacedAlready.value);
    }
}
