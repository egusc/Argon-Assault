using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 2f;
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;

    [SerializeField] float positionRollFactor = 2f;
    [SerializeField] float controlRollFactor = 30f;

    [SerializeField] float positionYawFactor = 12f;
    [SerializeField] float controlYawFactor = 20f;


    float horizontalMovement, verticalMovement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        float xOffset = (horizontalMovement * movementSpeed) * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = (verticalMovement * movementSpeed) * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(
        newXPos,
        newYPos,
        transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        float pitch = transform.localPosition.y * positionPitchFactor + verticalMovement * controlPitchFactor;
        float roll = transform.localPosition.z * positionRollFactor + horizontalMovement * controlRollFactor;
        float yaw = -180f + transform.localPosition.x * positionYawFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
