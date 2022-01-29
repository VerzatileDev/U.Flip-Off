using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;

    private void FixedUpdate()
    {
        transform.position = new Vector3(Target.position.x, 0 ,-10);
    }
}
