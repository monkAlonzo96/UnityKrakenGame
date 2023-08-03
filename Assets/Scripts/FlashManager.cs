using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashManager : MonoBehaviour
{
    [Header("Flash")]
    [Tooltip("Attach Canvas here.")]
    public Canvas flashCanvas; // Assign the canvas in the Inspector
    [Header("Duration & Timer")]
    [Tooltip("Set the desired Duration the Flash appears here.")]
    public float flashDuration = 0.5f; // Set the duration of the flash effect in seconds
    [Tooltip("Set the desired Time the Flash appears here.")]
    public float flashTimer = 1.0f; // Set the duration of the fade-out effect in seconds

    public void ShowFlashEffect()
    {
        if (flashCanvas != null)
        {
            // Activate the canvas to show the flash effect
            flashCanvas.gameObject.SetActive(true);

            // Start the flash effect 
            StartCoroutine(FlashCoroutine());
        }
    }

    private IEnumerator FlashCoroutine()
    {
        // Wait for the flash duration
        yield return new WaitForSeconds(flashDuration);

        // Start the fade-out effect
        float elapsedTime = 0f;
        CanvasGroup canvasGroup = flashCanvas.GetComponent<CanvasGroup>();
        float startAlpha = 1f;

        while (elapsedTime < flashTimer)
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / flashTimer;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, percentage);
            yield return null;
        }

        // Deactivate the canvas to hide the flash effect
        flashCanvas.gameObject.SetActive(false);
    }
}
