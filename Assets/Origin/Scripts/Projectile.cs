using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public GameObject bulletExplosion;
    public GameObject npcExplosion;
    public int score = 10;
    public int spawn = -1;

    
    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "NPC")
        {
            GameController.instance.AddCount(-1);
            GameController.instance.AddScore(1000);
            ContactPoint contact = collision.contacts[0];   // �Ѿ˰��� �浹���� 
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);   // �浹������ ����
            Instantiate(npcExplosion, contact.point, rotation); // �浹�� ����(instantiateExplosion) ������Ʈ ����
            //           GameController.instance.AddScore(score);
            Destroy(collision.gameObject); // NPC ������Ʈ ����
            Destroy(gameObject);
        }
        else Destroy(gameObject); // �Ѿ� ������Ʈ ����
    }
}
