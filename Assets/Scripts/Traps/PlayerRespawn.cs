using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerRespawn : MonoBehaviour,IDamagable
{
    private int deathCounter;

    [SerializeField] private TextMeshProUGUI deathCounterHud;
    
    public CheckpointController checkpointController;

    public ScriptableObjectINT SOdeathcounter;
    [SerializeField] private TextMeshProUGUI deathCounterALLHud;

    // Start is called before the first frame update    
    void Start()
    {
        deathCounterALLHud.text = SOdeathcounter.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            deathCounter++;
            deathCounterHud.text = deathCounter.ToString();
            checkpointController.Respawn(); 

        }
    }*/

   private void OnTriggerEnter(Collider other)
   {
       
   }
   // 
   public void OnKill()
   {
       deathCounter++;
       SOdeathcounter.value ++;
       deathCounterHud.text = deathCounter.ToString();
      deathCounterALLHud.text = SOdeathcounter.value.ToString();
       checkpointController.Respawn();
   }
}
