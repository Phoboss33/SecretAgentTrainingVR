using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class SliceObj : MonoBehaviour
{
    public Transform startSlicePos;
    public Transform endSlicePos;
    public VelocityEstimator VelocityEstimator;
    public Material crossSectionMaterial;
    public LayerMask sliceablelayer;

    public float cutForce = 2000f;

    private void FixedUpdate() {
        bool hasHit = Physics.Linecast(startSlicePos.position, endSlicePos.position, out RaycastHit hit, sliceablelayer);
        if (hasHit) {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    public void Slice(GameObject target) {
        Vector3 velocity = VelocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePos.position - startSlicePos.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePos.position, planeNormal);


        if (hull != null) {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);
            upperHull.layer = 7;
            Destroy(upperHull, 2f);

            GameObject loverHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(loverHull);
            Destroy(loverHull, 2f);
            loverHull.layer = 7;

            Destroy(target);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject) {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = rb.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1f);
    }
}
