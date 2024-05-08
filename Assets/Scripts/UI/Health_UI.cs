using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health_UI : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI healthText;

    private Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = stats.currentHealth / (float) stats.maxHealth;

        if (healthText != null) healthText.text = $"{stats.currentHealth}/{stats.maxHealth}";
    }
}
