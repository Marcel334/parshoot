using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    ////Obiekt systemu cząsteczkowego, który pozostawi ślady po kulach
    [SerializeField] protected GameObject particle;
    //Kamera (pomoże nam znaleźć środek ekranu)
    [SerializeField] protected GameObject cam;
    //Tryb strzelania broni
    protected bool auto = false;
    //Odstęp między strzałami i timer, który liczy czas
    protected float cooldown = 0;
    protected  float timer = 0;

    //Na początku gry ustawiamy timer na wartość cooldown broni
    //To gwarantuje, że pierwszy strzał zostanie oddany bez opóźnienia
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        //Uruchamiamy timer
        timer += Time.deltaTime;
        //Jeśli gracz nacisnął lewy przycisk myszy, wywołujemy funkcję Strzelaj
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    //Sprawdzamy, czy broń może strzelać
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                OnShot();
                timer = 0;
            }
        }
    }
    //A ta funkcja zdefiniuje co się dzieje, kiedy broń strzela. Ponieważ ma modyfikatory protected i virtual, klasy, które od niej dziedziczą, będą mogły zdefiniować swoją własną logikę strzelania
    protected virtual void OnShot()
    {
    }

}
