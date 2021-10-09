using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFeature : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody rbComponent;

    private void Awake()
    {
        rbComponent = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveVector = transform.forward * speed * Time.fixedDeltaTime;
        var moveTo = transform.position + moveVector;
        rbComponent.MovePosition(moveTo);
    }
}
