using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //odwolanie do obiektu typu CharacterController z naszego projektu
    public Transform cam; //referencja do kamery wykorzystanej w scenie
    public float speed = 6f; //predkosc poruszania sie gracza 
    public float turnSmoothTime = 0.1f; //zmienna uzyta do wygladzenia obrotu gracza
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        //w UNITY to czym sterujemy (np. strza�ki/WASD) ustawiamy w edytorze UNITY, a w skrypcie odwo�ujemy si� do tego poprzez Input
        float horizontal = Input.GetAxisRaw("Horizontal"); //przyjecie sygna�u z UNITY o ruchu w osi X
        float vertical = Input.GetAxisRaw("Vertical"); //przyjecie sygna�u z UNITY o ruchu w osi Z
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //z�o�enie ruchu do wektora. Normalized dodane jest po to aby przy ruchu po skosie nie rusza� si� szybciej

        if(direction.magnitude >= 0.1f) //je�eli wektor ruchu jest d�u�szy od ma�ej warto�ci (u nas 0.1f) to znaczy �e posta� si� porusza
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //k�t o jaki musimy obrocic gracza zeby podazal za kamer�
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //wygladzanie k�ta zeby animacja obrotu za kamer� byla gladka
            transform.rotation = Quaternion.Euler(0f, angle, 0f);//obr�t wok� poszczeg�lnych osi

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //konwersja k�ta kamery na kierunek
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //poruszenie postaci
        }
    }
}
