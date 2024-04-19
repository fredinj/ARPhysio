using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public float glowIntensity = 1.0f; // Public variable to control glow intensity

    private Material material;
    private bool isGlowing = false;

    void Start()
    {
        // Get the material of the object
        material = GetComponent<Renderer>().material;
        material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        // Check if the glow intensity has changed
        if (material.GetFloat("_EmissionStrength") != glowIntensity)
        {
            // Update the glow intensity in the material
            material.SetFloat("_EmissionStrength", glowIntensity);
            isGlowing = (glowIntensity > 0.0f);
        }

        // Check if the object is glowing or not
        if (isGlowing)
        {
            // Set the emission color to the object's color multiplied by the glow intensity
            material.SetColor("_EmissionColor", material.color * glowIntensity);
        }
        else
        {
            // Set the emission color to black (no glow)
            material.SetColor("_EmissionColor", Color.black);
        }
    }
}