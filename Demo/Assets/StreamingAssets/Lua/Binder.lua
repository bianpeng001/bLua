local AutoWrap = require("Core/AutoWrap")
local DefineClass = AutoWrap.DefineClass


System = {}
System.Object = DefineClass({ class = "System.Object" })
System.Type = DefineClass({ class = "System.Type" })
System.Array = DefineClass({ class = "System.Array" })
System.Random = DefineClass({ class = "System.Random" })
System.ArrayInt = DefineClass({ class = "System.ArrayInt", baseClass = "System.Array" })
System.ArrayFloat = DefineClass({ class = "System.ArrayFloat", baseClass = "System.Array" })
System.ArrayString = DefineClass({ class = "System.ArrayString", baseClass = "System.Array" })
System.ArrayObject = DefineClass({ class = "System.ArrayObject", baseClass = "System.Array" })

System.Collections = {}

System.Collections.Generic = {}
System.Collections.Generic.ListInt = DefineClass({ class = "System.Collections.Generic.ListInt" })
System.Collections.Generic.ListFloat = DefineClass({ class = "System.Collections.Generic.ListFloat" })
System.Collections.Generic.ListString = DefineClass({ class = "System.Collections.Generic.ListString" })
System.Collections.Generic.ListObject = DefineClass({ class = "System.Collections.Generic.ListObject" })

UnityEngine = {}
UnityEngine.Object = DefineClass({ class = "UnityEngine.Object" })
UnityEngine.MonoBehaviour = DefineClass({ class = "UnityEngine.MonoBehaviour", baseClass = "UnityEngine.Behaviour" })
UnityEngine.Behaviour = DefineClass({ class = "UnityEngine.Behaviour", baseClass = "UnityEngine.Component" })
UnityEngine.Component = DefineClass({ class = "UnityEngine.Component", baseClass = "UnityEngine.Object" })
UnityEngine.GameObject = DefineClass({ class = "UnityEngine.GameObject", baseClass = "UnityEngine.Object" })
UnityEngine.Debug = DefineClass({ class = "UnityEngine.Debug" })
UnityEngine.Input = DefineClass({ class = "UnityEngine.Input" })
UnityEngine.Time = DefineClass({ class = "UnityEngine.Time" })
UnityEngine.Graphics = DefineClass({ class = "UnityEngine.Graphics" })
UnityEngine.Screen = DefineClass({ class = "UnityEngine.Screen" })
UnityEngine.Application = DefineClass({ class = "UnityEngine.Application" })
UnityEngine.AssetBundle = DefineClass({ class = "UnityEngine.AssetBundle", baseClass = "UnityEngine.Object" })
UnityEngine.Transform = DefineClass({ class = "UnityEngine.Transform", baseClass = "UnityEngine.Component" })
UnityEngine.Shader = DefineClass({ class = "UnityEngine.Shader", baseClass = "UnityEngine.Object" })
UnityEngine.Material = DefineClass({ class = "UnityEngine.Material", baseClass = "UnityEngine.Object" })
UnityEngine.MaterialPropertyBlock = DefineClass({ class = "UnityEngine.MaterialPropertyBlock" })
UnityEngine.Renderer = DefineClass({ class = "UnityEngine.Renderer", baseClass = "UnityEngine.Component" })
UnityEngine.MeshRenderer = DefineClass({ class = "UnityEngine.MeshRenderer", baseClass = "UnityEngine.Renderer" })
UnityEngine.SkinnedMeshRenderer = DefineClass({ class = "UnityEngine.SkinnedMeshRenderer", baseClass = "UnityEngine.Renderer" })
UnityEngine.MeshFilter = DefineClass({ class = "UnityEngine.MeshFilter", baseClass = "UnityEngine.Component" })
UnityEngine.Mesh = DefineClass({ class = "UnityEngine.Mesh", baseClass = "UnityEngine.Object" })
UnityEngine.Texture = DefineClass({ class = "UnityEngine.Texture", baseClass = "UnityEngine.Object" })
UnityEngine.RenderTexture = DefineClass({ class = "UnityEngine.RenderTexture", baseClass = "UnityEngine.Texture" })
UnityEngine.Texture2D = DefineClass({ class = "UnityEngine.Texture2D", baseClass = "UnityEngine.Texture" })
UnityEngine.Physics = DefineClass({ class = "UnityEngine.Physics" })
UnityEngine.Collider = DefineClass({ class = "UnityEngine.Collider", baseClass = "UnityEngine.Component" })
UnityEngine.MeshCollider = DefineClass({ class = "UnityEngine.MeshCollider", baseClass = "UnityEngine.Collider" })
UnityEngine.TrailRenderer = DefineClass({ class = "UnityEngine.TrailRenderer", baseClass = "UnityEngine.Renderer" })
UnityEngine.LineRenderer = DefineClass({ class = "UnityEngine.LineRenderer", baseClass = "UnityEngine.Renderer" })
UnityEngine.BoxCollider = DefineClass({ class = "UnityEngine.BoxCollider", baseClass = "UnityEngine.Collider" })
UnityEngine.CapsuleCollider = DefineClass({ class = "UnityEngine.CapsuleCollider", baseClass = "UnityEngine.Collider" })
UnityEngine.SphereCollider = DefineClass({ class = "UnityEngine.SphereCollider", baseClass = "UnityEngine.Collider" })
UnityEngine.CharacterController = DefineClass({ class = "UnityEngine.CharacterController", baseClass = "UnityEngine.Collider" })
UnityEngine.Rigidbody = DefineClass({ class = "UnityEngine.Rigidbody", baseClass = "UnityEngine.Component" })
UnityEngine.Animator = DefineClass({ class = "UnityEngine.Animator", baseClass = "UnityEngine.Behaviour" })
UnityEngine.Animation = DefineClass({ class = "UnityEngine.Animation", baseClass = "UnityEngine.Behaviour" })
UnityEngine.AnimationClip = DefineClass({ class = "UnityEngine.AnimationClip", baseClass = "UnityEngine.Motion" })
UnityEngine.Motion = DefineClass({ class = "UnityEngine.Motion", baseClass = "UnityEngine.Object" })
UnityEngine.Light = DefineClass({ class = "UnityEngine.Light", baseClass = "UnityEngine.Behaviour" })
UnityEngine.Camera = DefineClass({ class = "UnityEngine.Camera", baseClass = "UnityEngine.Behaviour" })
UnityEngine.ParticleSystem = DefineClass({ class = "UnityEngine.ParticleSystem", baseClass = "UnityEngine.Component" })
UnityEngine.Canvas = DefineClass({ class = "UnityEngine.Canvas", baseClass = "UnityEngine.Behaviour" })
UnityEngine.Mathf = DefineClass({ class = "UnityEngine.Mathf" })
UnityEngine.Color = DefineClass({ class = "UnityEngine.Color" })
UnityEngine.Quaternion = DefineClass({ class = "UnityEngine.Quaternion" })
UnityEngine.Vector4 = DefineClass({ class = "UnityEngine.Vector4" })
UnityEngine.Vector3 = DefineClass({ class = "UnityEngine.Vector3" })
UnityEngine.Vector2 = DefineClass({ class = "UnityEngine.Vector2" })
UnityEngine.Matrix4x4 = DefineClass({ class = "UnityEngine.Matrix4x4" })

bLua = {}
bLua.LuaDelegate = DefineClass({ class = "bLua.LuaDelegate" })
bLua.LogUtil = DefineClass({ class = "bLua.LogUtil" })
bLua.Example = DefineClass({ class = "bLua.Example", baseClass = "UnityEngine.MonoBehaviour" })
bLua.Example02 = DefineClass({ class = "bLua.Example02", baseClass = "UnityEngine.MonoBehaviour" })
bLua.MoveSystem = DefineClass({ class = "bLua.MoveSystem" })

bLua.LuaDelegate.__call = CallLuaDelegate or function(obj, ...)
	print(obj, ...)
end

UnityEngine.HideFlags =
{
	None = 0,
	HideInHierarchy = 1,
	HideInInspector = 2,
	DontSaveInEditor = 4,
	NotEditable = 8,
	DontSaveInBuild = 16,
	DontUnloadUnusedAsset = 32,
	DontSave = 52,
	HideAndDontSave = 61,
}

UnityEngine.SendMessageOptions =
{
	RequireReceiver = 0,
	DontRequireReceiver = 1,
}

UnityEngine.Space =
{
	World = 0,
	Self = 1,
}


UnityEngine.Rendering = {}
UnityEngine.Rendering.ShaderPropertyType =
{
	Color = 0,
	Vector = 1,
	Float = 2,
	Range = 3,
	Texture = 4,
}

UnityEngine.Rendering.ShaderPropertyFlags =
{
	None = 0,
	HideInInspector = 1,
	PerRendererData = 2,
	NoScaleOffset = 4,
	Normal = 8,
	HDR = 16,
	Gamma = 32,
	NonModifiableTextureData = 64,
	MainTexture = 128,
	MainColor = 256,
}

UnityEngine.Rendering.TextureDimension =
{
	None = 0,
	Any = 1,
	Tex2D = 2,
	Tex3D = 3,
	Cube = 4,
	Tex2DArray = 5,
	CubeArray = 6,
	Unknown = -1,
}

UnityEngine.Rendering.RenderTextureSubElement =
{
	Color = 0,
	Depth = 1,
	Stencil = 2,
	Default = 3,
}

UnityEngine.MaterialGlobalIlluminationFlags =
{
	None = 0,
	RealtimeEmissive = 1,
	BakedEmissive = 2,
	AnyEmissive = 3,
	EmissiveIsBlack = 4,
}

UnityEngine.Rendering.ShadowCastingMode =
{
	Off = 0,
	On = 1,
	TwoSided = 2,
	ShadowsOnly = 3,
}

UnityEngine.MotionVectorGenerationMode =
{
	Camera = 0,
	Object = 1,
	ForceNoMotion = 2,
}

UnityEngine.Rendering.LightProbeUsage =
{
	Off = 0,
	BlendProbes = 1,
	UseProxyVolume = 2,
	CustomProvided = 4,
}

UnityEngine.Rendering.ReflectionProbeUsage =
{
	Off = 0,
	BlendProbes = 1,
	BlendProbesAndSkybox = 2,
	Simple = 3,
}


UnityEngine.Experimental = {}

UnityEngine.Experimental.Rendering = {}
UnityEngine.Experimental.Rendering.RayTracingMode =
{
	Off = 0,
	Static = 1,
	DynamicTransform = 2,
	DynamicGeometry = 3,
}

UnityEngine.SkinQuality =
{
	Auto = 0,
	Bone1 = 1,
	Bone2 = 2,
	Bone4 = 4,
}

UnityEngine.Rendering.IndexFormat =
{
	UInt16 = 0,
	UInt32 = 1,
}

UnityEngine.Rendering.VertexAttribute =
{
	Position = 0,
	Normal = 1,
	Tangent = 2,
	Color = 3,
	TexCoord0 = 4,
	TexCoord1 = 5,
	TexCoord2 = 6,
	TexCoord3 = 7,
	TexCoord4 = 8,
	TexCoord5 = 9,
	TexCoord6 = 10,
	TexCoord7 = 11,
	BlendWeight = 12,
	BlendIndices = 13,
}

UnityEngine.Rendering.VertexAttributeFormat =
{
	Float32 = 0,
	Float16 = 1,
	UNorm8 = 2,
	SNorm8 = 3,
	UNorm16 = 4,
	SNorm16 = 5,
	UInt8 = 6,
	SInt8 = 7,
	UInt16 = 8,
	SInt16 = 9,
	UInt32 = 10,
	SInt32 = 11,
}

UnityEngine.Rendering.MeshUpdateFlags =
{
	Default = 0,
	DontValidateIndices = 1,
	DontResetBoneBounds = 2,
	DontNotifyMeshUsers = 4,
	DontRecalculateBounds = 8,
}

UnityEngine.MeshTopology =
{
	Triangles = 0,
	Quads = 2,
	Lines = 3,
	LineStrip = 4,
	Points = 5,
}

UnityEngine.Experimental.Rendering.GraphicsFormat =
{
	None = 0,
	R8_SRGB = 1,
	R8G8_SRGB = 2,
	R8G8B8_SRGB = 3,
	R8G8B8A8_SRGB = 4,
	R8_UNorm = 5,
	R8G8_UNorm = 6,
	R8G8B8_UNorm = 7,
	R8G8B8A8_UNorm = 8,
	R8_SNorm = 9,
	R8G8_SNorm = 10,
	R8G8B8_SNorm = 11,
	R8G8B8A8_SNorm = 12,
	R8_UInt = 13,
	R8G8_UInt = 14,
	R8G8B8_UInt = 15,
	R8G8B8A8_UInt = 16,
	R8_SInt = 17,
	R8G8_SInt = 18,
	R8G8B8_SInt = 19,
	R8G8B8A8_SInt = 20,
	R16_UNorm = 21,
	R16G16_UNorm = 22,
	R16G16B16_UNorm = 23,
	R16G16B16A16_UNorm = 24,
	R16_SNorm = 25,
	R16G16_SNorm = 26,
	R16G16B16_SNorm = 27,
	R16G16B16A16_SNorm = 28,
	R16_UInt = 29,
	R16G16_UInt = 30,
	R16G16B16_UInt = 31,
	R16G16B16A16_UInt = 32,
	R16_SInt = 33,
	R16G16_SInt = 34,
	R16G16B16_SInt = 35,
	R16G16B16A16_SInt = 36,
	R32_UInt = 37,
	R32G32_UInt = 38,
	R32G32B32_UInt = 39,
	R32G32B32A32_UInt = 40,
	R32_SInt = 41,
	R32G32_SInt = 42,
	R32G32B32_SInt = 43,
	R32G32B32A32_SInt = 44,
	R16_SFloat = 45,
	R16G16_SFloat = 46,
	R16G16B16_SFloat = 47,
	R16G16B16A16_SFloat = 48,
	R32_SFloat = 49,
	R32G32_SFloat = 50,
	R32G32B32_SFloat = 51,
	R32G32B32A32_SFloat = 52,
	B8G8R8_SRGB = 56,
	B8G8R8A8_SRGB = 57,
	B8G8R8_UNorm = 58,
	B8G8R8A8_UNorm = 59,
	B8G8R8_SNorm = 60,
	B8G8R8A8_SNorm = 61,
	B8G8R8_UInt = 62,
	B8G8R8A8_UInt = 63,
	B8G8R8_SInt = 64,
	B8G8R8A8_SInt = 65,
	R4G4B4A4_UNormPack16 = 66,
	B4G4R4A4_UNormPack16 = 67,
	R5G6B5_UNormPack16 = 68,
	B5G6R5_UNormPack16 = 69,
	R5G5B5A1_UNormPack16 = 70,
	B5G5R5A1_UNormPack16 = 71,
	A1R5G5B5_UNormPack16 = 72,
	E5B9G9R9_UFloatPack32 = 73,
	B10G11R11_UFloatPack32 = 74,
	A2B10G10R10_UNormPack32 = 75,
	A2B10G10R10_UIntPack32 = 76,
	A2B10G10R10_SIntPack32 = 77,
	A2R10G10B10_UNormPack32 = 78,
	A2R10G10B10_UIntPack32 = 79,
	A2R10G10B10_SIntPack32 = 80,
	A2R10G10B10_XRSRGBPack32 = 81,
	A2R10G10B10_XRUNormPack32 = 82,
	R10G10B10_XRSRGBPack32 = 83,
	R10G10B10_XRUNormPack32 = 84,
	A10R10G10B10_XRSRGBPack32 = 85,
	A10R10G10B10_XRUNormPack32 = 86,
	RGB_DXT1_SRGB = 96,
	RGBA_DXT1_SRGB = 96,
	RGB_DXT1_UNorm = 97,
	RGBA_DXT1_UNorm = 97,
	RGBA_DXT3_SRGB = 98,
	RGBA_DXT3_UNorm = 99,
	RGBA_DXT5_SRGB = 100,
	RGBA_DXT5_UNorm = 101,
	R_BC4_UNorm = 102,
	R_BC4_SNorm = 103,
	RG_BC5_UNorm = 104,
	RG_BC5_SNorm = 105,
	RGB_BC6H_UFloat = 106,
	RGB_BC6H_SFloat = 107,
	RGBA_BC7_SRGB = 108,
	RGBA_BC7_UNorm = 109,
	RGB_PVRTC_2Bpp_SRGB = 110,
	RGB_PVRTC_2Bpp_UNorm = 111,
	RGB_PVRTC_4Bpp_SRGB = 112,
	RGB_PVRTC_4Bpp_UNorm = 113,
	RGBA_PVRTC_2Bpp_SRGB = 114,
	RGBA_PVRTC_2Bpp_UNorm = 115,
	RGBA_PVRTC_4Bpp_SRGB = 116,
	RGBA_PVRTC_4Bpp_UNorm = 117,
	RGB_ETC_UNorm = 118,
	RGB_ETC2_SRGB = 119,
	RGB_ETC2_UNorm = 120,
	RGB_A1_ETC2_SRGB = 121,
	RGB_A1_ETC2_UNorm = 122,
	RGBA_ETC2_SRGB = 123,
	RGBA_ETC2_UNorm = 124,
	R_EAC_UNorm = 125,
	R_EAC_SNorm = 126,
	RG_EAC_UNorm = 127,
	RG_EAC_SNorm = 128,
	RGBA_ASTC4X4_SRGB = 129,
	RGBA_ASTC4X4_UNorm = 130,
	RGBA_ASTC5X5_SRGB = 131,
	RGBA_ASTC5X5_UNorm = 132,
	RGBA_ASTC6X6_SRGB = 133,
	RGBA_ASTC6X6_UNorm = 134,
	RGBA_ASTC8X8_SRGB = 135,
	RGBA_ASTC8X8_UNorm = 136,
	RGBA_ASTC10X10_SRGB = 137,
	RGBA_ASTC10X10_UNorm = 138,
	RGBA_ASTC12X12_SRGB = 139,
	RGBA_ASTC12X12_UNorm = 140,
	RGBA_ASTC4X4_UFloat = 145,
	RGBA_ASTC5X5_UFloat = 146,
	RGBA_ASTC6X6_UFloat = 147,
	RGBA_ASTC8X8_UFloat = 148,
	RGBA_ASTC10X10_UFloat = 149,
	RGBA_ASTC12X12_UFloat = 150,
}

UnityEngine.TextureWrapMode =
{
	Repeat = 0,
	Clamp = 1,
	Mirror = 2,
	MirrorOnce = 3,
}

UnityEngine.FilterMode =
{
	Point = 0,
	Bilinear = 1,
	Trilinear = 2,
}

UnityEngine.Camera.MonoOrStereoscopicEye =
{
	Left = 0,
	Right = 1,
	Mono = 2,
}

UnityEngine.VRTextureUsage =
{
	None = 0,
	OneEye = 1,
	TwoEyes = 2,
	DeviceSpecific = 3,
}

UnityEngine.RenderTextureMemoryless =
{
	None = 0,
	Color = 1,
	Depth = 2,
	MSAA = 4,
}

UnityEngine.RenderTextureFormat =
{
	ARGB32 = 0,
	Depth = 1,
	ARGBHalf = 2,
	Shadowmap = 3,
	RGB565 = 4,
	ARGB4444 = 5,
	ARGB1555 = 6,
	Default = 7,
	ARGB2101010 = 8,
	DefaultHDR = 9,
	ARGB64 = 10,
	ARGBFloat = 11,
	RGFloat = 12,
	RGHalf = 13,
	RFloat = 14,
	RHalf = 15,
	R8 = 16,
	ARGBInt = 17,
	RGInt = 18,
	RInt = 19,
	BGRA32 = 20,
	RGB111110Float = 22,
	RG32 = 23,
	RGBAUShort = 24,
	RG16 = 25,
	BGRA10101010_XR = 26,
	BGR101010_XR = 27,
	R16 = 28,
}

UnityEngine.TextureFormat =
{
	Alpha8 = 1,
	ARGB4444 = 2,
	RGB24 = 3,
	RGBA32 = 4,
	ARGB32 = 5,
	RGB565 = 7,
	R16 = 9,
	DXT1 = 10,
	DXT5 = 12,
	RGBA4444 = 13,
	BGRA32 = 14,
	RHalf = 15,
	RGHalf = 16,
	RGBAHalf = 17,
	RFloat = 18,
	RGFloat = 19,
	RGBAFloat = 20,
	YUY2 = 21,
	RGB9e5Float = 22,
	BC6H = 24,
	BC7 = 25,
	BC4 = 26,
	BC5 = 27,
	DXT1Crunched = 28,
	DXT5Crunched = 29,
	PVRTC_RGB2 = 30,
	PVRTC_RGBA2 = 31,
	PVRTC_RGB4 = 32,
	PVRTC_RGBA4 = 33,
	ETC_RGB4 = 34,
	EAC_R = 41,
	EAC_R_SIGNED = 42,
	EAC_RG = 43,
	EAC_RG_SIGNED = 44,
	ETC2_RGB = 45,
	ETC2_RGBA1 = 46,
	ETC2_RGBA8 = 47,
	ASTC_4x4 = 48,
	ASTC_RGB_4x4 = 48,
	ASTC_RGB_5x5 = 49,
	ASTC_5x5 = 49,
	ASTC_RGB_6x6 = 50,
	ASTC_6x6 = 50,
	ASTC_8x8 = 51,
	ASTC_RGB_8x8 = 51,
	ASTC_10x10 = 52,
	ASTC_RGB_10x10 = 52,
	ASTC_RGB_12x12 = 53,
	ASTC_12x12 = 53,
	ASTC_RGBA_4x4 = 54,
	ASTC_RGBA_5x5 = 55,
	ASTC_RGBA_6x6 = 56,
	ASTC_RGBA_8x8 = 57,
	ASTC_RGBA_10x10 = 58,
	ASTC_RGBA_12x12 = 59,
	ETC_RGB4_3DS = 60,
	ETC_RGBA8_3DS = 61,
	RG16 = 62,
	R8 = 63,
	ETC_RGB4Crunched = 64,
	ETC2_RGBA8Crunched = 65,
	ASTC_HDR_4x4 = 66,
	ASTC_HDR_5x5 = 67,
	ASTC_HDR_6x6 = 68,
	ASTC_HDR_8x8 = 69,
	ASTC_HDR_10x10 = 70,
	ASTC_HDR_12x12 = 71,
	RG32 = 72,
	RGB48 = 73,
	RGBA64 = 74,
	PVRTC_2BPP_RGB = -127,
	PVRTC_2BPP_RGBA = -127,
	ATC_RGB4 = -127,
	PVRTC_4BPP_RGB = -127,
	ATC_RGBA8 = -127,
	PVRTC_4BPP_RGBA = -127,
}

UnityEngine.MeshColliderCookingOptions =
{
	None = 0,
	InflateConvexMesh = 1,
	CookForFasterSimulation = 2,
	EnableMeshCleaning = 4,
	WeldColocatedVertices = 8,
	UseFastMidphase = 16,
}

UnityEngine.LineTextureMode =
{
	Stretch = 0,
	Tile = 1,
	DistributePerSegment = 2,
	RepeatPerSegment = 3,
}

UnityEngine.LineAlignment =
{
	View = 0,
	Local = 1,
	TransformZ = 1,
}

UnityEngine.CollisionFlags =
{
	None = 0,
	Sides = 1,
	CollidedSides = 1,
	Above = 2,
	CollidedAbove = 2,
	Below = 4,
	CollidedBelow = 4,
}

UnityEngine.ForceMode =
{
	Force = 0,
	Impulse = 1,
	VelocityChange = 2,
	Acceleration = 5,
}

UnityEngine.QueryTriggerInteraction =
{
	UseGlobal = 0,
	Ignore = 1,
	Collide = 2,
}

UnityEngine.RigidbodyConstraints =
{
	None = 0,
	FreezePositionX = 2,
	FreezePositionY = 4,
	FreezePositionZ = 8,
	FreezePosition = 14,
	FreezeRotationX = 16,
	FreezeRotationY = 32,
	FreezeRotationZ = 64,
	FreezeRotation = 112,
	FreezeAll = 126,
}

UnityEngine.CollisionDetectionMode =
{
	Discrete = 0,
	Continuous = 1,
	ContinuousDynamic = 2,
	ContinuousSpeculative = 3,
}

UnityEngine.RigidbodyInterpolation =
{
	None = 0,
	Interpolate = 1,
	Extrapolate = 2,
}

UnityEngine.AvatarIKGoal =
{
	LeftFoot = 0,
	RightFoot = 1,
	LeftHand = 2,
	RightHand = 3,
}

UnityEngine.AvatarIKHint =
{
	LeftKnee = 0,
	RightKnee = 1,
	LeftElbow = 2,
	RightElbow = 3,
}

UnityEngine.HumanBodyBones =
{
	Hips = 0,
	LeftUpperLeg = 1,
	RightUpperLeg = 2,
	LeftLowerLeg = 3,
	RightLowerLeg = 4,
	LeftFoot = 5,
	RightFoot = 6,
	Spine = 7,
	Chest = 8,
	Neck = 9,
	Head = 10,
	LeftShoulder = 11,
	RightShoulder = 12,
	LeftUpperArm = 13,
	RightUpperArm = 14,
	LeftLowerArm = 15,
	RightLowerArm = 16,
	LeftHand = 17,
	RightHand = 18,
	LeftToes = 19,
	RightToes = 20,
	LeftEye = 21,
	RightEye = 22,
	Jaw = 23,
	LeftThumbProximal = 24,
	LeftThumbIntermediate = 25,
	LeftThumbDistal = 26,
	LeftIndexProximal = 27,
	LeftIndexIntermediate = 28,
	LeftIndexDistal = 29,
	LeftMiddleProximal = 30,
	LeftMiddleIntermediate = 31,
	LeftMiddleDistal = 32,
	LeftRingProximal = 33,
	LeftRingIntermediate = 34,
	LeftRingDistal = 35,
	LeftLittleProximal = 36,
	LeftLittleIntermediate = 37,
	LeftLittleDistal = 38,
	RightThumbProximal = 39,
	RightThumbIntermediate = 40,
	RightThumbDistal = 41,
	RightIndexProximal = 42,
	RightIndexIntermediate = 43,
	RightIndexDistal = 44,
	RightMiddleProximal = 45,
	RightMiddleIntermediate = 46,
	RightMiddleDistal = 47,
	RightRingProximal = 48,
	RightRingIntermediate = 49,
	RightRingDistal = 50,
	RightLittleProximal = 51,
	RightLittleIntermediate = 52,
	RightLittleDistal = 53,
	UpperChest = 54,
	LastBone = 55,
}

UnityEngine.AvatarTarget =
{
	Root = 0,
	Body = 1,
	LeftFoot = 2,
	RightFoot = 3,
	LeftHand = 4,
	RightHand = 5,
}

UnityEngine.AnimatorUpdateMode =
{
	Normal = 0,
	AnimatePhysics = 1,
	UnscaledTime = 2,
}

UnityEngine.AnimatorCullingMode =
{
	AlwaysAnimate = 0,
	CullUpdateTransforms = 1,
	BasedOnRenderers = 1,
	CullCompletely = 2,
}

UnityEngine.AnimatorRecorderMode =
{
	Offline = 0,
	Playback = 1,
	Record = 2,
}

UnityEngine.PlayMode =
{
	StopSameLayer = 0,
	StopAll = 4,
}

UnityEngine.QueueMode =
{
	CompleteOthers = 0,
	PlayNow = 2,
}

UnityEngine.WrapMode =
{
	Default = 0,
	Once = 1,
	Clamp = 1,
	Loop = 2,
	PingPong = 4,
	ClampForever = 8,
}

UnityEngine.Rendering.LightEvent =
{
	BeforeShadowMap = 0,
	AfterShadowMap = 1,
	BeforeScreenspaceMask = 2,
	AfterScreenspaceMask = 3,
	BeforeShadowMapPass = 4,
	AfterShadowMapPass = 5,
}

UnityEngine.Rendering.ShadowMapPass =
{
	PointlightPositiveX = 1,
	PointlightNegativeX = 2,
	PointlightPositiveY = 4,
	PointlightNegativeY = 8,
	PointlightPositiveZ = 16,
	PointlightNegativeZ = 32,
	Pointlight = 63,
	DirectionalCascade0 = 64,
	DirectionalCascade1 = 128,
	DirectionalCascade2 = 256,
	DirectionalCascade3 = 512,
	Directional = 960,
	Spotlight = 1024,
	All = 2047,
}

UnityEngine.Rendering.ComputeQueueType =
{
	Default = 0,
	Background = 1,
	Urgent = 2,
}

UnityEngine.LightType =
{
	Spot = 0,
	Directional = 1,
	Point = 2,
	Area = 3,
	Rectangle = 3,
	Disc = 4,
}

UnityEngine.LightShape =
{
	Cone = 0,
	Pyramid = 1,
	Box = 2,
}

UnityEngine.LightShadowCasterMode =
{
	Default = 0,
	NonLightmappedOnly = 1,
	Everything = 2,
}

UnityEngine.LightShadows =
{
	None = 0,
	Hard = 1,
	Soft = 2,
}

UnityEngine.Rendering.LightShadowResolution =
{
	Low = 0,
	Medium = 1,
	High = 2,
	VeryHigh = 3,
	FromQualitySettings = -1,
}

UnityEngine.LightRenderMode =
{
	Auto = 0,
	ForcePixel = 1,
	ForceVertex = 2,
}

UnityEngine.Camera.StereoscopicEye =
{
	Left = 0,
	Right = 1,
}

UnityEngine.Rendering.CameraEvent =
{
	BeforeDepthTexture = 0,
	AfterDepthTexture = 1,
	BeforeDepthNormalsTexture = 2,
	AfterDepthNormalsTexture = 3,
	BeforeGBuffer = 4,
	AfterGBuffer = 5,
	BeforeLighting = 6,
	AfterLighting = 7,
	BeforeFinalPass = 8,
	AfterFinalPass = 9,
	BeforeForwardOpaque = 10,
	AfterForwardOpaque = 11,
	BeforeImageEffectsOpaque = 12,
	AfterImageEffectsOpaque = 13,
	BeforeSkybox = 14,
	AfterSkybox = 15,
	BeforeForwardAlpha = 16,
	AfterForwardAlpha = 17,
	BeforeImageEffects = 18,
	AfterImageEffects = 19,
	AfterEverything = 20,
	BeforeReflections = 21,
	AfterReflections = 22,
	BeforeHaloAndLensFlares = 23,
	AfterHaloAndLensFlares = 24,
}

UnityEngine.RenderingPath =
{
	VertexLit = 0,
	Forward = 1,
	DeferredLighting = 2,
	DeferredShading = 3,
	UsePlayerSettings = -1,
}

UnityEngine.Rendering.OpaqueSortMode =
{
	Default = 0,
	FrontToBack = 1,
	NoDistanceSort = 2,
}

UnityEngine.TransparencySortMode =
{
	Default = 0,
	Perspective = 1,
	Orthographic = 2,
	CustomAxis = 3,
}

UnityEngine.CameraType =
{
	Game = 1,
	SceneView = 2,
	Preview = 4,
	VR = 8,
	Reflection = 16,
}

UnityEngine.CameraClearFlags =
{
	Skybox = 1,
	Color = 2,
	SolidColor = 2,
	Depth = 3,
	Nothing = 4,
}

UnityEngine.DepthTextureMode =
{
	None = 0,
	Depth = 1,
	DepthNormals = 2,
	MotionVectors = 4,
}

UnityEngine.Camera.GateFitMode =
{
	None = 0,
	Vertical = 1,
	Horizontal = 2,
	Fill = 3,
	Overscan = 4,
}

UnityEngine.StereoTargetEyeMask =
{
	None = 0,
	Left = 1,
	Right = 2,
	Both = 3,
}

UnityEngine.ParticleSystemStopBehavior =
{
	StopEmittingAndClear = 0,
	StopEmitting = 1,
}

UnityEngine.RenderMode =
{
	ScreenSpaceOverlay = 0,
	ScreenSpaceCamera = 1,
	WorldSpace = 2,
}

UnityEngine.AdditionalCanvasShaderChannels =
{
	None = 0,
	TexCoord1 = 1,
	TexCoord2 = 2,
	TexCoord3 = 4,
	Normal = 8,
	Tangent = 16,
}

print("lua binder ok")

