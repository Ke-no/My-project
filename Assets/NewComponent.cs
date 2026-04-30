using UnityEngine;

public class NewComponent : MonoBehaviour
{

    //Vector3 newPosition = new Vector3(0.05f, 0f, 0.05f);

    public Vector3 moveDirection = new Vector3(2f, 0f, 2f);
    public float xLimit = 5f;
    public float yLimit = 5f;
    public float zLimit = 5f;

    public Vector3 rotationSpeed = new Vector3(0f, 60f, 0f); //degrees per second
    public float rotationLimit = 45f;

    private float currentYRotation = 0f;
    private int rotationDirection = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(transform.position.x);
        print(transform.position.y);
        print(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * 60f;

        if (Mathf.Abs(transform.position.x) > xLimit)
            moveDirection.x *= -1;
        

        if (Mathf.Abs(transform.position.y) > yLimit)
            moveDirection.y *= -1;


        if (Mathf.Abs(transform.position.z) > zLimit)
            moveDirection.z *= -1;
        
        // --- Rotation --- //
        float rotationStep = rotationSpeed.y * rotationDirection * Time.deltaTime;
        transform.Rotate(0f, rotationStep, 0f);

        currentYRotation += rotationStep;

        // Reverse rotation when hit limit
        if (Mathf.Abs(currentYRotation) >= rotationLimit)
        {
            rotationDirection *= -1;
        }
    }
}
