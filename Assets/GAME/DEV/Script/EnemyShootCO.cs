using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootCO : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPoint;
    bool isShootingOn;

    private void Start()
    {
        isShootingOn = true;
        StartCoroutine(SpawnBullets());
    }
    private void CreateBullet()
    {
        GameObject bulletGO = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        Rigidbody bulletRb = bulletGO.GetComponent<Rigidbody>();
        bulletRb.velocity = Vector3.back * 10;
        Destroy(bulletGO, 5f);
    }

    IEnumerator SpawnBullets()
    {
        while (isShootingOn)
        {
            CreateBullet();
            yield return new WaitForSeconds(1);
        }
    }
}
