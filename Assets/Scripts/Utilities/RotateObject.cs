using UnityEngine;

namespace Team.One
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] private Transform objectToRotate;
        [SerializeField] private float rotationSpeed = 10f;
        void LateUpdate()
        {
            objectToRotate.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

}