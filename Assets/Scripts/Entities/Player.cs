using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoveFeature moveComponent;
    [SerializeField] private JumpFeature jumpComponent;
    [SerializeField] private StackFeature stackComponent;
    [SerializeField] private GrowFeature growComponent;

    public event Action OnDead = delegate { };
    
    private void Awake()
    {
        CheckComponents();
        SessionController.RegisterPlayer(this);
    }

    public void StartMove()
    {
        moveComponent.StartMove();
        SessionController.Input.OnEndTouth += jumpComponent.Jump;
    }

    public void StopMove()
    {
        moveComponent.StopMove();
        SessionController.Input.OnEndTouth -= jumpComponent.Jump;
    }

    public void PickCube(Cube cube)
    {
        cube.Pick();
        stackComponent.Push(cube);
        growComponent.Grow();
    }

    public void DropCube()
    {
        if (stackComponent.Count <= 1)
        {
            Kill();
            return;
        }
        
        var droppedCube = stackComponent.Pop();
        droppedCube.Drop();
        growComponent.Decrease();
    }
    
    public void Kill()
    {
        Debug.Log("Player : Player is dead!");
        StopMove();
        OnDead.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        jumpComponent.Land();
    }

    private void CheckComponents()
    {
        if (moveComponent == null)
        {
            Debug.LogError("Player : Not specified move component!");
        }
        if (jumpComponent == null)
        {
            Debug.LogError("Player : Not specified jump component!");
        }
        if (stackComponent == null)
        {
            Debug.LogError("Player : Not specified stack component!");
        }
        if (growComponent == null)
        {
            Debug.LogError("Player : Not specified grow component!");
        }
    }
}
