using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInterface : MonoBehaviour,IPlayerInteraction
{
    public void OnInteraction()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
