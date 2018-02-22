/*Main Programmer: Cameron Blomquist
 * A very simple script used for planets
 * that allows each planet to have a
 * unique gravity value
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    [SerializeField]
    private float _gravity;

    public float Gravity { get { return _gravity; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Gravitator>().activePlanet = this;
    }
}
