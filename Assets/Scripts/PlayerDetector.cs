using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject> {}

public class PlayerDetector : MonoBehaviour
{
    public string PlayerTag;
    public GameObjectEvent PlayerEntered;
    public GameObjectEvent PlayerStayed;
    public GameObjectEvent PlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerTag)
        {
            Debug.Log(other.gameObject);
            PlayerEntered.Invoke(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == PlayerTag)
        {
            PlayerStayed.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == PlayerTag)
        {
            PlayerExited.Invoke(other.gameObject);
        }
    }
  
}
