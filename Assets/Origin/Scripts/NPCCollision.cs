using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCCollision : MonoBehaviour
{
    public GameObject heat;
   
    public int healthValue = 10;


   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.AddCount(-1);          
            GameController.instance.MinusHealth(healthValue);
            ContactPoint contact = collision.contacts[0];   // �Ѿ˰��� �浹���� 
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);   // �浹������ ����
            Instantiate(heat, contact.point, rotation); // �浹�� ����(instantiateExplosion) ������Ʈ ����
            
            Destroy(gameObject);
           if (GameController.instance.health == 0) GameController.instance.GameOver();
        }
        else return;      // Floor Ȥ�� �ٸ� ��ü���� �浹 ����
    }
}
