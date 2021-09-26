using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour {

#region Public Fields
    public static Player Instance { get => instance; private set { instance = value; } }
    private static Player instance;
#endregion

#region Private Serializable Fields
    [SerializeField] internal float stoppingDistaceToEnemy = 1.5f;
    [SerializeField] internal int weaponDamage = 5;
    [SerializeField] internal int toolDamage = 5;
    [SerializeField] internal float attacksPerSec = 2;
    [SerializeField] internal float attackRadius = 2;
    [SerializeField] internal Animator animator;
    [SerializeField] internal SphereCollider enemyDetectionCollider;
    [SerializeField] internal GameObject movingToIndicator;
#endregion

#region Private Fields
    internal NavMeshAgent agent;
    internal GameObject target;
    private StateMachine stateMachine;
    internal IState stateIdle, stateMoving, stateAttacking, stateGettingHit;

#endregion

#region MonoBehaviour CallBacks
    void Awake() {

        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        agent = GetComponent<NavMeshAgent>();
        if(agent == null) {
            Debug.LogError($"{name} is missing a NavMeshAgent");
        }

        if(animator == null) {
            Debug.LogError($"{name} is missing an animator");
        }

        if(enemyDetectionCollider == null) {
            Debug.LogError($"{name} is missing the enemy detection collider");
        }

        if(movingToIndicator == null) {
            Debug.LogError($"{name} is missing the movingToIndicator");
        }
    }

    void Start() {

        stateIdle = new PlayerStateIdle();
        stateMoving = new PlayerStateMoving();
        stateAttacking = new PlayerStateAttacking();
        stateGettingHit = new PlayerStateGettingHit();

        stateMachine = new StateMachine();
        stateMachine.SetState(stateIdle);
    }

    void Update() {
        if(GameManager.Instance.gameState != GameManager.GameStates.Playing) {
            return;
        }

        stateMachine.Tick();
    }

#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}