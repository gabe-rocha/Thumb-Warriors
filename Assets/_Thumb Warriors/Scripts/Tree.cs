using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, IDamageable {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private GameObject pfResourceToSpawn;
#endregion

#region Private Fields
    private HealthSystem healthSystem;
    private Animator animator;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        healthSystem = new HealthSystem(Data.treeHealth);
        animator = GetComponent<Animator>();
        if (animator == null) {
            Debug.LogError($"{name} is missing animator");
        }
    }

    void Start() {

    }

    void Update() {

    }
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int value) {
        healthSystem.Damage(value);
        if (healthSystem.IsDead()) {
            animator.SetTrigger("Fall");
        }
    }

    public void SpawnResources() {
        //triggered by the animation
        int amount = UnityEngine.Random.Range(3, 6);
        for (var i = 0; i < amount; i++) {
            Instantiate(pfResourceToSpawn, transform.position, Quaternion.identity, null);
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

    public bool IsDead() {
        return healthSystem.IsDead();
    }

    public void SetAsTarget(bool isTargetted) {

    }
#endregion
}