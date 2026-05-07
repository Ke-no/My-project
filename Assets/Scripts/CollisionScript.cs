using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static int collectedCount = 0;
    public static int totalCollectibles = 6;
    private bool collected = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collected) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collected = true;
            collectedCount++;

            Debug.Log("Collected: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}