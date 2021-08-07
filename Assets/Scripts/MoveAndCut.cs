using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveAndCut : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    Vector3 startPosition;
    Quaternion startRotation;
    bool dragging;
    float zCoords;
    RaycastHit hit;
    public LayerMask layerMask;
    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        AxisSaver.dragging = true;
        dragging = true;
        zCoords = mainCamera.WorldToScreenPoint(transform.position).z;
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    private void OnMouseDrag()
    {

        if (dragging)
        {
            Vector3 mouseInput = Input.mousePosition;
            mouseInput.z = zCoords;
            transform.position = mainCamera.ScreenToWorldPoint(mouseInput);
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, layerMask))
            {
                Debug.Log(hit.transform.name);
                hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                ActionsToBePerformed();
            }
        }

    }


    private void OnMouseUp()
    {
        AxisSaver.dragging = false;
        dragging = false;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
    }

    void ActionsToBePerformed()
    {
        // Write any action you want to happen under here
    }


}
