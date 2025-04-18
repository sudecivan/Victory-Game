using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider healthbar;


    public void UpdateHealthBar(int maxHealth,int currentHealth) {

        healthbar.value = currentHealth; 
    }
}
