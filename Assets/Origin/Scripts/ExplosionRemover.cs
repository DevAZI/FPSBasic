using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionRemover : MonoBehaviour
{
    public float explosionTime = 1.0f;
    void Start()
    {
        // ���� ��ƼŬ 1���� ����
        Destroy(gameObject, explosionTime);
    }
}
