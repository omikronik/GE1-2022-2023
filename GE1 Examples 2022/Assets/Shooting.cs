using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    Coroutine shootCR = null;

    public float fireRate = 5;

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.forward = -bullet.transform.forward;
            bullet.transform.position = bulletSpawn.position;
            bullet.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 3.0f);
            bullet.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1 / (float)fireRate);
            Debug.Log("Coroutine is being fired");
        }
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (Input.GetButtonDown("a"))
        {
            shootCR = StartCoroutine(ShootCoroutine());
        }
        
        if (Input.GetButtonUp("a"))
        {
            StopCoroutine(shootCR);
            shootCR = null;
        }

        //Debug.Log(context.performed);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
