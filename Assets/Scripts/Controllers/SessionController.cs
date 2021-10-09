using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SessionController
{
    private static Player registredPlayer;
    private static InputController registredInput;
    private static Finish registredFinish;

    public static Player Player => registredPlayer;
    public static InputController Input => registredInput;
    public static Finish Finish => registredFinish;
    
    public static void RegisterPlayer(Player player)
    {
        if (registredPlayer != null)
        {
            Debug.LogError("SessionController : There are 2 players on the scene!");
            return;
        }
        
        registredPlayer = player;
        player.OnDead += EndSession;
    }

    public static void RegisterFinish(Finish finish)
    {
        if (registredFinish != null)
        {
            Debug.LogError("SessionController : There are 2 finishes on the scene!");
            return;
        }

        registredFinish = finish;
        registredFinish.OnPlayerFinished += EndSession;
    }
    
    public static void RegisterInput(InputController input)
    {
        if (registredInput != null)
        {
            Debug.LogError("SessionController : There are 2 input controllers on the scene!");
            return;
        }
        
        registredInput = input;
    }

    public static void StartSession()
    {
        registredPlayer.StartMove();
    }
    
    public static void EndSession()
    {
        registredPlayer.StopMove();
    }

    public static void RestartScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
