using System;
using System.Collections;
using System.Collections.Generic;

public class HealthSystem {

    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

#region Public Fields

#endregion

#region Private Fields
    internal int maxHealth;
    internal int currentHealth;
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int amount) {
        currentHealth -= amount;

        if(currentHealth < 0) {
            currentHealth = 0;
        }
    }

    public void Heal(int amount) {
        currentHealth += amount;
        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public bool IsDead() {
        return currentHealth <= 0;
    }
#endregion
}