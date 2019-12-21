using UnityEngine;

public class FullRotation : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;

    private Transform _transform;

    private float _startRotation;

    private float _endRotation;
    // Update is called once per frame

    private void Awake()
    {
        _transform = transform;
        var rotation = _transform.rotation;
        _startRotation = rotation.z;
        _endRotation = rotation.z + 360;
    }

    void Update()
    {
        //_transform.rotation = Qu
    }
}
