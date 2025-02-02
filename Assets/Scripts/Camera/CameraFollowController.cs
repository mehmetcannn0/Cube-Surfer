using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform heroTransform;
    private Vector3 cameraOffset;
    private Vector3 newPosition;
    [SerializeField] private float lerpValue;

    void Start()
    {
        cameraOffset = transform.position - heroTransform.position;
    }

    private void LateUpdate()
    {
        SetCameraSmoothFallow();
    }
    private void SetCameraSmoothFallow()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f,heroTransform.position.y,heroTransform.position.z)+cameraOffset, lerpValue*Time.deltaTime );
        transform.position = newPosition; 
    }
}
