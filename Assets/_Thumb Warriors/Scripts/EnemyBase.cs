using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour, IDamageable {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject selectedIndicator;
#endregion

#region Private Fields
    private HealthSystem healthSystem;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        if(animator == null) {
            Debug.LogError($"{name} is missing an animator");
        }

        if(selectedIndicator == null) {
            Debug.LogError($"{name} is missing the selection indicator");
        }

        selectedIndicator.SetActive(false);

        healthSystem = new HealthSystem(12);
    }

    void Start() { }

#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int value) {
        Debug.Log($"{name} received {value} points of damage!");

        animator.SetTrigger("Take Damage");
        healthSystem.Damage(value);
        if(healthSystem.IsDead()) {
            animator.SetTrigger("Die");
            selectedIndicator.SetActive(false);
        }
    }

    public bool IsDead() {
        return healthSystem.IsDead();
    }

    public void SetAsTarget(bool isTargetted) {
        selectedIndicator.SetActive(isTargetted);
    }
#endregion
}