using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float sensetyCam = 5;
    Transform cameraTransform;
    Vector3 deltaPosCam;
    Vector3 target;

    void Start()
    {
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - player.position;
        deltaPosCam.z = -10;
    }

    void FixedUpdate()
    {
        target = player.transform.position + deltaPosCam;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, Time.deltaTime * sensetyCam);
    }
}
