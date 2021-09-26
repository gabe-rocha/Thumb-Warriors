using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance { get => instance; set => instance = value; }

    public enum GameStates {
        Initializing,
        MainMenu,
        Loading,
        Playing,
    }
    public GameStates gameState = GameStates.Initializing;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            Application.targetFrameRate = 60;

        } else {
            Destroy(this);
        }
    }

    private void Start() {
        gameState = GameStates.Playing;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // EventManager.Instance.TriggerEvent(EventManager.Events.OnLevelStarted);
        }
    }
}