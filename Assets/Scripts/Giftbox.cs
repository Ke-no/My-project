using UnityEngine;

public class Giftbox : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public void Interact()
    {
        if (collectiblePrefab != null)
        {
        Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
