using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashManager : MonoBehaviour
{
    [Header("Flash")]
    public Canvas flashCanvas; // Assign the canvas in the Inspector

    public void ShowFlashEffect()
    {
        if (flashCanvas != null)
        {
            // Activate the canvas to show the flash effect
            flashCanvas.gameObject.SetActive(true);

            // Optionally, you can add any other customization or effects to the canvas here.
            // For example, you could fade out the canvas after a short delay to make the flash effect disappear.
            StartCoroutine(FadeOutCanvas());
        }
    }

    IEnumerator FadeOutCanvas()
    {
        // Wait for 0.5 seconds (adjust the time as needed)
        yield return new WaitForSeconds(0.5f);

        // Deactivate the canvas to hide the flash effect
        flashCanvas.gameObject.SetActive(false);
    }
}
