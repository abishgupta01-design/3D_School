using UnityEngine;

public class VehicleEnterExit : MonoBehaviour
{
    [Header("Player References")]
    public GameObject player;
    public Camera playerCamera;

    [Header("Bus References")]
    public Camera busCamera;
    public Transform exitPoint;

    private bool playerNear = false;
    private bool insideBus = false;

    private BusController busController;

    void Start()
    {
        // Get BusController attached to this bus
        busController = GetComponent<BusController>();

        // Check if BusController exists
        if (busController == null)
        {
            Debug.LogError("BusController script is missing on the bus!");
        }

        // Make sure bus camera starts OFF
        if (busCamera != null)
        {
            busCamera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Press E to enter or exit
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!insideBus)
            {
                EnterBus();
            }
            else
            {
                ExitBus();
            }
        }
    }

    void EnterBus()
    {
        insideBus = true;

        // Hide player
        if (player != null)
        {
            player.SetActive(false);
        }

        // Switch cameras
        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false);
        }

        if (busCamera != null)
        {
            busCamera.gameObject.SetActive(true);
        }

        // Enable driving
        if (busController != null)
        {
            busController.SetDriving(true);
        }

        Debug.Log("Entered Bus");
    }

    void ExitBus()
    {
        insideBus = false;

        // Move player outside bus
        if (player != null && exitPoint != null)
        {
            player.transform.position = exitPoint.position;

            player.SetActive(true);
        }

        // Switch cameras back
        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(true);
        }

        if (busCamera != null)
        {
            busCamera.gameObject.SetActive(false);
        }

        // Disable driving
        if (busController != null)
        {
            busController.SetDriving(false);
        }

        Debug.Log("Exited Bus");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            Debug.Log("Player Near Bus - Press E");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            Debug.Log("Player Left Bus Area");
        }
    }
}