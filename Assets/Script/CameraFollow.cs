using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * 2);
        transform.position = _target.position + _offset;
    }
}
