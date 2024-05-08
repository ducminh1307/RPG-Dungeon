using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Setting Chest")]
    [SerializeField] private int roomId;
    [SerializeField] private GameObject topChest;
    [SerializeField] private int potionQuantity;

    private bool canReward;
    private bool isOpen;
    private bool isPlayerInSign;

    private void Awake()
    {
        CheckPlayerInBackDoor.onPlayerInBackDoor += CheckChestRoom;
    }

    private void OnDestroy()
    {
        CheckPlayerInBackDoor.onPlayerInBackDoor -= CheckChestRoom;
    }

    void Start()
    {
        UIManager.instance.HideRecommendOpenChest();
    }

    void Update()
    {
        if (EnemyManager.instance.isClearRoom && canReward && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.F) && isPlayerInSign)
            {                
                RewardChest();
                isOpen = true;
                UIManager.instance.HideRecommendOpenChest();
            }
        }

        if (isOpen)
            OpenChest();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (EnemyManager.instance.isClearRoom && !isOpen && canReward)
                UIManager.instance.ShowRecommendOpenChest();
            isPlayerInSign = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideRecommendOpenChest();
        isPlayerInSign = false;
    }

    private void OpenChest()
    {
        topChest.transform.rotation = Quaternion.RotateTowards(topChest.transform.rotation, Quaternion.Euler(-60, 0, 0) * transform.rotation, 360 * Time.deltaTime);
    }

    private void RewardChest()
    {
        AudioSFXManager.instance.openChestSound.Play();
        PotionManager.instance.AddPotion(potionQuantity);
    }

    private void CheckChestRoom(int _id)
    {
        if (_id == roomId)
            canReward = true;
        else
            canReward = false;
    }
}
