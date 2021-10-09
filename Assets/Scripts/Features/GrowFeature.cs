using Sirenix.OdinInspector;
using UnityEngine;

public class GrowFeature : MonoBehaviour
{
    [SerializeField] private BoxCollider colliderComponent;
    [SerializeField] private Vector3 stepVector;

    private void Awake()
    {
        if (colliderComponent == null)
        {
            Debug.LogError("GrowFeature : Not specified collider component!");
        }
    }

    [Button]
    public void Grow(int times = 1)
    {
        var growVector = stepVector * times;
        colliderComponent.transform.position += growVector;
        colliderComponent.center -= growVector;
    }

    [Button]
    public void Decrease(int times = 1)
    {
        var decreaseVector = stepVector * times;
        colliderComponent.center += decreaseVector;
    }
}
