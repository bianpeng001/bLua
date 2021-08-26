
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_ParticleSystem
{
public static UnityEngine.ParticleSystem.PlaybackState GetPlaybackState(UnityEngine.ParticleSystem _this)
{
	return _this.GetPlaybackState();
}

public static void SetPlaybackState(UnityEngine.ParticleSystem _this, UnityEngine.ParticleSystem.PlaybackState playbackState)
{
	_this.SetPlaybackState(playbackState);
}

public static UnityEngine.ParticleSystem.Trails GetTrails(UnityEngine.ParticleSystem _this)
{
	return _this.GetTrails();
}

public static void SetTrails(UnityEngine.ParticleSystem _this, UnityEngine.ParticleSystem.Trails trailData)
{
	_this.SetTrails(trailData);
}

public static void Simulate(UnityEngine.ParticleSystem _this, float t, bool withChildren, bool restart, bool fixedTimeStep)
{
	_this.Simulate(t, withChildren, restart, fixedTimeStep);
}

public static void Simulate(UnityEngine.ParticleSystem _this, float t, bool withChildren, bool restart)
{
	_this.Simulate(t, withChildren, restart);
}

public static void Simulate(UnityEngine.ParticleSystem _this, float t, bool withChildren)
{
	_this.Simulate(t, withChildren);
}

public static void Simulate(UnityEngine.ParticleSystem _this, float t)
{
	_this.Simulate(t);
}

public static void Play(UnityEngine.ParticleSystem _this, bool withChildren)
{
	_this.Play(withChildren);
}

public static void Play(UnityEngine.ParticleSystem _this)
{
	_this.Play();
}

public static void Pause(UnityEngine.ParticleSystem _this, bool withChildren)
{
	_this.Pause(withChildren);
}

public static void Pause(UnityEngine.ParticleSystem _this)
{
	_this.Pause();
}

public static void Stop(UnityEngine.ParticleSystem _this, bool withChildren, int stopBehavior)
{
	_this.Stop(withChildren, (UnityEngine.ParticleSystemStopBehavior)stopBehavior);
}

public static void Stop(UnityEngine.ParticleSystem _this, bool withChildren)
{
	_this.Stop(withChildren);
}

public static void Stop(UnityEngine.ParticleSystem _this)
{
	_this.Stop();
}

public static void Clear(UnityEngine.ParticleSystem _this, bool withChildren)
{
	_this.Clear(withChildren);
}

public static void Clear(UnityEngine.ParticleSystem _this)
{
	_this.Clear();
}

public static bool IsAlive(UnityEngine.ParticleSystem _this, bool withChildren)
{
	return _this.IsAlive(withChildren);
}

public static bool IsAlive(UnityEngine.ParticleSystem _this)
{
	return _this.IsAlive();
}

public static void Emit(UnityEngine.ParticleSystem _this, int count)
{
	_this.Emit(count);
}

public static void Emit(UnityEngine.ParticleSystem _this, UnityEngine.ParticleSystem.EmitParams emitParams, int count)
{
	_this.Emit(emitParams, count);
}

public static void TriggerSubEmitter(UnityEngine.ParticleSystem _this, int subEmitterIndex)
{
	_this.TriggerSubEmitter(subEmitterIndex);
}

public static void AllocateAxisOfRotationAttribute(UnityEngine.ParticleSystem _this)
{
	_this.AllocateAxisOfRotationAttribute();
}

public static void AllocateMeshIndexAttribute(UnityEngine.ParticleSystem _this)
{
	_this.AllocateMeshIndexAttribute();
}

public static void AllocateCustomDataAttribute(UnityEngine.ParticleSystem _this, int stream)
{
	_this.AllocateCustomDataAttribute((UnityEngine.ParticleSystemCustomData)stream);
}

public static bool get_isPlaying(UnityEngine.ParticleSystem _this)
{
	return _this.isPlaying;
}

public static bool get_isEmitting(UnityEngine.ParticleSystem _this)
{
	return _this.isEmitting;
}

public static bool get_isStopped(UnityEngine.ParticleSystem _this)
{
	return _this.isStopped;
}

public static bool get_isPaused(UnityEngine.ParticleSystem _this)
{
	return _this.isPaused;
}

public static int get_particleCount(UnityEngine.ParticleSystem _this)
{
	return _this.particleCount;
}

public static float get_time(UnityEngine.ParticleSystem _this)
{
	return _this.time;
}

public static void set_time(UnityEngine.ParticleSystem _this, float value)
{
	_this.time = value;
}

public static uint get_randomSeed(UnityEngine.ParticleSystem _this)
{
	return _this.randomSeed;
}

public static void set_randomSeed(UnityEngine.ParticleSystem _this, uint value)
{
	_this.randomSeed = value;
}

public static bool get_useAutoRandomSeed(UnityEngine.ParticleSystem _this)
{
	return _this.useAutoRandomSeed;
}

public static void set_useAutoRandomSeed(UnityEngine.ParticleSystem _this, bool value)
{
	_this.useAutoRandomSeed = value;
}

public static bool get_proceduralSimulationSupported(UnityEngine.ParticleSystem _this)
{
	return _this.proceduralSimulationSupported;
}

public static UnityEngine.ParticleSystem.MainModule get_main(UnityEngine.ParticleSystem _this)
{
	return _this.main;
}

public static UnityEngine.ParticleSystem.EmissionModule get_emission(UnityEngine.ParticleSystem _this)
{
	return _this.emission;
}

public static UnityEngine.ParticleSystem.ShapeModule get_shape(UnityEngine.ParticleSystem _this)
{
	return _this.shape;
}

public static UnityEngine.ParticleSystem.VelocityOverLifetimeModule get_velocityOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.velocityOverLifetime;
}

public static UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule get_limitVelocityOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.limitVelocityOverLifetime;
}

public static UnityEngine.ParticleSystem.InheritVelocityModule get_inheritVelocity(UnityEngine.ParticleSystem _this)
{
	return _this.inheritVelocity;
}

public static UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule get_lifetimeByEmitterSpeed(UnityEngine.ParticleSystem _this)
{
	return _this.lifetimeByEmitterSpeed;
}

public static UnityEngine.ParticleSystem.ForceOverLifetimeModule get_forceOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.forceOverLifetime;
}

public static UnityEngine.ParticleSystem.ColorOverLifetimeModule get_colorOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.colorOverLifetime;
}

public static UnityEngine.ParticleSystem.ColorBySpeedModule get_colorBySpeed(UnityEngine.ParticleSystem _this)
{
	return _this.colorBySpeed;
}

public static UnityEngine.ParticleSystem.SizeOverLifetimeModule get_sizeOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.sizeOverLifetime;
}

public static UnityEngine.ParticleSystem.SizeBySpeedModule get_sizeBySpeed(UnityEngine.ParticleSystem _this)
{
	return _this.sizeBySpeed;
}

public static UnityEngine.ParticleSystem.RotationOverLifetimeModule get_rotationOverLifetime(UnityEngine.ParticleSystem _this)
{
	return _this.rotationOverLifetime;
}

public static UnityEngine.ParticleSystem.RotationBySpeedModule get_rotationBySpeed(UnityEngine.ParticleSystem _this)
{
	return _this.rotationBySpeed;
}

public static UnityEngine.ParticleSystem.ExternalForcesModule get_externalForces(UnityEngine.ParticleSystem _this)
{
	return _this.externalForces;
}

public static UnityEngine.ParticleSystem.NoiseModule get_noise(UnityEngine.ParticleSystem _this)
{
	return _this.noise;
}

public static UnityEngine.ParticleSystem.CollisionModule get_collision(UnityEngine.ParticleSystem _this)
{
	return _this.collision;
}

public static UnityEngine.ParticleSystem.TriggerModule get_trigger(UnityEngine.ParticleSystem _this)
{
	return _this.trigger;
}

public static UnityEngine.ParticleSystem.SubEmittersModule get_subEmitters(UnityEngine.ParticleSystem _this)
{
	return _this.subEmitters;
}

public static UnityEngine.ParticleSystem.TextureSheetAnimationModule get_textureSheetAnimation(UnityEngine.ParticleSystem _this)
{
	return _this.textureSheetAnimation;
}

public static UnityEngine.ParticleSystem.LightsModule get_lights(UnityEngine.ParticleSystem _this)
{
	return _this.lights;
}

public static UnityEngine.ParticleSystem.TrailModule get_trails(UnityEngine.ParticleSystem _this)
{
	return _this.trails;
}

public static UnityEngine.ParticleSystem.CustomDataModule get_customData(UnityEngine.ParticleSystem _this)
{
	return _this.customData;
}

}
}
