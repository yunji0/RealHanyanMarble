using UnityEngine;

public class Y_Movement3D : MonoBehaviour
{
    private float moveSpeed = 1f;
    private Vector3 moveDirection = Vector3.zero;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

}