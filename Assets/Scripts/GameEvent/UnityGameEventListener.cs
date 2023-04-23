using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    public GameEvent gameEvent;
    public UnityEvent response;
    
    private void Start()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDestroy()
    {
        gameEvent.UnregisterListener(this);
    }
    public void OnEventRaise()
    {
        response?.Invoke();
    }
    
    
}
