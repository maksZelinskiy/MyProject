using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        // Когда в область действия триггера попадает что-то,
        // проверить, является ли это "что-то” снарядом
        if (other.gameObject.tag == "Projectile")
        {
            goalMet = true;
            // Также изменить альфа-канал цвета, чтобы увеличить непрозрачность
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.g = 1;
            mat.color = c;
        }
    }
}

