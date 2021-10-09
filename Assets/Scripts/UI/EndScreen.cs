using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        SessionController.Finish.OnPlayerFinished += Show;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        SessionController.Input.OnStartTouth += OnTap;
    }
    
    private void OnTap()
    {
        SessionController.RestartScene();
    }
}
