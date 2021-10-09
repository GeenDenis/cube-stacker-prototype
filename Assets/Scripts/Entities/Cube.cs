using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer rendererComponent;
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private Collider triggerComponent;
    [SerializeField] private Material neutralCubeMaterial;
    [SerializeField] private Material pickedCubeMaterial;

    private void Awake()
    {
        CheckComponents();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Player player))
        {
            return;
        }

        player.PickCube(this);
    }

    public void Drop()
    {
        rendererComponent.sharedMaterial = neutralCubeMaterial;
        triggerComponent.enabled = true;
        triggerComponent.isTrigger = false;
        rigidbodyComponent.isKinematic = false;
    }

    public void Pick()
    {
        rendererComponent.sharedMaterial = pickedCubeMaterial;
        triggerComponent.enabled = false;
    }

    private void CheckComponents()
    {
        if (rendererComponent == null)
        {
            Debug.LogError("Cube : Not specified render component!");
        }
        if (rigidbodyComponent == null)
        {
            Debug.LogError("Cube : Not specified rigidbody component!");
        }
        if (triggerComponent == null)
        {
            Debug.LogError("Cube : Not specified collider component!");
        }
    }
}
