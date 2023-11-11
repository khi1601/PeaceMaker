using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    // Start is called before the first frame update
    public enum SoundAct
    {
        Play,
        Stop,
        Pause,
        UnPause
    }

    public static SoundBox instance;

    [SerializeField]
    public Sound[] common_clips;

    [SerializeField]
    public List<Sound> act_clips = new List<Sound>();

    public AudioSource BGM;

    [SerializeField]
    public List<AudioSource> Effects = new List<AudioSource>();

    public AudioSource Etc;

    public AudioSource Common;

    private float Volume = 1f;

    private void Awake()
    {
        instance = this;
        Initialize();
        SetVolume(Volume);
    }

    public void Initialize()
    {
        int i;
        for (i = 0; i < common_clips.Length; i++)
        {
            if (act_clips.Find((Sound x) => x.name == common_clips[i].name) == null)
            {
                act_clips.Add(common_clips[i]);
            }
        }
    }
    public void PlayBGM(string name)
    {
        AudioSource audioSource = Etc;
        Sound sound_Members = act_clips.Find((Sound x) => x.name == name);
        if (sound_Members != null)
        {
            if (sound_Members.type==SoundType.BGM)
            {
                audioSource = BGM;
                if (!audioSource.loop)
                {
                    audioSource.loop = true;
                }
                audioSource.clip = sound_Members.audioClip;
            }
            
        }
        
    }
    public void PlaySFX(string name, SoundAct soundAct = SoundAct.Play)
    {
        AudioSource audioSource = Etc;
        bool flag = false;
        Sound sound_Members = act_clips.Find((Sound x) => x.name == name);
        if (sound_Members != null)
        {
            if (sound_Members.name.Contains("BGM"))
            {
                audioSource = BGM;
                if (!audioSource.loop)
                {
                    audioSource.loop = true;
                }
            }
            //else if (sound_Members.name.Contains("Eff"))
            //{
            //    flag = true;
            //}
            else if (sound_Members.type==SoundType.SFX)
            {
                flag = true;
            }
            else if (sound_Members.name.Contains("Common"))
            {
                audioSource = Common;
            }

            audioSource.clip = sound_Members.audioClip;
        }
        else if (name.Contains("BGM"))
        {
            audioSource = BGM;
        }
        
        else
        {
            if (!name.Contains("Eff"))
            {
                return;
            }

            flag = true;
        }

 

        if (flag)
        {
            bool flag2 = false;
            switch (soundAct)
            {
                case SoundAct.Play:
                    {
                        for (int num = 0; num < Effects.Count; num++)
                        {
                            if (!Effects[num].isPlaying)
                            {
                                flag2 = true;
                                Effects[num].clip = audioSource.clip;
                                audioSource = Effects[num];
                                break;
                            }
                        }

                        if (!flag2)
                        {
                            AudioSource audioSource2 = Object.Instantiate(Effects[0]);
                            audioSource2.name = string.Concat(Effects.Count);
                            audioSource2.transform.parent = Effects[0].transform.parent;
                            audioSource2.clip = audioSource.clip;
                            audioSource2.loop = false;
                            Effects.Add(audioSource2);
                            audioSource = audioSource2;
                        }

                        audioSource.Play();
                        break;
                    }
                case SoundAct.Stop:
                    if (sound_Members != null)
                    {
                        for (int k = 0; k < Effects.Count; k++)
                        {
                            if (Effects[k].clip != null && (Effects[k].clip.name.Equals(sound_Members.audioClip.name) || Effects[k].clip.name.Equals(sound_Members.name)))
                            {
                                flag2 = true;
                                audioSource = Effects[k];
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < Effects.Count; l++)
                        {
                            Effects[l].Stop();
                        }
                    }

                    if (flag2)
                    {
                        audioSource.Stop();
                    }

                    break;
                case SoundAct.Pause:
                    if (sound_Members != null)
                    {
                        for (int m = 0; m < Effects.Count; m++)
                        {
                            if (Effects[m].clip != null && (Effects[m].clip.name.Equals(sound_Members.audioClip.name) || Effects[m].clip.name.Equals(sound_Members.name)))
                            {
                                flag2 = true;
                                audioSource = Effects[m];
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int n = 0; n < Effects.Count; n++)
                        {
                            Effects[n].Pause();
                        }
                    }

                    if (flag2)
                    {
                        audioSource.Pause();
                    }

                    break;
                case SoundAct.UnPause:
                    if (sound_Members != null)
                    {
                        for (int i = 0; i < Effects.Count; i++)
                        {
                            if (Effects[i].clip != null && (Effects[i].clip.name.Equals(sound_Members.audioClip.name) || Effects[i].clip.name.Equals(sound_Members.name)))
                            {
                                flag2 = true;
                                audioSource = Effects[i];
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag2 = false;
                        for (int j = 0; j < Effects.Count; j++)
                        {
                            Effects[j].UnPause();
                        }
                    }

                    if (flag2)
                    {
                        audioSource.UnPause();
                    }

                    break;
            }
        }
        else
        {
            switch (soundAct)
            {
                case SoundAct.Play:
                    audioSource.Play();
                    break;
                case SoundAct.Stop:
                    audioSource.Stop();
                    break;
                case SoundAct.Pause:
                    audioSource.Pause();
                    break;
                case SoundAct.UnPause:
                    audioSource.UnPause();
                    break;
            }
        }
    }

  

    public void AddClip(string name, AudioClip clip)
    {
        Sound sound_Members = FindClip(name);
        if (sound_Members != null)
        {
            sound_Members.audioClip = clip;
        }
        else
        {
            act_clips.Add(new Sound(name, clip));
        }
    }

    public float GetDuration(string name)
    {
        Sound sound_Members = act_clips.Find((Sound x) => x.name == name);
        if (sound_Members == null)
        {
            return 0f;
        }

        if (sound_Members.audioClip == null)
        {
            return 0f;
        }

        return sound_Members.audioClip.length;
    }

    public Sound FindClip(string name)
    {
        Sound sound_Members = act_clips.Find((Sound x) => x.name == name);
        if (sound_Members == null)
        {
            return null;
        }

        return sound_Members;
    }
    public void SetVolume(float f)
    {
        BGM.volume = Volume* f;
        Etc.volume = Volume * f;
        Common.volume = Volume * f;
        for (int num = 0; num < Effects.Count; num++)
        {
            Effects[num].volume = Volume * f;           
        }
    }
}


