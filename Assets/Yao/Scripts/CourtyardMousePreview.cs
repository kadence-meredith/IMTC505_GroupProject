using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

// Lets us try the same button in Game view without a headset.
[RequireComponent(typeof(Camera))]
public class CourtyardMousePreview : MonoBehaviour
{
    private Camera previewCamera;

    private void Awake()
    {
        previewCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (XRSettings.isDeviceActive || Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = previewCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                FireAlarm button = hit.collider.GetComponentInParent<FireAlarm>();
                if (button != null)
                    button.Press();
            }
        }
    }
}
