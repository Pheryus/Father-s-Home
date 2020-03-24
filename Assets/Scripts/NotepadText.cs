using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotepadText : MonoBehaviour {
    public static NotepadText instance;

    public Text text;

    public GameObject window;

    string[] notes = { "Desde que sua mãe se foi, este lugar se tornou minha nova casa.\n\nAgora ela é sua.\n\n" +
            "Sempre que se sentir sozinho, sabe onde pode ir.\n\n" + "Não esqueça de explorá-la bastante. Irá te manter ocupado.",
        "Bem-vindo ao meu antigo lar, filho.\n\nJá pode chamá-lo de sua casa, se preferir.\n\n Sei que você adora quebra cabeças, então preparei" +
            "várias surpresinhas para você aqui.\n\n Não desista e não perca o foco. Eu ainda tenho que te mostrar algo muito especial.",

        "Por um momento você deve ter ficado feliz, meu rapaz.\n\nEssa é minha última travessura para você.\n\n" +
            "Pena que já não estou mais aqui para ver seu rosto pela última vez.\n\n Gostou da pintura de sua mãe?\n É ela visitando a Europa Ocidental.",
        "                                III",
        "                               IV",
        "                               V",
        "                               I",
    };

    public enum dials { first = 3, second = 4, third = 5, fourth = 6};

    private void Awake() {
        instance = this;
    }

    public Sprite[] dials_sprite;

    public Image dial, dial2;

    public void showMessage(int id) {

        DescriptionControl.instance.disableMessage();
        dial.enabled = true;
        

        if (id == (int)dials.first)
            dial.sprite = dials_sprite[0];
        else if (id == (int)dials.second)
            dial.sprite = dials_sprite[1];
        else if (id == (int)dials.third)
            dial.sprite = dials_sprite[2];
        else if (id == (int)dials.fourth) {
            Debug.Log("aqui");
            dial.sprite = dials_sprite[3];
        }
        else
            dial.enabled = false;


        window.SetActive(true);
        text.enabled = true;
        text.text = notes[id];
        PlayerAction.reading_note = true;
        PlayerAction.can_act = false;
    }

    public void closeText() {
        dial2.enabled = false;
        dial.enabled = false;
        window.SetActive(false);
        text.enabled = false;
        text.text = string.Empty;
        PlayerAction.reading_note = false;
        PlayerAction.can_act = true;
    }
}
