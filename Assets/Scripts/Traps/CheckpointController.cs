using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
   public Transform actuallCheckpoint;
   [SerializeField] GameObject _player;


   public void Respawn()
   {
       _player.transform.position = actuallCheckpoint.position;
   }





















    


   /* public GameObject checkpoint;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject checkpoint4;

    private Vector3 checkpointPosition;

    public static int checkpointNumber = 0;
    [SerializeField] GameObject playerPosition;
    Vector3 _playerPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = playerPosition.transform.position;
        //playerPosition.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    DLA KRZYSIA 
   void OnTriggerEnter(Collider other)
    {
        checkpointNumber++;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log(checkpointNumber);
    }

    public void _Checkpoints()
    {
        switch (checkpointNumber)
        {
            case 1 :
                checkpointPosition = checkpoint2.transform.position;
                break;
            case 2:
                checkpointPosition = checkpoint3.transform.position;
                break;
            case 3:
                checkpointPosition = checkpoint4.transform.position;
                break;
            
            default:
                checkpointPosition = checkpoint.transform.position;
                break;
                
        }
    }
    public void Respawn()
    {
        _playerPosition = checkpointPosition;
        Debug.Log(checkpointPosition);
        Debug.Log(_playerPosition);
    }*/
}
