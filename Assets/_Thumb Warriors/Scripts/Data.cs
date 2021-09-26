using System.Collections;
using System.Collections.Generic;

public static class Data {
    public enum Events {
        OnGameStarted,
        OnGamePaused,
        OnGameUnpaused,
        OnGameOver,
        OnGameManagerReady,
    }

    internal static int treeHealth = 30;
}