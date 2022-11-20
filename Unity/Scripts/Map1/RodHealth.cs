using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RodHealth : MonoBehaviour
{
    public Image healthBar;
    [HideInInspector] public float targetHealth = 1f;

    
    private void Update() {
        if(healthBar.fillAmount > targetHealth)
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetHealth, 3f * Time.deltaTime);
    }

    public void HealthBarFiller(float health) {
        targetHealth = health;
        if (health == 1f)
            healthBar.fillAmount = 1f;
    }
}
