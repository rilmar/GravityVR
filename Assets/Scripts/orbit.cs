using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class orbit : MonoBehaviour
{

    //physics settings
    public float mass;
    public int influence;

    void start()
    {

        mass = mass * 100000000000;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, influence);
    }

    void FixedUpdate()
    {
        //collects planets into an array
        GameObject[] planets = GameObject.FindGameObjectsWithTag("planet");

        //cycles through planets for manipulation
        foreach (GameObject planet in planets)
        {
            Rigidbody gravBody = planet.GetComponent<Rigidbody>();
            gravBody.constraints = RigidbodyConstraints.FreezePositionY;//keeps 2d

            float orbitalDistance = Vector3.Distance(this.transform.position, gravBody.transform.position);

            if (orbitalDistance != 0)
            {
                if (orbitalDistance < influence)
                {
                    Vector3 offset = this.transform.position - gravBody.transform.position;

                    //Vector3 trajectory = gravBody.velocity;
                    //float angle = Vector3.Angle (offset, trajectory);

                    float magsqr = offset.sqrMagnitude;

                    if (magsqr > 0.0001f)
                    {
                        Vector3 gravity = (mass * offset.normalized / magsqr);
                        gravBody.AddForce(gravity * orbitalDistance);
                    }
                }
            }
        }
    }
}