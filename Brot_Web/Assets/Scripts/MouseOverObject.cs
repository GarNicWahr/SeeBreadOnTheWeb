using UnityEngine;
using UnityEngine.UI;

public class MouseOverUIActivator : MonoBehaviour
{
    public Camera mainCamera;  // Ziehe hier die Main Camera rein
    public GameObject uiElement; // Ziehe hier dein UI-Element rein (z. B. ein Panel)
    public LayerMask interactableLayer; // Setze in Unity einen Layer für deine Objekte

    private bool isHovering = false;

    void Update()
    {
        CheckMouseOver();
    }

    void CheckMouseOver()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            if (!isHovering) // Nur bei neuem Hover aktivieren
            {
                isHovering = true;
                uiElement.SetActive(true); // UI einschalten
                Debug.Log("Mouse is over: " + hit.collider.gameObject.name);
            }
        }
        else
        {
            if (isHovering) // Nur bei Verlassen deaktivieren
            {
                isHovering = false;
                uiElement.SetActive(false); // UI ausschalten
                Debug.Log("Mouse left object");
            }
        }
    }
}
