using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementController : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    NavMeshAgent agent;

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null) {
            Debug.LogError($"{name} is missing a NavMeshAgent");
        }
    }

    void Start() {

    }

    void Update() {

        if(GameManager.Instance.gameState != GameManager.GameStates.Playing) {
            return;
        }

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
            }
        }

    }
#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}