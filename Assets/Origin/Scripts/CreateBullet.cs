using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public Rigidbody prefabBullet;
    public float bulletForce = 1000.0f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // �Ѿ� ������Ʈ(InstanceBullet) ����   
            Rigidbody instanceBullet = Instantiate(prefabBullet, transform.position , transform.rotation) as Rigidbody;
            instanceBullet.AddForce(transform.forward * bulletForce);    // �Ѿ� ������Ʈ ������ �߻��ϴ� �� �߰�
            Physics.IgnoreCollision(instanceBullet.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
            // Player�� Collider ���� �浹 ����
        }
    }
}
