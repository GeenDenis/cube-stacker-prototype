using System;using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action OnPlayerFinished = delegate { };
    
    private void Awake()
    {
        SessionController.RegisterFinish(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Player player))
        {
            return;
        }
        
        OnPlayerFinished.Invoke();
    }
}
