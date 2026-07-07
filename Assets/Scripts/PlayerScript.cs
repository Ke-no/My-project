using System; // Import standard .NET system types (not strictly needed here but common in C# files)
using UnityEngine; // Import Unity-specific classes like MonoBehaviour, GameObject, Collider, and print

public class PlayerScript : MonoBehaviour
{

    GameObject currentCollectible; // Store the collectible object the player is currently able to interact with
    GameObject currentDoor;
    GameObject currentGiftbox;
    GameObject currentBall;

    int playerScore = 0; // Keep track of how many points the player has collected so far

    [SerializeField]
    int targetScore = 0; // The goal score required to complete a task, editable from the Unity Inspector

void OnInteract()
{
    // Collectibles
    if(currentCollectible != null)
    {
        CollectibleScript collScript = currentCollectible.GetComponentInParent<CollectibleScript>();

        if(collScript == null)
        {
            print("Error: No CollectibleScript found on " + currentCollectible.name);
            return;
        }
        else
        {
            playerScore += collScript.collectibleScore;

            print("Player has collected " + playerScore + " points");

            collScript.Collect();

            currentCollectible = null;
        }
    }

    if(currentBall != null)
    {
        BallScript ballScript = currentBall.GetComponent<BallScript>();

        if(ballScript != null)
        {
            ballScript.Interact(transform);
        }
    }

    // Doors
    if(currentDoor != null)
    {
        DoorScript doorScript = currentDoor.GetComponent<DoorScript>();

        if(doorScript != null)
        {
            doorScript.Interact();
        }
    }

    // Giftbox
    if(currentGiftbox != null)
        {
            Giftbox giftbox = currentGiftbox.GetComponent<Giftbox>();

            if(giftbox != null)
            {
                giftbox.Interact();
                currentGiftbox = null;
            }
        }
}

    void OnTriggerEnter(Collider other) // Unity event called when another collider enters this GameObject's trigger collider
    {
        if(other.gameObject.tag == "Collectible") // Check if the object entering the trigger is tagged as a collectible
        {
            currentCollectible = other.GetComponentInParent<CollectibleScript>().gameObject; // Store the collectible GameObject so the player can interact with it later
        }

        if(other.gameObject.tag == "GoalArea" && playerScore >= targetScore) // Check if the player entered the goal area and has enough points
        {
            print("Player entered trigger zone with " + playerScore + " points"); // Print a success message when the player reaches the goal with enough score
        }
        
        if(other.CompareTag("Door"))
        {
            currentDoor = other.GetComponentInParent<DoorScript>()?.gameObject;
        }

        if(other.CompareTag("Giftbox"))
        {
            currentGiftbox = other.GetComponent<Giftbox>().gameObject;
        }

        if(other.CompareTag("Ball"))
        {
            currentBall = other.gameObject;
        }

    }

    void OnTriggerExit(Collider other) // Unity event called when another collider leaves this GameObject's trigger collider
    {
        if(other.gameObject == currentCollectible) // If the collectible leaving the trigger is the one we were tracking
        {
            currentCollectible = null; // Clear the current collectible because it is no longer in range
        }
        if(other.gameObject == currentDoor)
        {
            currentDoor = null;
        }
        if(other.gameObject == currentGiftbox)
        {
            currentGiftbox = null;
        }
        if(other.gameObject == currentBall)
        {
            currentBall = null;
        }
    }

}
