using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateIdle : IState {

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
        player = Player.Instance;
        Debug.Log($"Entered State Idle");
    }

    public void OnExit() { }

    public IState Tick() {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                Debug.Log($"Left clicked on {hit.transform.name}");

                if(hit.collider.CompareTag("Enemy")) {
                    SelectTarget(hit.transform.gameObject);
                    return this;
                } else if(hit.collider.CompareTag("Gatherable")) {
                    SelectTarget(hit.transform.gameObject);
                    return this;
                }

                //if clicked the ground, move
                DeselectTarget();
                player.agent.destination = hit.point;
                return player.stateMoving;
            }
        } else if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                if(hit.collider.CompareTag("Enemy")) {
                    Debug.Log($"Right clicked on an enemy {hit.transform.name}");

                    //Select and Move
                    SelectTarget(hit.transform.gameObject);

                    player.agent.stoppingDistance = player.stoppingDistaceToEnemy;
                    player.agent.destination = hit.transform.position;

                    return player.stateMoving;

                } else {
                    Debug.Log($"Right clicked on {hit.transform.name}");
                    DeselectTarget();
                    return this;
                }
            }
        }
        return this;
    }

    private void SelectTarget(GameObject enemy) {
        player.target = enemy;
        player.target.GetComponent<IDamageable>().SetAsTarget(true);
    }

    private void DeselectTarget() {
        if(player.target == null) {
            return;
        }

        player.target.GetComponent<IDamageable>().SetAsTarget(false);
        player.target = null;
    }
#endregion
}