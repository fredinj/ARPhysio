using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCameraController : MonoBehaviour
{
    public ARCameraManager aRCameraManager;

    private void Awake()
    {
        aRCameraManager = FindObjectOfType<ARCameraManager>();
    }

    private void Start()
    {
        aRCameraManager = FindObjectOfType<ARCameraManager>();
    }

    private void Update()
    {

            aRCameraManager = FindObjectOfType<ARCameraManager>();
    
    }

    public void EnableARCamera()
    {
        aRCameraManager.enabled= true;
    }

    public void DisableARCamera()
    {
        aRCameraManager.enabled = false;
    }
}