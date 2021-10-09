using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private Vector3 relativeCameraPosition;
    [SerializeField] private Vector3 relativeCameraRotation;

    private void Start()
    {
        if (followObject == null)
        {
            followObject = SessionController.Player.gameObject;
        }
    }
    
    private void LateUpdate()
    {
        var followObjectPosition = followObject.transform.position;
        followObjectPosition = new Vector3(followObjectPosition.x, 0f, followObjectPosition.z);
        
        transform.position = followObjectPosition + relativeCameraPosition;
        transform.rotation.SetLookRotation(relativeCameraRotation);
    }
}
