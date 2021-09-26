using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAndSpread : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    private Vector3 startScale;
    private Vector3 startPosition;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        startPosition = transform.position;
        startScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    void Start() {
        LeanTween.move(gameObject, new Vector3(startPosition.x + Random.Range(-1f, 1f), startPosition.y, startPosition.z + Random.Range(-1f, 1f)), Time.deltaTime);
        LeanTween.scale(gameObject, startScale, Time.deltaTime).setEase(LeanTweenType.easeOutBounce);
    }

    void Update() { }
#endregion

#region Private Methods
#endregion

#region Public Methods

#endregion
}