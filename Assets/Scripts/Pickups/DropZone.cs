using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour,IPlayerInteraction
{
    public DropZoneInteractionType dropZoneInteractionType;

    public void OnInteraction()
    {
        switch (dropZoneInteractionType)
        {
            case DropZoneInteractionType.PutOn:
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case DropZoneInteractionType.PutOff:
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                break;
        }
    }
}
