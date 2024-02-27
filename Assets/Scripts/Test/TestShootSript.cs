using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TestShootSript : MonoBehaviour {
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public GameObject pistol;

    [SerializeField]
    private TrailRenderer BulletTrail;

    private void Start() {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Fire);
        //grabInteractable.selectEntered.AddListener(ActivatePistolInHand);
        //grabInteractable.selectExited.AddListener(Deactivate);

        grabInteractable.selectExited.RemoveListener(OnSelectExited);

    }

    private void OnSelectExited(SelectExitEventArgs arg0) {
        throw new NotImplementedException();
    }

    private void ActivatePistolInHand(SelectEnterEventArgs arg0) {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null && grabInteractable.interactorsSelecting.Count > 0) {
            XRBaseInteractor handInteractor = (XRBaseInteractor)grabInteractable.GetOldestInteractorSelecting();
            GameObject handObject = handInteractor.attachTransform.gameObject;

            // Создаем новый объект
            GameObject newObject = Instantiate(pistol, handInteractor.transform.position,
                handInteractor.transform.rotation);

            // Получаем XRGrabInteractable нового объекта
            XRGrabInteractable newGrabInteractable = newObject.GetComponent<XRGrabInteractable>();

            // Если текущий объект выбран, отменяем его выбор и удаляем его
            if (grabInteractable.isSelected) {
                grabInteractable.interactorsSelecting.Remove(handInteractor);
                if (grabInteractable.gameObject != null) {
                    Destroy(grabInteractable.gameObject);
                }
            }

            // Выбираем новый объект
            if (!newGrabInteractable.interactorsSelecting.Contains(handInteractor)) {
                newGrabInteractable.interactorsSelecting.Add(handInteractor);
            }
        }
    }
    public GameObject obj;
    public void Deactivate() {
        // Получите все дочерние объекты
        obj.SetActive(true);
    }

    public void Fire(ActivateEventArgs arg) {
        //GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
        //spawnedBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward.normalized * fireSpeed, ForceMode.Impulse);
        //Destroy(spawnedBullet, 2f);

        RaycastHit hit;
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);

        //Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.red, 5.0f);
        

        if (Physics.Raycast(ray, out hit)) {
            CheckForObj(hit.collider.gameObject);

            
            TrailRenderer trail = Instantiate(BulletTrail, ray.origin, transform.rotation);
            StartCoroutine(SpawnTrail(trail, hit, ray));

            
        }
        

    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit, Ray ray) {
        float time = 0;

        while (time < 1) {
            Trail.transform.position = Vector3.Lerp(ray.origin, hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        //Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));
    }

    private Vector3 GetDirection() {
        Vector3 direction = transform.forward;
        direction.Normalize();

        return direction;
    }

    private void CheckForObj(GameObject hitObject) {
        if (hitObject.CompareTag("Target")) {
            Target target = hitObject.GetComponent<Target>();
            target.Kill();
        }
    }
}