using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int health = 100;

    //[SerializeField] Inventory inventory;
    //[SerializeField] EquipmentPanel equipmentPanel;
    
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
            GameOver();
    }

    void GameOver()
    {
        
    }

    private void Awake()
    {
        
    }
}
