using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDist;
    public TextMeshProUGUI interactionText;
    public GameObject speechBubble;
    public Camera cam;

    private void Start()
    {
        
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;

        bool sucessHit = false;

        if (Physics.Raycast(ray, out hit, interactionDist))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            HandleInteraction(interactable);
            interactionText.text = interactable.GetDescription();
            speechBubble.SetActive(true);
            sucessHit = true;
        }

        if (!sucessHit)
        {
            speechBubble.SetActive(false);
        }

        void HandleInteraction(Interactable interactable)
        {
            KeyCode key = KeyCode.E;
            if (Input.GetKeyDown(key))
            {
                interactable.Interact();
            }
        }
    }
}
