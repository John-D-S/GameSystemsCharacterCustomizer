using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitch : MonoBehaviour
{
    public List<Sprite> sprites;
    public SpriteRenderer rend;

    private void Start()
    {
        GetComponent<Slider>().wholeNumbers = true;
        GetComponent<Slider>().maxValue = sprites.Count - 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomSprite();
        }
    }

    void RandomSprite()
    {
        int rand = Random.Range(0, sprites.Count);
        rend.sprite = sprites[rand];
        GetComponent<Slider>().value = rand;
    }

    public void ChangeSprite(float value)
    {
        int roundvalue = Mathf.RoundToInt(value);
        rend.sprite = sprites[roundvalue];
    }
}
