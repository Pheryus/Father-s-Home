using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum hack_messages { first_puzzle = 0, door, table, return_door, window, paint, none, mat, tv, door_to_room, refrigerator,
kitchen_table, light_switch, bedroom_door, color_switch, stove, sofa, binary_code, locked_glass
};

public class HackMessages : MonoBehaviour {
    public static HackMessages instance;

    public Text hack_text;

    public GameObject hack_panel;

    private void Awake() {
        instance = this;
    }

    public void setMessage(hack_messages hack_message) {
        if (hack_message == hack_messages.first_puzzle)
            hack_text.text = "caso (senha1 == 552)\n       aberto = true;";
        else if (hack_message == hack_messages.door)
            hack_text.text = "caso (coordenada1 == true e coordenada2 == true e coordenada3 == true e coordenada 4 == true)\n       aberto = true;";
        else if (hack_message == hack_messages.table)
            hack_text.text = "caso (objeto == mesa){\n       sul = false;\n       leste = false;\n}";
        else if (hack_message == hack_messages.return_door)
            hack_text.text = "caso (objeto == porta_saida){\n        norte = false;\n       sul = false;\n}";
        else if (hack_message == hack_messages.window)
            hack_text.text = "vista_bonita = true;";
        else if (hack_message == hack_messages.paint)
            hack_text.text = "quadro = ''LISA'';";
        else if (hack_message == hack_messages.mat)
            hack_text.text = "caso (objeto == tapete){\n        leste = false;\n        oeste = false;}";
        else if (hack_message == hack_messages.door_to_room)
            hack_text.text = "conectado = Sala;";
        else if (hack_message == hack_messages.refrigerator)
            hack_text.text = "caso (luz_ambiente)\n        esconderCodigoBinario();\nsenão\n        mostrarCodigoBinario();";
        else if (hack_message == hack_messages.light_switch)
            hack_text.text = "caso (ligado == true)\n        luz = alta;";
        else if (hack_message == hack_messages.bedroom_door)
            hack_text.text = "caso (verde == true e azul == true e amarelo == false e vermelho == false e luz_ambiente == false)\n        aberto = true;";
        else if (hack_message == hack_messages.color_switch)
            hack_text.text = "caso (clicar == true)\n        ligado = !ligado;";
        else if (hack_message == hack_messages.stove)
            hack_text.text = "caso (botao0 == 90)\n        botao1 = 120;\nsenao\n        botao1 = 90;";
        else if (hack_message == hack_messages.binary_code)
            hack_text.text = "inteiro M = 32;\ninteiro L = 16;\ninteiro R = 8;\ninteiro I = 4;\ninteiro S = 2;\ninteiro A = 1;\ninteiro numero_31 = L + R + I + S + A;\n" +
                "inteiro numero_5 = I + A;";
        else if (hack_message == hack_messages.sofa)
            hack_text.text = "confortavel = true; otimo_para_dormir = true";
        else if (hack_message == hack_messages.locked_glass)
            hack_text.text = "caso (copo.contem(agua) e copo.contem(gelo) e copo.contem(canudo))\n        aberto = true;";
        hack_text.enabled = true;
        hack_panel.SetActive(true);
    }

    public void closeHackWindow() {
        hack_text.text = string.Empty;
        hack_text.enabled = false;
        hack_panel.SetActive(false);
    }


}
