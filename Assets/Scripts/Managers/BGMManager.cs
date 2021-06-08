using UnityEngine.Audio;
using System;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
	public Sound[] sounds;
	protected override void Awake()
	{
		base.Awake();
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.playOnAwake = s.playOnAwake;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}

	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (!s.source.enabled)
		{
			return;
		}
		else
		{
			s.source.Stop();
		}

	}
}

