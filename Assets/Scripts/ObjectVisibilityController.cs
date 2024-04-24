using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public GameObject objectToShow;

    private void Start()
    {
        // Hide the object initially
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // If the ray hits an object
            if (hit.collider != null)
            {
                // Check if the hit object is the one we want to trigger visibility
                if (hit.collider.gameObject == gameObject)
                {
                    // Toggle the visibility of the object to show
                    if (objectToShow != null)
                    {
                        objectToShow.SetActive(!objectToShow.activeSelf);
                    }
                }
            }
        }
    }
}
