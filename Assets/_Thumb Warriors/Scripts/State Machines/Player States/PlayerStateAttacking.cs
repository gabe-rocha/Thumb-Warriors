using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateAttacking : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    private Player player;
    private IDamageable enemy;
    private float attackCooldown;
    private float attackStartTime;
    private float halfAnimationDuration = 0.375f;
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void OnEnter() {
        Debug.Log($"Entered State Attacking");
        player = Player.Instance;
        enemy = player.target.GetComponent<IDamageable>();
        //animation will be on Idle here already
    }

    public void OnExit() {
        //animation will be on Idle here already
    }

    public IState Tick() {
        if(enemy.IsDead()) {
            player.target = null;
        }

        if(player.target == null) {
            return player.stateIdle;
        }

        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0) {
            attackStartTime = Time.time;
            player.animator.SetTrigger("Melee Right Attack 01");
            attackCooldown = 1f / player.attacksPerSec;
        }

        if(Time.time >= attackStartTime + halfAnimationDuration) {
            attackStartTime = float.PositiveInfinity;
            enemy.Damage(player.weaponDamage);
        }

        return this;
    }

#endregion
}