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
    public int Pamflets = 0;

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
        //_mytransform.Rotate(Vector3.back, rotSpeed * Time.deltaTime * Input.GetAxis("Rotate"));

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
        #region Lookatmouse
        if (cam == null)
        {
            Debug.LogError(gameObject.name + " target missing!");
            return;
        }
        // store mouse pixel coordinates
        mousePosition = Input.mousePosition;

        // distance in z between this object and the camera
        // so it always align with the object
        mousePosition.z = -cam.transform.position.z + transform.position.z;

        // transform mousePosition from screen pixels to world position
        lookAtPosition = cam.ScreenToWorldPoint(mousePosition);

        // Calculate normalized direction
        Vector2 direction = (lookAtPosition - transform.position).normalized;

        Debug.DrawRay(transform.position, direction * 20f, Color.blue);

        switch (axis)
        {
            case Axis.x:
                if (!inverted)
                    transform.right = direction; // Point x axis towards direction
                else
                    transform.right = -direction; // Point x axis towards inverted direction
                break;

            case Axis.y:
                if (!inverted)
                    transform.up = direction; // Point y axis towards direction
                else
                    transform.up = -direction; // Point y axis towards inverted direction
                break;

            default:
                break;
        }
        #endregion
    }
}
