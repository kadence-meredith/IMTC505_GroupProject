using UnityEngine;

public class materialChangeTouch : MonoBehaviour
{
    [Header("New Material")]
    public Material newMaterial;
    [Header("Material to Change")]
    public int materialIndex = 0;
    [Header("Object Tag to Cause Change")]
    public string targetTag = "Cylinder";

    private void OnCollisionEnter(Collision collision)
    {
        // Check tag filter
        if (!string.IsNullOrEmpty(targetTag) && !collision.gameObject.CompareTag(targetTag))
            return;

        if (TryGetComponent(out Renderer renderer) && newMaterial != null)
        {
            // Swap out the specific material index
            Material[] mats = renderer.materials;
            if (materialIndex < mats.Length)
            {
                mats[materialIndex] = newMaterial;
                renderer.materials = mats;
            }
        }
    }
}
