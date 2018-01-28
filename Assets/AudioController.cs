﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
        private static AudioController _instance;
        public List<AudioClip> audioSources;
        AudioSource thisAudio;

        public static AudioController Instance { get { return _instance; } }

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }

        private void Start() {
            thisAudio = GetComponent<AudioSource>();
        }

        public void PlayRoombaHitSounds() {
                thisAudio.PlayOneShot(audioSources[Random.Range(0, 11)]);
        }

        public void PlayRoombaExplosionSounds() {
                thisAudio.PlayOneShot(audioSources[Random.Range(12, 17)]);
        }
}
