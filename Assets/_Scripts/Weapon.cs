using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int rotationSpeed = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = rotationSpeed*Time.deltaTime;
        transform.RotateAround(Vector3.zero,Vector3.forward,rotationAmount);
        // rotationSpeed++;
        
    }
}
