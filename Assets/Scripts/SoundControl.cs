using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {
    public static SoundControl instance;

    public AudioSource se_source, text_source;

    public AudioClip button_click, combine_item, open_something, find_item, open_door, rip, locked_sound, water;

    private void Awake() {
        instance = this;
    }

    public void fillWater() {
        se_source.clip = water;
        se_source.Play();
    }

    public void ripPillow() {
        se_source.clip = rip;
        se_source.Play();
    }
    
    public void locked() {
        se_source.clip = locked_sound;
        se_source.Play();
    }

    public void clickButton() {
        se_source.clip = button_click;
        se_source.Play();
    }

    public void combineItems() {
        se_source.clip = combine_item;
        se_source.Play();
    }
    public void openDoor() {
        se_source.clip = open_door;
        se_source.Play();
    }

    public void openSomething() {
        se_source.clip = open_something;
        se_source.Play();
    }

    public void findItem() {
        se_source.clip = find_item;
        se_source.Play();
    }

    public void playTextSound() {
        text_source.Play();
    }
}
