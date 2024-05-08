using System;
using UnityEngine;
using UnityEngine.Events;

public class CheckPlayerInBackDoor : MonoBehaviour
{
    [SerializeField] private int doorId;
    public static UnityAction<int> onPlayerInBackDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerInBackDoor.Invoke(doorId);
            gameObject.SetActive(false);
        }
    }
}
