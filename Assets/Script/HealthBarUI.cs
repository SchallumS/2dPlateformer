using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    // Start is called before the first frame update

    public float Health, MaxHealth, Width, Height;
    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxHealth(float max_health)
    {
        MaxHealth = max_health;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (Health / MaxHealth) * Width;
 
        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
