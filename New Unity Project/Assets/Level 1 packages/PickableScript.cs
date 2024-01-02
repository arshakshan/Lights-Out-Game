using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableScript : MonoBehaviour
{
    public GameObject PickupText;
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;

    [Space]
    [SerializeField] private float PickupRange;
    [SerializeField] private float PickupThreshold; // Threshold distance for pickup

    private Rigidbody CurrentObject;

    void Start()
    {
        PickupText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                PickupText.SetActive(false);
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;

                // Check if the hit point is within the threshold distance
                if (Vector3.Distance(CurrentObject.position, HitInfo.point) <= PickupThreshold)
                {
                    CurrentObject.useGravity = false;
                    PickupText.SetActive(true);
                }
                else
                {
                    CurrentObject = null;
                    PickupText.SetActive(false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
