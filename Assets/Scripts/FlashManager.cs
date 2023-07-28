using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashManager : MonoBehaviour
{
    [Header("Flash")]
    public GameObject flashPrefab;

    public void ShowFlashEffect()
    {
        if (flashPrefab != null)
        {
            // Instantiate the flash prefab at the center of the screen (you can change the position as needed)
            Vector3 spawnPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            GameObject flashInstance = Instantiate(flashPrefab, spawnPosition, Quaternion.identity);

            // Optionally, you can set the parent of the instantiated object to a canvas or other GameObject in your scene.
            // flashInstance.transform.SetParent(parentTransform);

            // Optionally, you can add any other customization or effects to the instantiated object here.
        }
    }
}
