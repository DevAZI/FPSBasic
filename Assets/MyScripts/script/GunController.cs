using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    public Gun currentGun;

    public Rigidbody prefabBullet;
    public float bulletForce = 1000.0f;

    public  float currentFireRate;

    public bool isReload = false;


    // ���� ������ ��.
    
    public Vector3 originPos;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
        TryFire();
        TryReload();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentGun.anim.SetTrigger("Run");
        }
      

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentGun.anim.SetTrigger("Walk");
        }
        if(Input.GetMouseButton(0))
        {
            currentGun.anim.SetTrigger("Idle");
        }

    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0 && !isReload)
        {
            Fire();
        }
    }

     void Fire()
    {
        if (!isReload)
        {
            if (currentGun.currentBulletCount > 0)
                Shoot();
            else
            {
                StartCoroutine(ReloadCoroutine());
            }


        }
    }

     void Shoot()
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate; // ���� �ӵ� ����.
       // PlaySE(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();

        // �Ѿ� ������Ʈ(InstanceBullet) ����   
        Rigidbody instanceBullet = Instantiate(prefabBullet, transform.position, transform.rotation) as Rigidbody;
        instanceBullet.AddForce(transform.forward * bulletForce);    // �Ѿ� ������Ʈ ������ �߻��ϴ� �� �߰�
        Physics.IgnoreCollision(instanceBullet.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
        // Player�� Collider ���� �浹 ����

        StopAllCoroutines();    

    }

     void TryReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload && currentGun.currentBulletCount < currentGun.reloadBulletCount)
        {
           
            StartCoroutine(ReloadCoroutine());
        }
    }

    IEnumerator ReloadCoroutine()
    {
        if (currentGun.carryBulletCount > 0)
        {
            isReload = true;

            currentGun.anim.SetTrigger("Reload");


            currentGun.carryBulletCount += currentGun.currentBulletCount;
            currentGun.currentBulletCount = 0;

            yield return new WaitForSeconds(currentGun.reloadTime);

            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            }
            else
            {
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }


            isReload = false;
        }
        else
        {
            GameController.instance.GameOver();
        }
    }
    public Gun GetGun()
    {
        return currentGun;
    }
    

    //private void PlaySE(AudioClip _clip)
    //{
    //    audioSource.clip = _clip;
    //    audioSource.Play();
    //}
}