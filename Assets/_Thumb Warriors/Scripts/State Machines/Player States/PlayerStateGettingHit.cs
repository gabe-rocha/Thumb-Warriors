using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateGettingHit : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    private Player player;
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void OnEnter() {
        Debug.Log($"Entered State Getting Hit");
        player = Player.Instance;
    }

    public void OnExit() { }

    public IState Tick() {
        return this;
    }

#endregion
}