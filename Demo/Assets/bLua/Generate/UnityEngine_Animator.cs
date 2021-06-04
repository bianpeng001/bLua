
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Animator
{
public static float GetFloat(UnityEngine.Animator _this, string name)
{
	return _this.GetFloat(name);
}

public static float GetFloat(UnityEngine.Animator _this, int id)
{
	return _this.GetFloat(id);
}

public static void SetFloat(UnityEngine.Animator _this, string name, float value)
{
	_this.SetFloat(name, value);
}

public static void SetFloat(UnityEngine.Animator _this, string name, float value, float dampTime, float deltaTime)
{
	_this.SetFloat(name, value, dampTime, deltaTime);
}

public static void SetFloat(UnityEngine.Animator _this, int id, float value)
{
	_this.SetFloat(id, value);
}

public static void SetFloat(UnityEngine.Animator _this, int id, float value, float dampTime, float deltaTime)
{
	_this.SetFloat(id, value, dampTime, deltaTime);
}

public static bool GetBool(UnityEngine.Animator _this, string name)
{
	return _this.GetBool(name);
}

public static bool GetBool(UnityEngine.Animator _this, int id)
{
	return _this.GetBool(id);
}

public static void SetBool(UnityEngine.Animator _this, string name, bool value)
{
	_this.SetBool(name, value);
}

public static void SetBool(UnityEngine.Animator _this, int id, bool value)
{
	_this.SetBool(id, value);
}

public static int GetInteger(UnityEngine.Animator _this, string name)
{
	return _this.GetInteger(name);
}

public static int GetInteger(UnityEngine.Animator _this, int id)
{
	return _this.GetInteger(id);
}

public static void SetInteger(UnityEngine.Animator _this, string name, int value)
{
	_this.SetInteger(name, value);
}

public static void SetInteger(UnityEngine.Animator _this, int id, int value)
{
	_this.SetInteger(id, value);
}

public static void SetTrigger(UnityEngine.Animator _this, string name)
{
	_this.SetTrigger(name);
}

public static void SetTrigger(UnityEngine.Animator _this, int id)
{
	_this.SetTrigger(id);
}

public static void ResetTrigger(UnityEngine.Animator _this, string name)
{
	_this.ResetTrigger(name);
}

public static void ResetTrigger(UnityEngine.Animator _this, int id)
{
	_this.ResetTrigger(id);
}

public static bool IsParameterControlledByCurve(UnityEngine.Animator _this, string name)
{
	return _this.IsParameterControlledByCurve(name);
}

public static bool IsParameterControlledByCurve(UnityEngine.Animator _this, int id)
{
	return _this.IsParameterControlledByCurve(id);
}

public static UnityEngine.Vector3 GetIKPosition(UnityEngine.Animator _this, int goal)
{
	return _this.GetIKPosition((UnityEngine.AvatarIKGoal)goal);
}

public static void SetIKPosition(UnityEngine.Animator _this, int goal, UnityEngine.Vector3 goalPosition)
{
	_this.SetIKPosition((UnityEngine.AvatarIKGoal)goal, goalPosition);
}

public static UnityEngine.Quaternion GetIKRotation(UnityEngine.Animator _this, int goal)
{
	return _this.GetIKRotation((UnityEngine.AvatarIKGoal)goal);
}

public static void SetIKRotation(UnityEngine.Animator _this, int goal, UnityEngine.Quaternion goalRotation)
{
	_this.SetIKRotation((UnityEngine.AvatarIKGoal)goal, goalRotation);
}

public static float GetIKPositionWeight(UnityEngine.Animator _this, int goal)
{
	return _this.GetIKPositionWeight((UnityEngine.AvatarIKGoal)goal);
}

public static void SetIKPositionWeight(UnityEngine.Animator _this, int goal, float value)
{
	_this.SetIKPositionWeight((UnityEngine.AvatarIKGoal)goal, value);
}

public static float GetIKRotationWeight(UnityEngine.Animator _this, int goal)
{
	return _this.GetIKRotationWeight((UnityEngine.AvatarIKGoal)goal);
}

public static void SetIKRotationWeight(UnityEngine.Animator _this, int goal, float value)
{
	_this.SetIKRotationWeight((UnityEngine.AvatarIKGoal)goal, value);
}

public static UnityEngine.Vector3 GetIKHintPosition(UnityEngine.Animator _this, int hint)
{
	return _this.GetIKHintPosition((UnityEngine.AvatarIKHint)hint);
}

public static void SetIKHintPosition(UnityEngine.Animator _this, int hint, UnityEngine.Vector3 hintPosition)
{
	_this.SetIKHintPosition((UnityEngine.AvatarIKHint)hint, hintPosition);
}

public static float GetIKHintPositionWeight(UnityEngine.Animator _this, int hint)
{
	return _this.GetIKHintPositionWeight((UnityEngine.AvatarIKHint)hint);
}

public static void SetIKHintPositionWeight(UnityEngine.Animator _this, int hint, float value)
{
	_this.SetIKHintPositionWeight((UnityEngine.AvatarIKHint)hint, value);
}

public static void SetLookAtPosition(UnityEngine.Animator _this, UnityEngine.Vector3 lookAtPosition)
{
	_this.SetLookAtPosition(lookAtPosition);
}

public static void SetLookAtWeight(UnityEngine.Animator _this, float weight)
{
	_this.SetLookAtWeight(weight);
}

public static void SetLookAtWeight(UnityEngine.Animator _this, float weight, float bodyWeight)
{
	_this.SetLookAtWeight(weight, bodyWeight);
}

public static void SetLookAtWeight(UnityEngine.Animator _this, float weight, float bodyWeight, float headWeight)
{
	_this.SetLookAtWeight(weight, bodyWeight, headWeight);
}

public static void SetLookAtWeight(UnityEngine.Animator _this, float weight, float bodyWeight, float headWeight, float eyesWeight)
{
	_this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight);
}

public static void SetLookAtWeight(UnityEngine.Animator _this, float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight)
{
	_this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
}

public static void SetBoneLocalRotation(UnityEngine.Animator _this, int humanBoneId, UnityEngine.Quaternion rotation)
{
	_this.SetBoneLocalRotation((UnityEngine.HumanBodyBones)humanBoneId, rotation);
}

public static UnityEngine.StateMachineBehaviour[] GetBehaviours(UnityEngine.Animator _this, int fullPathHash, int layerIndex)
{
	return _this.GetBehaviours(fullPathHash, layerIndex);
}

public static string GetLayerName(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetLayerName(layerIndex);
}

public static int GetLayerIndex(UnityEngine.Animator _this, string layerName)
{
	return _this.GetLayerIndex(layerName);
}

public static float GetLayerWeight(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetLayerWeight(layerIndex);
}

public static void SetLayerWeight(UnityEngine.Animator _this, int layerIndex, float weight)
{
	_this.SetLayerWeight(layerIndex, weight);
}

public static UnityEngine.AnimatorStateInfo GetCurrentAnimatorStateInfo(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetCurrentAnimatorStateInfo(layerIndex);
}

public static UnityEngine.AnimatorStateInfo GetNextAnimatorStateInfo(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetNextAnimatorStateInfo(layerIndex);
}

public static UnityEngine.AnimatorTransitionInfo GetAnimatorTransitionInfo(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetAnimatorTransitionInfo(layerIndex);
}

public static int GetCurrentAnimatorClipInfoCount(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetCurrentAnimatorClipInfoCount(layerIndex);
}

public static int GetNextAnimatorClipInfoCount(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetNextAnimatorClipInfoCount(layerIndex);
}

public static UnityEngine.AnimatorClipInfo[] GetCurrentAnimatorClipInfo(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetCurrentAnimatorClipInfo(layerIndex);
}

public static UnityEngine.AnimatorClipInfo[] GetNextAnimatorClipInfo(UnityEngine.Animator _this, int layerIndex)
{
	return _this.GetNextAnimatorClipInfo(layerIndex);
}

public static bool IsInTransition(UnityEngine.Animator _this, int layerIndex)
{
	return _this.IsInTransition(layerIndex);
}

public static UnityEngine.AnimatorControllerParameter GetParameter(UnityEngine.Animator _this, int index)
{
	return _this.GetParameter(index);
}

public static void MatchTarget(UnityEngine.Animator _this, UnityEngine.Vector3 matchPosition, UnityEngine.Quaternion matchRotation, int targetBodyPart, UnityEngine.MatchTargetWeightMask weightMask, float startNormalizedTime)
{
	_this.MatchTarget(matchPosition, matchRotation, (UnityEngine.AvatarTarget)targetBodyPart, weightMask, startNormalizedTime);
}

public static void MatchTarget(UnityEngine.Animator _this, UnityEngine.Vector3 matchPosition, UnityEngine.Quaternion matchRotation, int targetBodyPart, UnityEngine.MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime)
{
	_this.MatchTarget(matchPosition, matchRotation, (UnityEngine.AvatarTarget)targetBodyPart, weightMask, startNormalizedTime, targetNormalizedTime);
}

public static void MatchTarget(UnityEngine.Animator _this, UnityEngine.Vector3 matchPosition, UnityEngine.Quaternion matchRotation, int targetBodyPart, UnityEngine.MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime, bool completeMatch)
{
	_this.MatchTarget(matchPosition, matchRotation, (UnityEngine.AvatarTarget)targetBodyPart, weightMask, startNormalizedTime, targetNormalizedTime, completeMatch);
}

public static void InterruptMatchTarget(UnityEngine.Animator _this)
{
	_this.InterruptMatchTarget();
}

public static void InterruptMatchTarget(UnityEngine.Animator _this, bool completeMatch)
{
	_this.InterruptMatchTarget(completeMatch);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, string stateName, float fixedTransitionDuration)
{
	_this.CrossFadeInFixedTime(stateName, fixedTransitionDuration);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, string stateName, float fixedTransitionDuration, int layer)
{
	_this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
{
	_this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime)
{
	_this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
{
	_this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, int stateHashName, float fixedTransitionDuration, int layer)
{
	_this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, int stateHashName, float fixedTransitionDuration)
{
	_this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration);
}

public static void CrossFadeInFixedTime(UnityEngine.Animator _this, int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset, float normalizedTransitionTime)
{
	_this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
}

public static void WriteDefaultValues(UnityEngine.Animator _this)
{
	_this.WriteDefaultValues();
}

public static void CrossFade(UnityEngine.Animator _this, string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
{
	_this.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset);
}

public static void CrossFade(UnityEngine.Animator _this, string stateName, float normalizedTransitionDuration, int layer)
{
	_this.CrossFade(stateName, normalizedTransitionDuration, layer);
}

public static void CrossFade(UnityEngine.Animator _this, string stateName, float normalizedTransitionDuration)
{
	_this.CrossFade(stateName, normalizedTransitionDuration);
}

public static void CrossFade(UnityEngine.Animator _this, string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime)
{
	_this.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
}

public static void CrossFade(UnityEngine.Animator _this, int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime)
{
	_this.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
}

public static void CrossFade(UnityEngine.Animator _this, int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
{
	_this.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset);
}

public static void CrossFade(UnityEngine.Animator _this, int stateHashName, float normalizedTransitionDuration, int layer)
{
	_this.CrossFade(stateHashName, normalizedTransitionDuration, layer);
}

public static void CrossFade(UnityEngine.Animator _this, int stateHashName, float normalizedTransitionDuration)
{
	_this.CrossFade(stateHashName, normalizedTransitionDuration);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, string stateName, int layer)
{
	_this.PlayInFixedTime(stateName, layer);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, string stateName)
{
	_this.PlayInFixedTime(stateName);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, string stateName, int layer, float fixedTime)
{
	_this.PlayInFixedTime(stateName, layer, fixedTime);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, int stateNameHash, int layer, float fixedTime)
{
	_this.PlayInFixedTime(stateNameHash, layer, fixedTime);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, int stateNameHash, int layer)
{
	_this.PlayInFixedTime(stateNameHash, layer);
}

public static void PlayInFixedTime(UnityEngine.Animator _this, int stateNameHash)
{
	_this.PlayInFixedTime(stateNameHash);
}

public static void Play(UnityEngine.Animator _this, string stateName, int layer)
{
	_this.Play(stateName, layer);
}

public static void Play(UnityEngine.Animator _this, string stateName)
{
	_this.Play(stateName);
}

public static void Play(UnityEngine.Animator _this, string stateName, int layer, float normalizedTime)
{
	_this.Play(stateName, layer, normalizedTime);
}

public static void Play(UnityEngine.Animator _this, int stateNameHash, int layer, float normalizedTime)
{
	_this.Play(stateNameHash, layer, normalizedTime);
}

public static void Play(UnityEngine.Animator _this, int stateNameHash, int layer)
{
	_this.Play(stateNameHash, layer);
}

public static void Play(UnityEngine.Animator _this, int stateNameHash)
{
	_this.Play(stateNameHash);
}

public static void SetTarget(UnityEngine.Animator _this, int targetIndex, float targetNormalizedTime)
{
	_this.SetTarget((UnityEngine.AvatarTarget)targetIndex, targetNormalizedTime);
}

public static UnityEngine.Transform GetBoneTransform(UnityEngine.Animator _this, int humanBoneId)
{
	return _this.GetBoneTransform((UnityEngine.HumanBodyBones)humanBoneId);
}

public static void StartPlayback(UnityEngine.Animator _this)
{
	_this.StartPlayback();
}

public static void StopPlayback(UnityEngine.Animator _this)
{
	_this.StopPlayback();
}

public static void StartRecording(UnityEngine.Animator _this, int frameCount)
{
	_this.StartRecording(frameCount);
}

public static void StopRecording(UnityEngine.Animator _this)
{
	_this.StopRecording();
}

public static bool HasState(UnityEngine.Animator _this, int layerIndex, int stateID)
{
	return _this.HasState(layerIndex, stateID);
}

public static void Update(UnityEngine.Animator _this, float deltaTime)
{
	_this.Update(deltaTime);
}

public static void Rebind(UnityEngine.Animator _this)
{
	_this.Rebind();
}

public static void ApplyBuiltinRootMotion(UnityEngine.Animator _this)
{
	_this.ApplyBuiltinRootMotion();
}

public static bool get_isOptimizable(UnityEngine.Animator _this)
{
	return _this.isOptimizable;
}

public static bool get_isHuman(UnityEngine.Animator _this)
{
	return _this.isHuman;
}

public static bool get_hasRootMotion(UnityEngine.Animator _this)
{
	return _this.hasRootMotion;
}

public static float get_humanScale(UnityEngine.Animator _this)
{
	return _this.humanScale;
}

public static bool get_isInitialized(UnityEngine.Animator _this)
{
	return _this.isInitialized;
}

public static UnityEngine.Vector3 get_deltaPosition(UnityEngine.Animator _this)
{
	return _this.deltaPosition;
}

public static UnityEngine.Quaternion get_deltaRotation(UnityEngine.Animator _this)
{
	return _this.deltaRotation;
}

public static UnityEngine.Vector3 get_velocity(UnityEngine.Animator _this)
{
	return _this.velocity;
}

public static UnityEngine.Vector3 get_angularVelocity(UnityEngine.Animator _this)
{
	return _this.angularVelocity;
}

public static UnityEngine.Vector3 get_rootPosition(UnityEngine.Animator _this)
{
	return _this.rootPosition;
}

public static void set_rootPosition(UnityEngine.Animator _this, UnityEngine.Vector3 value)
{
	_this.rootPosition = value;
}

public static UnityEngine.Quaternion get_rootRotation(UnityEngine.Animator _this)
{
	return _this.rootRotation;
}

public static void set_rootRotation(UnityEngine.Animator _this, UnityEngine.Quaternion value)
{
	_this.rootRotation = value;
}

public static bool get_applyRootMotion(UnityEngine.Animator _this)
{
	return _this.applyRootMotion;
}

public static void set_applyRootMotion(UnityEngine.Animator _this, bool value)
{
	_this.applyRootMotion = value;
}

public static UnityEngine.AnimatorUpdateMode get_updateMode(UnityEngine.Animator _this)
{
	return _this.updateMode;
}

public static void set_updateMode(UnityEngine.Animator _this, UnityEngine.AnimatorUpdateMode value)
{
	_this.updateMode = value;
}

public static bool get_hasTransformHierarchy(UnityEngine.Animator _this)
{
	return _this.hasTransformHierarchy;
}

public static float get_gravityWeight(UnityEngine.Animator _this)
{
	return _this.gravityWeight;
}

public static UnityEngine.Vector3 get_bodyPosition(UnityEngine.Animator _this)
{
	return _this.bodyPosition;
}

public static void set_bodyPosition(UnityEngine.Animator _this, UnityEngine.Vector3 value)
{
	_this.bodyPosition = value;
}

public static UnityEngine.Quaternion get_bodyRotation(UnityEngine.Animator _this)
{
	return _this.bodyRotation;
}

public static void set_bodyRotation(UnityEngine.Animator _this, UnityEngine.Quaternion value)
{
	_this.bodyRotation = value;
}

public static bool get_stabilizeFeet(UnityEngine.Animator _this)
{
	return _this.stabilizeFeet;
}

public static void set_stabilizeFeet(UnityEngine.Animator _this, bool value)
{
	_this.stabilizeFeet = value;
}

public static int get_layerCount(UnityEngine.Animator _this)
{
	return _this.layerCount;
}

public static UnityEngine.AnimatorControllerParameter[] get_parameters(UnityEngine.Animator _this)
{
	return _this.parameters;
}

public static int get_parameterCount(UnityEngine.Animator _this)
{
	return _this.parameterCount;
}

public static float get_feetPivotActive(UnityEngine.Animator _this)
{
	return _this.feetPivotActive;
}

public static void set_feetPivotActive(UnityEngine.Animator _this, float value)
{
	_this.feetPivotActive = value;
}

public static float get_pivotWeight(UnityEngine.Animator _this)
{
	return _this.pivotWeight;
}

public static UnityEngine.Vector3 get_pivotPosition(UnityEngine.Animator _this)
{
	return _this.pivotPosition;
}

public static bool get_isMatchingTarget(UnityEngine.Animator _this)
{
	return _this.isMatchingTarget;
}

public static float get_speed(UnityEngine.Animator _this)
{
	return _this.speed;
}

public static void set_speed(UnityEngine.Animator _this, float value)
{
	_this.speed = value;
}

public static UnityEngine.Vector3 get_targetPosition(UnityEngine.Animator _this)
{
	return _this.targetPosition;
}

public static UnityEngine.Quaternion get_targetRotation(UnityEngine.Animator _this)
{
	return _this.targetRotation;
}

public static UnityEngine.AnimatorCullingMode get_cullingMode(UnityEngine.Animator _this)
{
	return _this.cullingMode;
}

public static void set_cullingMode(UnityEngine.Animator _this, UnityEngine.AnimatorCullingMode value)
{
	_this.cullingMode = value;
}

public static float get_playbackTime(UnityEngine.Animator _this)
{
	return _this.playbackTime;
}

public static void set_playbackTime(UnityEngine.Animator _this, float value)
{
	_this.playbackTime = value;
}

public static float get_recorderStartTime(UnityEngine.Animator _this)
{
	return _this.recorderStartTime;
}

public static void set_recorderStartTime(UnityEngine.Animator _this, float value)
{
	_this.recorderStartTime = value;
}

public static float get_recorderStopTime(UnityEngine.Animator _this)
{
	return _this.recorderStopTime;
}

public static void set_recorderStopTime(UnityEngine.Animator _this, float value)
{
	_this.recorderStopTime = value;
}

public static UnityEngine.AnimatorRecorderMode get_recorderMode(UnityEngine.Animator _this)
{
	return _this.recorderMode;
}

public static UnityEngine.RuntimeAnimatorController get_runtimeAnimatorController(UnityEngine.Animator _this)
{
	return _this.runtimeAnimatorController;
}

public static void set_runtimeAnimatorController(UnityEngine.Animator _this, UnityEngine.RuntimeAnimatorController value)
{
	_this.runtimeAnimatorController = value;
}

public static bool get_hasBoundPlayables(UnityEngine.Animator _this)
{
	return _this.hasBoundPlayables;
}

public static UnityEngine.Avatar get_avatar(UnityEngine.Animator _this)
{
	return _this.avatar;
}

public static void set_avatar(UnityEngine.Animator _this, UnityEngine.Avatar value)
{
	_this.avatar = value;
}

public static UnityEngine.Playables.PlayableGraph get_playableGraph(UnityEngine.Animator _this)
{
	return _this.playableGraph;
}

public static bool get_layersAffectMassCenter(UnityEngine.Animator _this)
{
	return _this.layersAffectMassCenter;
}

public static void set_layersAffectMassCenter(UnityEngine.Animator _this, bool value)
{
	_this.layersAffectMassCenter = value;
}

public static float get_leftFeetBottomHeight(UnityEngine.Animator _this)
{
	return _this.leftFeetBottomHeight;
}

public static float get_rightFeetBottomHeight(UnityEngine.Animator _this)
{
	return _this.rightFeetBottomHeight;
}

public static bool get_logWarnings(UnityEngine.Animator _this)
{
	return _this.logWarnings;
}

public static void set_logWarnings(UnityEngine.Animator _this, bool value)
{
	_this.logWarnings = value;
}

public static bool get_fireEvents(UnityEngine.Animator _this)
{
	return _this.fireEvents;
}

public static void set_fireEvents(UnityEngine.Animator _this, bool value)
{
	_this.fireEvents = value;
}

public static bool get_keepAnimatorControllerStateOnDisable(UnityEngine.Animator _this)
{
	return _this.keepAnimatorControllerStateOnDisable;
}

public static void set_keepAnimatorControllerStateOnDisable(UnityEngine.Animator _this, bool value)
{
	_this.keepAnimatorControllerStateOnDisable = value;
}

}
}
