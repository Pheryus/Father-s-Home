using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMessages : MonoBehaviour {

    string[] messages = {"... Enfim consegui entrar no mundo que meu pai programou.", "Gostaria de entender o motivo dele ter " +
            "deixado este lugar só para mim\\..\\..\\.." };

    string[] end_game_messages = {"Eu sempre trabalhei o máximo que pude.", "Quando Lisa, sua mãe, se foi, eu não pude parar.", "Você sabe que eu não gosto de desistir no meio do caminho\\..\\..\\..",
        "Você sabe que\\p que eu faria qualquer coisa\\p para tê-la\\P de volta.", "Quando o câncer dela foi detectado, eu já estava trabalhando nisso.", "Tentei terminar o máximo rápido que pude,\\p mas,\\p você sabe.\\p.\\p.\\p",
        "Ela se foi.\\p E eu fiquei aqui,\\p você sabe.", "Nâo queria que você viesse aqui.\\p Não queria que achasse que eu fosse louco.", "Eu sei que eu precisava de ajuda.\\P Mas com você será diferente, eu garanto.", "Ela estará sempre aqui para você.", "M\\pa\\pm\\pã\\pe\\p?", "Lisa: Você não sabe o quanto eu senti saudades.", "Ela irá te fazer companhia, filho.\\p Assim como fez para mim.", "Você a fez?\\p Por quê, pai?", "Tudo começou com uma brincadeira,\\p mas depois que ela se foi,\\p eu\\p.\\p.\\p, eu\\P",
        "Eu queria me sentir em casa de novo."
    };

    int black_screen = 10;

    public AnimatedMessage animated_message;

    public static InGameMessages instance;

    public string active_message;

    public bool end_game = false;

    public GameObject fadeout;

    public GameObject message_panel;

    int id = 0;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        PlayerAction.can_act = false;
        PlayerAction.on_talk = true;
        active_message = messages[id];

        message_panel.SetActive(true);

        animated_message.text.enabled = true;

        animated_message.showMessage();
    }

    public void changeMessage() {
        if (animated_message.ended_animation) {
            id++;
            if (!end_game && id > messages.Length - 1) {
                if (!end_game)
                    endMessage();
            }
            else {
                if (end_game) {
                    if (id == end_game_messages.Length - 2) {
                        animated_message.delay = 0.05f;
                    }
                    if (id > end_game_messages.Length - 1) {
                        Invoke("closeGame", 3f);
                    }

                    animated_message.ended_animation = false;
                    if (id == black_screen) {
                        message_panel.SetActive(false);
                        animated_message.text.text = string.Empty;
                        fadeout.SetActive(true);
                        Destroy(animated_message.text.transform.GetChild(0).gameObject);
                        Invoke("enableNextMessage", 1.5f);
                    }
                    else
                        Invoke("enableNextMessage", 0.3f);
                }
                else {
                    enableNextMessage();
                }
            }
            
        }
    }

    void closeGame() {
        SceneManager.LoadScene("Menu");
    }

    void enableNextMessage() {
        if (end_game)
            active_message = end_game_messages[id];
        else
            active_message = messages[id];
        animated_message.showMessage();
    }

    public void endGame() {
        PlayerAction.on_talk = true;
        PlayerAction.can_act = false;
        message_panel.SetActive(true);

        animated_message.text.enabled = true;

        animated_message.delay = 0.04f;
        id = 0;
        end_game = true;
        active_message = end_game_messages[id];

        animated_message.showMessage();
    }

    void endMessage() {
        message_panel.SetActive(false);
        Debug.Log("end message");
        animated_message.text.enabled = false;
        PlayerAction.can_act = true;
        PlayerAction.on_talk = false;
    }

}
