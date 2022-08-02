using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    private int _respeed;
    public int sprintSpeed;
    public int rotSpeed;
    private Transform _mytransform;
    public Transform Chamber;
    public GameObject BulletPref;
    List<GameObject> _bulletList = new List<GameObject>();

    void Start()
    {
        _mytransform = GetComponent<Transform>();
        speed = 5;
        _respeed = speed;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _respeed = sprintSpeed;
        }
        else
        {
            _respeed = speed;
        }

        _mytransform.Translate(_respeed * Time.deltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        _mytransform.Rotate(Vector3.back, rotSpeed * Time.deltaTime * Input.GetAxis("Rotate"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject bullet in _bulletList)
            {
                if (bullet.GetComponent<Bullet>().Fire(Chamber)) return;
            }
            GameObject tempBullet = Instantiate(BulletPref);
            _bulletList.Add(tempBullet);
            tempBullet.GetComponent<Bullet>().Fire(Chamber);
        }
        //_mytransform.Rotate(Vector3.back, _rspeed * Time.deltaTime * new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).normalized);
    }
}
