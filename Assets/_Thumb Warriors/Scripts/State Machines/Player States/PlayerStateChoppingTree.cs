using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateChoppingTree : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    private Player player;
    private IDamageable tree;
    private float actionCooldown;
    private float actionStartTime;
    private float halfAnimationDuration = 0.375f;
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void OnEnter() {
        Debug.Log($"Entered State Chopping a Tree");
        player = Player.Instance;
        tree = player.target.GetComponent<IDamageable>();
        player.animator.SetBool("Chop Tree", true);
    }

    public void OnExit() {
        player.animator.SetBool("Chop Tree", false);

    }

    public IState Tick() {
        if(tree.IsDead()) {
            player.target = null;
        }

        if(player.target == null) {
            return player.stateIdle;
        }

        actionCooldown -= Time.deltaTime;
        if(actionCooldown <= 0) {
            actionStartTime = Time.time;
            actionCooldown = 1f / player.attacksPerSec;
        }

        if(Time.time >= actionStartTime + halfAnimationDuration) {
            actionStartTime = float.PositiveInfinity;
            tree.Damage(player.weaponDamage);
        }

        return this;
    }

#endregion
}