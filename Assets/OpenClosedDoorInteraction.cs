using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenClosedDoorInteraction : MonoBehaviour, IPlayerInteraction
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textObject => text;

    public InteractionType GetInteractionType() => InteractionType.OpenClosedDoor;
    [SerializeField] ScriptableObjectINT itemsPlacedAlready;
    [SerializeField] int itemsNeededToPlace;

    public void OnInteraction(GameObject sender)
    {
        if (itemsPlacedAlready.value == itemsNeededToPlace)
        {
            textObject.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

}
