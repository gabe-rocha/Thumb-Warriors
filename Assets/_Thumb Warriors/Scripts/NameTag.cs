using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameTag : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private TextMeshProUGUI text;
#endregion

#region Private Fields

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        //component = GetComponent<Component>();
        //if(component == null) {
        //Debug.LogError($"{name} is missing a component");
        //}

        text.enabled = true;
    }

    void Start() {

    }

    void Update() {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        text.transform.position = screenPos;
    }
#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}