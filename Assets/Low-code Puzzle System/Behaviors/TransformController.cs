using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    [Tooltip("Automatically set to the transform's parent on Start")]
    public Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
    }

    public void SetParent(Transform newParent)
    {
        transform.parent = newParent;
    }

    public void Unparent()
    {
        transform.parent = null;
    }

    public void ReturnToOriginalParent()
    {
        if(originalParent != null) 
            transform.parent = originalParent;
    }
}
