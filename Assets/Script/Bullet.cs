using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform MyTransform;


    void Update()
    {
        MyTransform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    public bool Fire(Transform transform)
    {
        if (this.gameObject.activeSelf) return false;
        MyTransform.position = transform.position;
        MyTransform.rotation = transform.rotation;
        this.gameObject.SetActive(true);
        return true;
    }

    private void OnEnable()
    {
        StartCoroutine("Disable");
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Wall"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
