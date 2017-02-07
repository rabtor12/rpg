using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseY = 1,
        MouseX = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    private float _rotationX;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private void Start()
    {
        var body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivityHor, 0);
        }
        else
        {
            if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y")*sensitivityHor;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                var rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y")*sensitivityHor;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                var delta = Input.GetAxis("Mouse X")*sensitivityHor;
                var rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}
