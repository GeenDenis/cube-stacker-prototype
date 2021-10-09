using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private float touchTime = 0f;
    public bool OnTouch { get; private set; }

    public event Action OnStartTouth = delegate { };
    public event Action<float> OnEndTouth = delegate (float touchTime) { };

    private void Awake()
    {
        SessionController.RegisterInput(this);
    }

    public void SetActiveInput(bool value)
    {
        enabled = value;
    }
    
    private void Update()
    {
        if (!OnTouch && CheckTouth())
        {
            OnTouch = true;
            OnStartTouth.Invoke();
        }
        
        if (OnTouch && !CheckTouth())
        {
            OnTouch = false;
            OnEndTouth.Invoke(touchTime);
            touchTime = 0f;
        }

        if (OnTouch)
        {
            touchTime += Time.deltaTime;
        }
    }
    
    private static bool CheckTouth()
    {
#if UNITY_EDITOR
        return Input.GetButton("Jump");
#else
        return Input.touchCount > 0;
#endif
    }
}
