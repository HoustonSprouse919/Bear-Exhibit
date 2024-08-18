using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
            Debug.Log("WORKED");
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //if colliders with anything within reach
        if (Physics.Raycast(ray, out hit, playerReach)){
            if(hit.collider.tag == "Interactable") //if looking at interactable
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                            else{
                DisableCurrentInteractable();
            }
            }
            else{
                DisableCurrentInteractable();
            }
        }

        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable){
        currentInteractable = newInteractable;
    }

    void DisableCurrentInteractable(){
        if(currentInteractable){
            currentInteractable = null;
        }
    }
}
