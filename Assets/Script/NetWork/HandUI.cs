using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    public Transform follow;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, follow.position, 0);
    }
}
