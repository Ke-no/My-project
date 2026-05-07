using UnityEngine;

public class TriggerZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Collectible.collectedCount >= Collectible.totalCollectibles)
            {
                Debug.Log("You have collected all objects");
            }
            else
            {
                Debug.ClearDeveloperConsole();
                Debug.Log("You have not collected all the objects yet");
            }
        }
    }
}