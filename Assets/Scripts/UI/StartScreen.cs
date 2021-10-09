using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Start()
    {
        SessionController.Input.OnStartTouth += OnTap;
    }

    private void Hide()
    {
        SessionController.Input.OnStartTouth -= OnTap;
        gameObject.SetActive(false);
    }
    
    private void OnTap()
    {
        SessionController.StartSession();
        Hide();
    }
}
