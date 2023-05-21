using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform targetToFollow;

    void Update()
    {
        transform.position = new Vector3(targetToFollow.position.x, targetToFollow.position.y, transform.position.z);
    }
}
