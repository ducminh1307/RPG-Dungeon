using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public static PotionManager instance;
    private int potionQuantity = 0;

    [SerializeField] private TextMeshProUGUI potionText;
    [field: SerializeField] public int healthPower {  get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        UpdatePotion();
    }

    public void AddPotion(int quantity)
    {
        potionQuantity += quantity;
        UpdatePotion();
    }

    public void UsePotion()
    {
        potionQuantity --;
        UpdatePotion();
    }

    public bool canHealth() => potionQuantity > 0;

    private void UpdatePotion()
    {
        potionText.text = potionQuantity.ToString();
    }
}
