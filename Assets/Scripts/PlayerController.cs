using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    float moveSpeed;
    Transform aimTransform;
    Vector3 camOffset;
    float horizontalInput;
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveSpeed = GetComponent<PlayerCharacter>().MoveSpeed;
        camOffset = FindObjectOfType<CamHandler>().GetComponent<CamHandler>().CamOffset;
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGameOver)
        {
            Vector3 mousePos = GetMouseWorldPos(Input.mousePosition, Camera.main);
            aimTransform.eulerAngles = new Vector3(0, AngleOfAim(mousePos), 0);
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Shooting();
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.Translate(horizontalInput * Vector3.right * moveSpeed * Time.deltaTime);
        transform.Translate(verticalInput * Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.projectiles, ObjectPooling.instance.AmountofObject(2));
            if (projectile != null)
            {
                projectile.transform.position = aimTransform.position;
                projectile.transform.rotation = aimTransform.rotation;
                projectile.SetActive(true);
            }
        }
    }

    float AngleOfAim(Vector3 mousePos)
    {
        return Mathf.Atan2(-DirectionOfAim(mousePos).z, DirectionOfAim(mousePos).x) * Mathf.Rad2Deg;
    }

    Vector3 GetMouseWorldPos(Vector3 screenPos, Camera mainCam)
    {
        Vector3 pos = mainCam.ScreenToWorldPoint(screenPos);
        pos -= camOffset;       
        return pos;
    }

    Vector3 DirectionOfAim(Vector3 mousePos)
    {
        return (mousePos - transform.position).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveSpeed = 1;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveSpeed = GetComponent<PlayerCharacter>().MoveSpeed;
        }      
    }
}
