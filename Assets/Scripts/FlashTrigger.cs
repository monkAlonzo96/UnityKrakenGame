using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTrigger : MonoBehaviour
{
    [Tooltip("Attach Canvas with Flash Manager script (attached to the Canvas) here.")]
    public FlashManager flashManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger, show the flash effect using the FlashManager
            flashManager.ShowFlashEffect();
        }
    }
}
