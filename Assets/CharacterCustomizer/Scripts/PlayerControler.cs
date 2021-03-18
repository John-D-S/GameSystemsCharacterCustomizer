using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jetpackForce;
    private bool grounded;
    private float currentFuel = 3;
    //private GameObject fuelGauge;
    private bool jetpackEnabled;

    [SerializeField]
    private float sprintMuliplier = 2;
    [SerializeField]
    private float jumpHeight = 5;
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float maxFuel = 3;
    [SerializeField]
    private float jetpackMaxForce = 15;
    [SerializeField]
    private GameObject flame;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private GameObject fuelGauge;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*
        foreach (Transform child in transform)
        {
            if (child.tag == "fuelGauge")
            {
                fuelGauge = child.gameObject;
                break;
            }
        }
        */
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += Vector2.up * jumpHeight;
            //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonUp("Jump") && !grounded)
        {
            jetpackEnabled = true;
        }
        else if (Input.GetButton("Jump") && !grounded && jetpackEnabled && currentFuel > 0)
        {
            if (currentFuel > 0)
            {
                flame.SetActive(true);
                jetpackForce = jetpackMaxForce;
                currentFuel -= Time.deltaTime;
            }
        }
        else
        {
            jetpackForce = 0;
            flame.SetActive(false);
        }

        flame.transform.rotation = Quaternion.identity;
        camera.transform.rotation = Quaternion.identity;

        fuelGauge.transform.localScale = Vector3.one * (currentFuel / maxFuel);
    }

    void FixedUpdate()
    {
        rb.AddTorque(-Input.GetAxis("Horizontal") * moveSpeed);
        rb.AddForce(Vector2.up * jetpackForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        jetpackEnabled = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("we're colliding");
        if (collision.gameObject.tag == "Ground" && currentFuel < maxFuel)
        {
            currentFuel += Time.deltaTime * 0.5f;
        }
        else if (currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    public void raiseStat(int value)
    {
        switch (value)
        {
            case 1:
                moveSpeed += 1;
                break;
            case 2:
                jumpHeight += 1;
                break;
            case 3:
                maxFuel += 1;
                break;
            case 4:
                jetpackForce += 1;
                break;
        }
    }

    public void lowerStat(int value)
    {
        switch (value)
        {
            case 1:
                moveSpeed -= 1;
                break;
            case 2:
                jumpHeight -= 1;
                break;
            case 3:
                maxFuel -= 1;
                break;
            case 4:
                jetpackForce -= 1;
                break;
        }
    }
}
