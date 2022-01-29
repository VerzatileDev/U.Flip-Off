using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;

    private void FixedUpdate()
    {
        transform.position = new Vector2(Target.position.x, Target.position.y);
    }
}
