using System.Collections;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    public float speed;
    public Transform page, slide;
    bool isRotating, isSliding;
    float movingVec = 1;

    private void Start()
    {
        isSliding = true;
    }

    void Update()
    {

        if (isSliding)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isSliding = false;
                speed = (200f - (25f * Mathf.Abs(slide.transform.localPosition.x)));
                StartCoroutine(RotateCo());
                return;
            }
            slide.transform.localPosition += Vector3.right * Time.deltaTime * movingVec * 5;
            if(slide.transform.localPosition.x >= 4)
            {
                movingVec = -1;
            }
            else if(slide.transform.localPosition.x <= -4)
            {
                movingVec = 1;
            }

            
        }

        if (isRotating)
        {
            page.transform.rotation = Quaternion.Euler(0, 0, page.transform.eulerAngles.z + speed * Time.deltaTime);
        }
    }

    IEnumerator RotateCo()
    {
        isRotating = true;
        float originalSpeed = speed;
        yield return new WaitForSeconds(3);
        for(int i = 0; i < 100; i++)
        {
            speed -= originalSpeed * 0.01f;
            yield return null;
        }
        speed = 0;
        isRotating = false;
    }
}