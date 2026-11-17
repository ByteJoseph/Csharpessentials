using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _clouds;
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _XLimit = 12.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Cloud at index 0 " + _clouds[0]);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<_clouds.Length;i++)
        {
            _clouds[i].position += Vector3.right * Time.deltaTime *_speed;
            if (_clouds[i].position.x > _XLimit)
            {
                _clouds[i].position -= new Vector3(2*_XLimit, 0, 0);
            }

        }
    }
}
