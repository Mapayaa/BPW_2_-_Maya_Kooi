using UnityEngine;
using UnityEngine.VFX;

public class AdjustVFXBounds : MonoBehaviour
{
    public VisualEffect vfx;
    public Vector3 centerOffset = Vector3.zero;
    public Vector3 boundsSize = new Vector3(10, 10, 10);

    void Start()
    {
        if (vfx == null)
        {
            vfx = GetComponent<VisualEffect>();
        }
        UpdateBounds();
    }

    void UpdateBounds()
    {
        if (vfx != null)
        {
            // Set the bounds center and size
            vfx.SetVector3("Bounds Center", centerOffset);
            vfx.SetVector3("Bounds Size", boundsSize);
        }
    }
}