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
            ContactPoint contact = collision.contacts[0];   // 총알과의 충돌지점 
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);   // 충돌지점의 방향
            Instantiate(npcExplosion, contact.point, rotation); // 충돌후 폭파(instantiateExplosion) 오브젝트 생성
            //           GameController.instance.AddScore(score);
            Destroy(collision.gameObject); // NPC 오브젝트 제거
            Destroy(gameObject);
        }
        else Destroy(gameObject); // 총알 오브젝트 제거
    }
}
