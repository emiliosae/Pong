using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 150;
    private Vector3 _dir;
    public Transform Chamber;
    public GameObject BulletPref;
    public int Dmg;
    List<GameObject> _bulletList = new List<GameObject>();
    public int Pamflets = 0;
    private Rigidbody2D _rb;
    #region Point at vars
    public Camera cam;
    public enum Axis { x, y }
    public Axis axis = Axis.y;
    public bool inverted;
    private Vector3 mousePosition;
    private Vector3 lookAtPosition;
    #endregion

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _dir = (vertical * transform.up + horizontal * transform.right).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject bullet in _bulletList)
            {
                if (bullet.GetComponent<Bullet>().Fire(Chamber)) return;
            }
            GameObject tempBullet = Instantiate(BulletPref);
            _bulletList.Add(tempBullet);
            tempBullet.GetComponent<Bullet>().Dmg = Dmg;
            tempBullet.GetComponent<Bullet>().Fire(Chamber);
        }
        //_mytransform.Rotate(Vector3.back, _rspeed * Time.deltaTime * new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).normalized);
        #region Lookatmouse
        //if (cam == null)
        //{
        //    Debug.LogError(gameObject.name + " target missing!");
        //    return;
        //}
        // store mouse pixel coordinates
        //mousePosition = Input.mousePosition;

        // distance in z between this object and the camera
        // so it always align with the object
        //mousePosition.z = -cam.transform.position.z + transform.position.z;

        // transform mousePosition from screen pixels to world position
        //lookAtPosition = cam.ScreenToWorldPoint(mousePosition);

        // Calculate normalized direction
        //Vector2 direction = (lookAtPosition - transform.position).normalized;

        //Debug.DrawRay(transform.position, direction * 20f, Color.blue);

        //switch (axis)
        //{
        //    case Axis.x:
        //        if (!inverted)
        //            transform.right = direction; // Point x axis towards direction
        //        else
        //            transform.right = -direction; // Point x axis towards inverted direction
        //        break;

        //    case Axis.y:
        //        if (!inverted)
        //            transform.up = direction; // Point y axis towards direction
        //        else
        //            transform.up = -direction; // Point y axis towards inverted direction
        //        break;

        //    default:
        //        break;
        //}
        #endregion
    }
    private void FixedUpdate()
    {
        //_rb.AddForce(_dir * speed * Time.fixedDeltaTime);
        _rb.velocity = _dir * speed * Time.fixedDeltaTime;
    }
}
