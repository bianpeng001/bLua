
using System;
using UnityEngine;

namespace bLua.Extension
{
public static class UnityEngine_Mesh
{
public static void SetIndexBufferParams(UnityEngine.Mesh _this, int indexCount, int format)
{
	_this.SetIndexBufferParams(indexCount, (UnityEngine.Rendering.IndexFormat)format);
}

public static UnityEngine.Rendering.VertexAttributeDescriptor GetVertexAttribute(UnityEngine.Mesh _this, int index)
{
	return _this.GetVertexAttribute(index);
}

public static bool HasVertexAttribute(UnityEngine.Mesh _this, int attr)
{
	return _this.HasVertexAttribute((UnityEngine.Rendering.VertexAttribute)attr);
}

public static int GetVertexAttributeDimension(UnityEngine.Mesh _this, int attr)
{
	return _this.GetVertexAttributeDimension((UnityEngine.Rendering.VertexAttribute)attr);
}

public static UnityEngine.Rendering.VertexAttributeFormat GetVertexAttributeFormat(UnityEngine.Mesh _this, int attr)
{
	return _this.GetVertexAttributeFormat((UnityEngine.Rendering.VertexAttribute)attr);
}

public static System.IntPtr GetNativeVertexBufferPtr(UnityEngine.Mesh _this, int index)
{
	return _this.GetNativeVertexBufferPtr(index);
}

public static System.IntPtr GetNativeIndexBufferPtr(UnityEngine.Mesh _this)
{
	return _this.GetNativeIndexBufferPtr();
}

public static void ClearBlendShapes(UnityEngine.Mesh _this)
{
	_this.ClearBlendShapes();
}

public static string GetBlendShapeName(UnityEngine.Mesh _this, int shapeIndex)
{
	return _this.GetBlendShapeName(shapeIndex);
}

public static int GetBlendShapeIndex(UnityEngine.Mesh _this, string blendShapeName)
{
	return _this.GetBlendShapeIndex(blendShapeName);
}

public static int GetBlendShapeFrameCount(UnityEngine.Mesh _this, int shapeIndex)
{
	return _this.GetBlendShapeFrameCount(shapeIndex);
}

public static float GetBlendShapeFrameWeight(UnityEngine.Mesh _this, int shapeIndex, int frameIndex)
{
	return _this.GetBlendShapeFrameWeight(shapeIndex, frameIndex);
}

public static void GetBlendShapeFrameVertices(UnityEngine.Mesh _this, int shapeIndex, int frameIndex, UnityEngine.Vector3[] deltaVertices, UnityEngine.Vector3[] deltaNormals, UnityEngine.Vector3[] deltaTangents)
{
	_this.GetBlendShapeFrameVertices(shapeIndex, frameIndex, deltaVertices, deltaNormals, deltaTangents);
}

public static void AddBlendShapeFrame(UnityEngine.Mesh _this, string shapeName, float frameWeight, UnityEngine.Vector3[] deltaVertices, UnityEngine.Vector3[] deltaNormals, UnityEngine.Vector3[] deltaTangents)
{
	_this.AddBlendShapeFrame(shapeName, frameWeight, deltaVertices, deltaNormals, deltaTangents);
}

public static void SetSubMesh(UnityEngine.Mesh _this, int index, UnityEngine.Rendering.SubMeshDescriptor desc, int flags)
{
	_this.SetSubMesh(index, desc, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static UnityEngine.Rendering.SubMeshDescriptor GetSubMesh(UnityEngine.Mesh _this, int index)
{
	return _this.GetSubMesh(index);
}

public static void MarkModified(UnityEngine.Mesh _this)
{
	_this.MarkModified();
}

public static float GetUVDistributionMetric(UnityEngine.Mesh _this, int uvSetIndex)
{
	return _this.GetUVDistributionMetric(uvSetIndex);
}

public static void SetVertices(UnityEngine.Mesh _this, UnityEngine.Vector3[] inVertices)
{
	_this.SetVertices(inVertices);
}

public static void SetVertices(UnityEngine.Mesh _this, UnityEngine.Vector3[] inVertices, int start, int length)
{
	_this.SetVertices(inVertices, start, length);
}

public static void SetVertices(UnityEngine.Mesh _this, UnityEngine.Vector3[] inVertices, int start, int length, int flags)
{
	_this.SetVertices(inVertices, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetNormals(UnityEngine.Mesh _this, UnityEngine.Vector3[] inNormals)
{
	_this.SetNormals(inNormals);
}

public static void SetNormals(UnityEngine.Mesh _this, UnityEngine.Vector3[] inNormals, int start, int length)
{
	_this.SetNormals(inNormals, start, length);
}

public static void SetNormals(UnityEngine.Mesh _this, UnityEngine.Vector3[] inNormals, int start, int length, int flags)
{
	_this.SetNormals(inNormals, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetTangents(UnityEngine.Mesh _this, UnityEngine.Vector4[] inTangents)
{
	_this.SetTangents(inTangents);
}

public static void SetTangents(UnityEngine.Mesh _this, UnityEngine.Vector4[] inTangents, int start, int length)
{
	_this.SetTangents(inTangents, start, length);
}

public static void SetTangents(UnityEngine.Mesh _this, UnityEngine.Vector4[] inTangents, int start, int length, int flags)
{
	_this.SetTangents(inTangents, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color[] inColors)
{
	_this.SetColors(inColors);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color[] inColors, int start, int length)
{
	_this.SetColors(inColors, start, length);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color[] inColors, int start, int length, int flags)
{
	_this.SetColors(inColors, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color32[] inColors)
{
	_this.SetColors(inColors);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color32[] inColors, int start, int length)
{
	_this.SetColors(inColors, start, length);
}

public static void SetColors(UnityEngine.Mesh _this, UnityEngine.Color32[] inColors, int start, int length, int flags)
{
	_this.SetColors(inColors, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector2[] uvs)
{
	_this.SetUVs(channel, uvs);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector3[] uvs)
{
	_this.SetUVs(channel, uvs);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector4[] uvs)
{
	_this.SetUVs(channel, uvs);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector2[] uvs, int start, int length)
{
	_this.SetUVs(channel, uvs, start, length);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector2[] uvs, int start, int length, int flags)
{
	_this.SetUVs(channel, uvs, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector3[] uvs, int start, int length)
{
	_this.SetUVs(channel, uvs, start, length);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector3[] uvs, int start, int length, int flags)
{
	_this.SetUVs(channel, uvs, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector4[] uvs, int start, int length)
{
	_this.SetUVs(channel, uvs, start, length);
}

public static void SetUVs(UnityEngine.Mesh _this, int channel, UnityEngine.Vector4[] uvs, int start, int length, int flags)
{
	_this.SetUVs(channel, uvs, start, length, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static UnityEngine.Rendering.VertexAttributeDescriptor[] GetVertexAttributes(UnityEngine.Mesh _this)
{
	return _this.GetVertexAttributes();
}

public static int GetVertexAttributes(UnityEngine.Mesh _this, UnityEngine.Rendering.VertexAttributeDescriptor[] attributes)
{
	return _this.GetVertexAttributes(attributes);
}

public static void SetVertexBufferParams(UnityEngine.Mesh _this, int vertexCount, UnityEngine.Rendering.VertexAttributeDescriptor[] attributes)
{
	_this.SetVertexBufferParams(vertexCount, attributes);
}

public static int[] GetTriangles(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetTriangles(submesh);
}

public static int[] GetTriangles(UnityEngine.Mesh _this, int submesh, bool applyBaseVertex)
{
	return _this.GetTriangles(submesh, applyBaseVertex);
}

public static int[] GetIndices(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetIndices(submesh);
}

public static int[] GetIndices(UnityEngine.Mesh _this, int submesh, bool applyBaseVertex)
{
	return _this.GetIndices(submesh, applyBaseVertex);
}

public static uint GetIndexStart(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetIndexStart(submesh);
}

public static uint GetIndexCount(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetIndexCount(submesh);
}

public static uint GetBaseVertex(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetBaseVertex(submesh);
}

public static void SetTriangles(UnityEngine.Mesh _this, int[] triangles, int submesh)
{
	_this.SetTriangles(triangles, submesh);
}

public static void SetTriangles(UnityEngine.Mesh _this, int[] triangles, int submesh, bool calculateBounds)
{
	_this.SetTriangles(triangles, submesh, calculateBounds);
}

public static void SetTriangles(UnityEngine.Mesh _this, int[] triangles, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetTriangles(triangles, submesh, calculateBounds, baseVertex);
}

public static void SetTriangles(UnityEngine.Mesh _this, int[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetTriangles(triangles, trianglesStart, trianglesLength, submesh, calculateBounds, baseVertex);
}

public static void SetTriangles(UnityEngine.Mesh _this, ushort[] triangles, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetTriangles(triangles, submesh, calculateBounds, baseVertex);
}

public static void SetTriangles(UnityEngine.Mesh _this, ushort[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetTriangles(triangles, trianglesStart, trianglesLength, submesh, calculateBounds, baseVertex);
}

public static void SetIndices(UnityEngine.Mesh _this, int[] indices, int topology, int submesh)
{
	_this.SetIndices(indices, (UnityEngine.MeshTopology)topology, submesh);
}

public static void SetIndices(UnityEngine.Mesh _this, int[] indices, int topology, int submesh, bool calculateBounds)
{
	_this.SetIndices(indices, (UnityEngine.MeshTopology)topology, submesh, calculateBounds);
}

public static void SetIndices(UnityEngine.Mesh _this, int[] indices, int topology, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetIndices(indices, (UnityEngine.MeshTopology)topology, submesh, calculateBounds, baseVertex);
}

public static void SetIndices(UnityEngine.Mesh _this, int[] indices, int indicesStart, int indicesLength, int topology, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetIndices(indices, indicesStart, indicesLength, (UnityEngine.MeshTopology)topology, submesh, calculateBounds, baseVertex);
}

public static void SetIndices(UnityEngine.Mesh _this, ushort[] indices, int topology, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetIndices(indices, (UnityEngine.MeshTopology)topology, submesh, calculateBounds, baseVertex);
}

public static void SetIndices(UnityEngine.Mesh _this, ushort[] indices, int indicesStart, int indicesLength, int topology, int submesh, bool calculateBounds, int baseVertex)
{
	_this.SetIndices(indices, indicesStart, indicesLength, (UnityEngine.MeshTopology)topology, submesh, calculateBounds, baseVertex);
}

public static void SetSubMeshes(UnityEngine.Mesh _this, UnityEngine.Rendering.SubMeshDescriptor[] desc, int start, int count, int flags)
{
	_this.SetSubMeshes(desc, start, count, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void SetSubMeshes(UnityEngine.Mesh _this, UnityEngine.Rendering.SubMeshDescriptor[] desc, int flags)
{
	_this.SetSubMeshes(desc, (UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void Clear(UnityEngine.Mesh _this, bool keepVertexLayout)
{
	_this.Clear(keepVertexLayout);
}

public static void Clear(UnityEngine.Mesh _this)
{
	_this.Clear();
}

public static void RecalculateBounds(UnityEngine.Mesh _this)
{
	_this.RecalculateBounds();
}

public static void RecalculateNormals(UnityEngine.Mesh _this)
{
	_this.RecalculateNormals();
}

public static void RecalculateTangents(UnityEngine.Mesh _this)
{
	_this.RecalculateTangents();
}

public static void RecalculateBounds(UnityEngine.Mesh _this, int flags)
{
	_this.RecalculateBounds((UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void RecalculateNormals(UnityEngine.Mesh _this, int flags)
{
	_this.RecalculateNormals((UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void RecalculateTangents(UnityEngine.Mesh _this, int flags)
{
	_this.RecalculateTangents((UnityEngine.Rendering.MeshUpdateFlags)flags);
}

public static void RecalculateUVDistributionMetric(UnityEngine.Mesh _this, int uvSetIndex, float uvAreaThreshold)
{
	_this.RecalculateUVDistributionMetric(uvSetIndex, uvAreaThreshold);
}

public static void RecalculateUVDistributionMetrics(UnityEngine.Mesh _this, float uvAreaThreshold)
{
	_this.RecalculateUVDistributionMetrics(uvAreaThreshold);
}

public static void MarkDynamic(UnityEngine.Mesh _this)
{
	_this.MarkDynamic();
}

public static void UploadMeshData(UnityEngine.Mesh _this, bool markNoLongerReadable)
{
	_this.UploadMeshData(markNoLongerReadable);
}

public static void Optimize(UnityEngine.Mesh _this)
{
	_this.Optimize();
}

public static void OptimizeIndexBuffers(UnityEngine.Mesh _this)
{
	_this.OptimizeIndexBuffers();
}

public static void OptimizeReorderVertexBuffer(UnityEngine.Mesh _this)
{
	_this.OptimizeReorderVertexBuffer();
}

public static UnityEngine.MeshTopology GetTopology(UnityEngine.Mesh _this, int submesh)
{
	return _this.GetTopology(submesh);
}

public static void CombineMeshes(UnityEngine.Mesh _this, UnityEngine.CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices, bool hasLightmapData)
{
	_this.CombineMeshes(combine, mergeSubMeshes, useMatrices, hasLightmapData);
}

public static void CombineMeshes(UnityEngine.Mesh _this, UnityEngine.CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices)
{
	_this.CombineMeshes(combine, mergeSubMeshes, useMatrices);
}

public static void CombineMeshes(UnityEngine.Mesh _this, UnityEngine.CombineInstance[] combine, bool mergeSubMeshes)
{
	_this.CombineMeshes(combine, mergeSubMeshes);
}

public static void CombineMeshes(UnityEngine.Mesh _this, UnityEngine.CombineInstance[] combine)
{
	_this.CombineMeshes(combine);
}

public static UnityEngine.Rendering.IndexFormat get_indexFormat(UnityEngine.Mesh _this)
{
	return _this.indexFormat;
}

public static void set_indexFormat(UnityEngine.Mesh _this, UnityEngine.Rendering.IndexFormat value)
{
	_this.indexFormat = value;
}

public static int get_vertexBufferCount(UnityEngine.Mesh _this)
{
	return _this.vertexBufferCount;
}

public static int get_blendShapeCount(UnityEngine.Mesh _this)
{
	return _this.blendShapeCount;
}

public static UnityEngine.Matrix4x4[] get_bindposes(UnityEngine.Mesh _this)
{
	return _this.bindposes;
}

public static void set_bindposes(UnityEngine.Mesh _this, UnityEngine.Matrix4x4[] value)
{
	_this.bindposes = value;
}

public static bool get_isReadable(UnityEngine.Mesh _this)
{
	return _this.isReadable;
}

public static int get_vertexCount(UnityEngine.Mesh _this)
{
	return _this.vertexCount;
}

public static int get_subMeshCount(UnityEngine.Mesh _this)
{
	return _this.subMeshCount;
}

public static void set_subMeshCount(UnityEngine.Mesh _this, int value)
{
	_this.subMeshCount = value;
}

public static UnityEngine.Bounds get_bounds(UnityEngine.Mesh _this)
{
	return _this.bounds;
}

public static void set_bounds(UnityEngine.Mesh _this, UnityEngine.Bounds value)
{
	_this.bounds = value;
}

public static UnityEngine.Vector3[] get_vertices(UnityEngine.Mesh _this)
{
	return _this.vertices;
}

public static void set_vertices(UnityEngine.Mesh _this, UnityEngine.Vector3[] value)
{
	_this.vertices = value;
}

public static UnityEngine.Vector3[] get_normals(UnityEngine.Mesh _this)
{
	return _this.normals;
}

public static void set_normals(UnityEngine.Mesh _this, UnityEngine.Vector3[] value)
{
	_this.normals = value;
}

public static UnityEngine.Vector4[] get_tangents(UnityEngine.Mesh _this)
{
	return _this.tangents;
}

public static void set_tangents(UnityEngine.Mesh _this, UnityEngine.Vector4[] value)
{
	_this.tangents = value;
}

public static UnityEngine.Vector2[] get_uv(UnityEngine.Mesh _this)
{
	return _this.uv;
}

public static void set_uv(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv = value;
}

public static UnityEngine.Vector2[] get_uv2(UnityEngine.Mesh _this)
{
	return _this.uv2;
}

public static void set_uv2(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv2 = value;
}

public static UnityEngine.Vector2[] get_uv3(UnityEngine.Mesh _this)
{
	return _this.uv3;
}

public static void set_uv3(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv3 = value;
}

public static UnityEngine.Vector2[] get_uv4(UnityEngine.Mesh _this)
{
	return _this.uv4;
}

public static void set_uv4(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv4 = value;
}

public static UnityEngine.Vector2[] get_uv5(UnityEngine.Mesh _this)
{
	return _this.uv5;
}

public static void set_uv5(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv5 = value;
}

public static UnityEngine.Vector2[] get_uv6(UnityEngine.Mesh _this)
{
	return _this.uv6;
}

public static void set_uv6(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv6 = value;
}

public static UnityEngine.Vector2[] get_uv7(UnityEngine.Mesh _this)
{
	return _this.uv7;
}

public static void set_uv7(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv7 = value;
}

public static UnityEngine.Vector2[] get_uv8(UnityEngine.Mesh _this)
{
	return _this.uv8;
}

public static void set_uv8(UnityEngine.Mesh _this, UnityEngine.Vector2[] value)
{
	_this.uv8 = value;
}

public static UnityEngine.Color[] get_colors(UnityEngine.Mesh _this)
{
	return _this.colors;
}

public static void set_colors(UnityEngine.Mesh _this, UnityEngine.Color[] value)
{
	_this.colors = value;
}

public static UnityEngine.Color32[] get_colors32(UnityEngine.Mesh _this)
{
	return _this.colors32;
}

public static void set_colors32(UnityEngine.Mesh _this, UnityEngine.Color32[] value)
{
	_this.colors32 = value;
}

public static int get_vertexAttributeCount(UnityEngine.Mesh _this)
{
	return _this.vertexAttributeCount;
}

public static int[] get_triangles(UnityEngine.Mesh _this)
{
	return _this.triangles;
}

public static void set_triangles(UnityEngine.Mesh _this, int[] value)
{
	_this.triangles = value;
}

public static UnityEngine.BoneWeight[] get_boneWeights(UnityEngine.Mesh _this)
{
	return _this.boneWeights;
}

public static void set_boneWeights(UnityEngine.Mesh _this, UnityEngine.BoneWeight[] value)
{
	_this.boneWeights = value;
}

}
}
