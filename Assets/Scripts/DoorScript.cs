using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator doorAnimator;

    bool isOpen = false;

    void Start()
    {
        // Find Animator on this object or child objects
        doorAnimator = GetComponentInChildren<Animator>();

        if(doorAnimator == null)
        {
            print("No Animator found on door!");
        }
    }

public void Interact()
{
    isOpen = !isOpen;

    if(isOpen)
        doorAnimator.Play("DoorOpen");
    else
        doorAnimator.Play("DoorClose");
}
}