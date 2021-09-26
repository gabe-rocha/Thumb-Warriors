using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMoving : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    private Player player;
    private IState stateToReturn;
    private GameObject movingToIndicator;
#endregion

#region Private Methods

    private void OnEnemyDetected(GameObject enemy) {
        if(enemy == player.target) {
            stateToReturn = player.stateAttacking;
        }
    }

#endregion

#region Public Methods
    public void OnEnter() {
        Debug.Log($"Entered State Moving");
        player = Player.Instance;
        player.animator.SetBool("Run", true);
        stateToReturn = null;

        movingToIndicator = UnityEngine.MonoBehaviour.Instantiate(player.movingToIndicator, player.agent.destination, Quaternion.identity);

        EventManager.Instance.StartListeningWithGOParam(EventManager.Events.EnemyDetected, OnEnemyDetected);
    }

    public void OnExit() {
        player.animator.SetBool("Run", false);
        UnityEngine.MonoBehaviour.Destroy(movingToIndicator);
        EventManager.Instance.StopListeningWithGOParam(EventManager.Events.EnemyDetected, OnEnemyDetected);
    }

    public IState Tick() {
        if(stateToReturn != null) {
            return stateToReturn;
        }

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                Debug.Log($"Left clicked on {hit.transform.name}");

                if(hit.collider.CompareTag("Enemy")) {
                    SelectEnemyTarget(hit.transform.gameObject);
                    return this;
                }

                //if clicked the ground, move
                DeselectEnemyTarget();
                player.agent.destination = hit.point;
                movingToIndicator.transform.position = player.agent.destination;
                return this;
            }
        } else if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                if(hit.collider.CompareTag("Enemy")) {
                    Debug.Log($"Right clicked on an enemy {hit.transform.name}");
                    player.agent.stoppingDistance = player.stoppingDistaceToEnemy;
                    player.agent.destination = hit.transform.position;

                    SelectEnemyTarget(hit.transform.gameObject);

                    return this;
                } else {
                    Debug.Log($"Right clicked on {hit.transform.name}");
                    DeselectEnemyTarget();
                    return this;
                }
            }
        }

        if(player.agent.remainingDistance <= player.agent.stoppingDistance + 0.1f) {
            return player.stateIdle;
        }

        return this;
    }

    private void SelectEnemyTarget(GameObject enemy) {
        player.target = enemy;
        player.target.GetComponent<IDamageable>().SetAsTarget(true);
    }

    private void DeselectEnemyTarget() {
        if(player.target == null) {
            return;
        }

        player.target.GetComponent<IDamageable>().SetAsTarget(false);
        player.target = null;
    }

#endregion
}