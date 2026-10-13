using Team.One;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Team.Two
{
    public class EventTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<XROrigin>(out XROrigin xrOrigin);
            if (xrOrigin != null)
            {
                Steps.Instance.PlayNextStep();
            }
        }
    }
}