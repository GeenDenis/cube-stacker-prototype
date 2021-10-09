using UnityEngine;

public class JumpFeature : MonoBehaviour
{
    [SerializeField] private Rigidbody rbComponent;
    [SerializeField] private Vector3 relativeJumpVector;
    [SerializeField] private float durationTouchLimit;

    private float jumpPower;

    private void Awake()
    {
        if (rbComponent == null)
        {
            Debug.LogError("JumpFeature : Not specified rigidbody component!");
        }
    }

    public void Jump(float durationTouch)
    {
        var jumpPower = Mathf.InverseLerp(0f, durationTouchLimit, durationTouch);
        var jumpVector = transform.up + relativeJumpVector * jumpPower;
        rbComponent.AddForce(jumpVector, ForceMode.Impulse);
    }
}
