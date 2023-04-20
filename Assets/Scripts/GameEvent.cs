using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Game Event/New Event", fileName = "New Event")]
public class GameEvent : ScriptableObject
{
   
    public int value;
    
    public List<IGameEventListener> gameEventListeners = new List<IGameEventListener>();
    
    public void Raise()
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i].OnEventRaise();
        }
    }
    
    public void RegisterListener(IGameEventListener gameEventListener)
    {
        if (gameEventListeners.Contains(gameEventListener))
            return;
        gameEventListeners.Add(gameEventListener);
    }

    public void UnregisterListener(IGameEventListener gameEventListener)
    {
        if (gameEventListeners.Contains(gameEventListener) == false)
            return;
        gameEventListeners.Remove(gameEventListener);
    }
}
