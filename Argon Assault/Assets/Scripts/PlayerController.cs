using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Settings")]

    [Tooltip("Speed player moves around the screen (float)")] 
    [SerializeField] float movementSpeed = 5f;
    
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 2f;
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float positionRollFactor = 2f;
    [SerializeField] float controlRollFactor = 30f;

    [SerializeField] float positionYawFactor = 12f;
    [SerializeField] float controlYawFactor = 20f;

    [Header("Weapon settings")]
    [SerializeField] GameObject[] lasers;




    const int LEFT_CLICK = 0;


    float horizontalMovement, verticalMovement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
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

    private void ProcessFiring()
    {
        // if pushing fire button then print shooting
        //else dont

        if(Input.GetMouseButton(LEFT_CLICK))
        {
            SetLasersActive(true);

        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
