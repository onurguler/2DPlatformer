using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360 * _speed * Time.deltaTime));        
    }
}
