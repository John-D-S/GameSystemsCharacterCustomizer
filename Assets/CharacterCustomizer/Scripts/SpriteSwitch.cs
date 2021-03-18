using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public List<Sprite> sprites;
    public SpriteRenderer rend;

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
    }

    public void ChangeSprite(float value)
    {
        int roundvalue = Mathf.RoundToInt(value);
        rend.sprite = sprites[roundvalue];
    }
}
