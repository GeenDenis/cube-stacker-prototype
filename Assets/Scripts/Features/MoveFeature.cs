using UnityEngine;

public class MoveFeature : MonoBehaviour
{
    [SerializeField]private Rigidbody rbComponent;
    [SerializeField] private float speed = 3f;

    private void Awake()
    {
        if (rbComponent == null)
        {
            Debug.LogError("MoveFeature : Not specified rigidbody component!");
        }
    }
    
    public void StartMove(float speed = 0f)
    {
        if (speed > 0f)
        {
            this.speed = speed;
        }
        enabled = true;
    }

    public void StopMove()
    {
        enabled = false;
    }
    
    void FixedUpdate()
    {
        var moveVector = transform.forward * speed;
        var moveTo = transform.position + moveVector;
        rbComponent.MovePosition(moveTo);
    }
}
