using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System;

public class TestTakeSCript : MonoBehaviour {
    public GameObject pistol;

    private void Start() {
        //XRBaseInteractable baseInteractable = GetComponent<XRBaseInteractable>();

        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        socket.hoverEntered.AddListener(ReactToInteraction);
        socket.hoverExited.AddListener(DeactivateGun);
        pistol.SetActive(false);
    }

    private void DeactivateGun(HoverExitEventArgs arg0) {
        pistol.SetActive(false);
    }

    private void ReactToInteraction(HoverEnterEventArgs arg0) {
        pistol.SetActive(true);
    }
}
