using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float minX; // Максимальное и минимальное X координат платформы
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;// позиция мыши в координатах камеры
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos); // позиция мыши в координатах мира
        //Debug.Log("mousePos: " + mousePos + ", mouseWorldPos: " + mouseWorldPos);

        float xPlatform = mouseWorldPos.x;// значение x координат мыши
        float clampedPlatformX = Mathf.Clamp(xPlatform, minX, maxX); // обрезаем координаты платформы по x до нужных нам значений
        float yPlatform = transform.position.y;

        transform.position = new Vector3(clampedPlatformX, yPlatform, 0);
    }
}
