using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetectionCollider : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        //component = GetComponent<Component>();
        //if(component == null) {
        //Debug.LogError($"{name} is missing a component");
        //}

    }

    void Start() {

    }

    void Update() {

    }
#endregion

#region Private Methods
    private void OnTriggerEnter(Collider obj) {

        if(obj.CompareTag("Enemy")) {
            Debug.Log($"Enemy is in Range!");
            EventManager.Instance.TriggerEventWithGOParam(EventManager.Events.EnemyDetected, obj.gameObject);
        }

    }
#endregion

#region Public Methods

#endregion
}