using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOffInterface : MonoBehaviour,IPlayerInteraction
{
    public void OnInteraction()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
