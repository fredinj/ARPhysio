using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;

public class GameManagerScript : MonoBehaviour
{
        // toast related variables
    public Text toastText;
    private float displayTime = 2f;


    public void ShowToast(string message)
    {
        toastText.text = message;
        toastText.enabled = true;
        StartCoroutine(HideToast());
    }

    private IEnumerator HideToast()
    {
        yield return new WaitForSeconds(displayTime);
        toastText.enabled = false;
    }

}
