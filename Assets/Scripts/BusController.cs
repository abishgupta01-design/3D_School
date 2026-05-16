using UnityEngine;

public class BusController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 50f;

    private bool canDrive = false;

    void Update()
    {
        if (!canDrive) return;

        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);
    }

    public void SetDriving(bool driving)
    {
        canDrive = driving;
    }
}