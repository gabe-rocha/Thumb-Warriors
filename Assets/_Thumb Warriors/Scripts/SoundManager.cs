using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

#region Public Fields
    public AudioClip sfxWhistle, sfxIntro, sfxAww, sfxButtonStart, sfxButtonPlayAgain, sfxButtonQuit, sfxBallHitGround, sfxCheer, sfxFanfarre, sfxWrong, sfxCountdownBeep, sfxGameOver, sfxMathQuestionShow, sfxMathQuestionCorrect;
    public AudioClip bgmIntro;
    public AudioSource bgmAudioSource;
#endregion

#region Private Serializable Fields
#endregion

#region Private Fields
    private static SoundManager instance;

    public static SoundManager Instance { get => instance; set => instance = value; }

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }

        bgmAudioSource = GetComponent<AudioSource>();
        if(bgmAudioSource == null) {
            Debug.LogError($"{name} is missing audio source");
        }
    }
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void PlaySfx(AudioClip audioclip) {
        AudioSource.PlayClipAtPoint(audioclip, Camera.main.gameObject.transform.position);
    }

    internal void PlayBGMIntro() {
        bgmAudioSource.clip = bgmIntro;
        bgmAudioSource.Play();
    }

    internal void StopBGMIntro() {
        bgmAudioSource.Stop();
    }
#endregion
}