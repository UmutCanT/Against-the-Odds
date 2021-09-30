using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveSpeed = GetComponent<PlayerCharacter>().MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGameOver)
        {
            Vector3 mousePos = GetMouseWorldPos(Input.mousePosition, Camera.main);
            transform.eulerAngles = new Vector3(0, AngleOfAim(mousePos), 0);
            PlayerMovement();
            Shooting();
        }
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

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
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
            }
        }
    }

    float AngleOfAim(Vector3 mousePos)
    {
        return Mathf.Atan2(DirectionOfAim(mousePos).y, DirectionOfAim(mousePos).x) * Mathf.Rad2Deg;
    }

    Vector3 GetMouseWorldPos(Vector3 screenPos, Camera mainCam)
    {
        Vector3 pos = mainCam.ScreenToWorldPoint(screenPos);
        pos.z = 0;
        return pos;
    }

    Vector3 DirectionOfAim(Vector3 mousePos)
    {
        return (mousePos - transform.position).normalized;
    }
}
