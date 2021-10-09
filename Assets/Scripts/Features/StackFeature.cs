using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackFeature : MonoBehaviour
{
    [SerializeField] private Transform stackContainer;
    [SerializeField] private Vector3 step;
    [SerializeField] private List<Cube> stack;
    public int Count => stack.Count;
    
    private void Awake()
    {
        if (stackContainer == null)
        {
            Debug.LogError("StackFeature : Not specified stack container!");
        }
    }

    public void Push(Cube obj)
    {
        obj.transform.SetParent(stackContainer);
        obj.transform.localPosition = step * Count;
        stack.Add(obj);
    }

    public Cube Pop()
    {
        Cube popObject = null;
        
        if (Count > 0)
        {
            popObject = stack.Last();
            popObject.transform.SetParent(null);
            stack.Remove(popObject);
        }

        return popObject;
    }
}
