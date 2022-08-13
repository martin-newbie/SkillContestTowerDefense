using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public bool isMoveAble = true;

    void Start()
    {

    }

    void Update()
    {
        if (isMoveAble)
        {
            Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            MoveCamera(mousePos);
        }
    }


    void MoveCamera(Vector2 mousePos)
    {
        // y move
        if(mousePos.y >= 0.9f)
        {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
        }
        else if(mousePos.y <= 0.1f)
        {
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);
        }


        // x move
        if(mousePos.x >= 0.9f)
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        else if(mousePos.x <= 0.1f)
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(Vector3.down * wheel * cameraSpeed);

        float x = Mathf.Clamp(transform.position.x, -40f, 55f);
        float y = Mathf.Clamp(transform.position.y, 25f, 55f);
        float z = Mathf.Clamp(transform.position.z, -50f, 15f);

        transform.position = new Vector3(x, y, z);

    }
}
