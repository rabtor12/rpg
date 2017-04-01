using UnityEngine;

public class WanderingAL : MonoBehaviour
{
    [SerializeField] private GameObject Fireball;
    private GameObject _fireball;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(Fireball) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward*1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
               else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
