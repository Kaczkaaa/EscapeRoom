using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointController checkpointController;
    [SerializeField] Collider collider;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            checkpointController.actuallCheckpoint = gameObject.transform;
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }


}
