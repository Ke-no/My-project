using UnityEngine;

public class Giftbox : MonoBehaviour
{
    public GameObject ballPrefab;

    private int interactCount = 0;
    public void Interact()
    {
        interactCount++;

        Debug.Log("Interacted" + interactCount + "times(s)");

        if (interactCount >= 3)
        {
            if (ballPrefab != null)
            {
                Instantiate(ballPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        //if (collectiblePrefab != null)
        //{
        //Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
        //}
    }
}
