using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Classe responsável pela animação dos textos de fala de Crona.
/// </summary>
public class AnimatedMessage : MonoBehaviour {

    public bool ended_animation;

    public float delay = 0.02f, pause = 0.3f;

	float duration = 1.5f;

	string full_message;

	public char[] actual_message; 

	public Text text;

	int message_index = 0;
	
	public bool on_pause = false;

	public bool skip_message = false;

	Coroutine show_character_routine;

    public InGameMessages in_game_messages;

	public void showMessage(){
		if (show_character_routine != null)
			StopCoroutine(show_character_routine);

		ended_animation = false;
		message_index = 0;
		show_character_routine = StartCoroutine(showCharacter());
	}

    public void deleteText() {
        text.text = string.Empty;
    }

	void defineMessage(){
        full_message = in_game_messages.active_message;
		actual_message = new char[full_message.Length + 20];
		text.text = new string(actual_message);
	}


	IEnumerator showCharacter(){

		defineMessage();

		for (int i = 0; i < full_message.Length; i++){
			if (i + 1 < full_message.Length){
				if (full_message[i] == '\\'){
					if (full_message[i+1] == '.'){
					 	skip_message = false;
						yield return new WaitForSecondsRealtime(delay * 3);
						i++;
						continue;
					}
					else if (full_message[i+1] == 'P'){
						skip_message = false;
						freezeMessage();
						yield return new WaitForSecondsRealtime(delay * 10);
						unfreezeMessage();
						i++; 
						continue;
					}
					else if (full_message[i+1] == 'p'){
						skip_message = false;
						freezeMessage();
						yield return new WaitForSecondsRealtime(delay * 5);
						unfreezeMessage();
						i++;
						continue;
					}

				}
				else if (full_message[i] == '<'){
					
					if (full_message[i + 2] == '>' || full_message[i + 3] == '>'){
						actual_message[message_index] = full_message[i];

						actual_message[message_index + 1] = full_message[i+1];
						actual_message[message_index + 2] = full_message[i+2];

						if (full_message[i + 3] == '>'){
							actual_message[message_index + 3] = full_message[i+3];
							i++;
							message_index ++;
						}

						i += 2;
						message_index += 3;
						text.text = new string(actual_message);
						continue;
					}
				}
			}
            SoundControl.instance.playTextSound();
			actual_message[message_index] = full_message[i];
			text.text = new string(actual_message);
			message_index++;

            if (!skip_message) { 
                yield return null;
            }

            if (ended_animation){		
				break;
			}	
		}
        
		full_message = cleanMessage(full_message);

		text.text = full_message;
		ended_animation = true;
		skip_message = false;

	}

    /// <summary>
    /// Remove simbolos usados para representar pausas entre mensagens.
    /// </summary>
    /// <returns>Mensagem limpa</returns>
	string cleanMessage(string full_message) {
		full_message = full_message.Replace("\\.", "");
		full_message = full_message.Replace("\\^", "");
		full_message = full_message.Replace("\\P", "");
		full_message = full_message.Replace("\\p", "");
		return full_message;
	}

	void freezeMessage(){
		on_pause = true;
	}


	void unfreezeMessage(){
		on_pause = false;
	}

}
