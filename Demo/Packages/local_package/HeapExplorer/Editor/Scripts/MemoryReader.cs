using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HeapExplorer
{
    public class MemoryReader : AbstractMemoryReader
    {
        public MemoryReader(PackedMemorySnapshot snapshot)
            : base(snapshot)
        {
        }

        protected override int TryBeginRead(System.UInt64 address)
        {
            if (address == 0)
                return -1;

            if (address >= m_StartAddress && address < m_EndAddress)
            {
                return (int)(address - m_StartAddress);
            }

            var heapIndex = m_Snapshot.FindHeapOfAddress(address);
            if (heapIndex == -1)
            {
                Debug.LogWarningFormat("HeapExplorer: Heap at {0:X} not found. Haven't figured out why this happens yet. Perhaps related to .NET4 ScriptingRuntime?", address);
                return -1;
            }

            var memorySection = m_Snapshot.managedHeapSections[heapIndex];
            m_StartAddress = memorySection.startAddress;
            m_EndAddress = m_StartAddress + (ulong)memorySection.bytes.LongLength;
            m_Bytes = memorySection.bytes;

            return (int)(address - m_StartAddress);
        }
    }


    public class StaticMemoryReader : AbstractMemoryReader
    {
        public StaticMemoryReader(PackedMemorySnapshot snapshot, System.Byte[] staticBytes)
            : base(snapshot)
        {
            m_Bytes = staticBytes;
        }

        protected override int TryBeginRead(System.UInt64 address)
        {
            if (m_Bytes == null || m_Bytes.LongLength == 0 || address >= (ulong)m_Bytes.LongLength)
                return -1;

            if (address >= m_StartAddress && address < m_EndAddress)
            {
                return (int)(address);
            }

            m_StartAddress = 0;
            m_EndAddress = m_StartAddress + (ulong)m_Bytes.LongLength;

            return (int)(address);
        }
    }

    abstract public class AbstractMemoryReader
    {
        protected PackedMemorySnapshot m_Snapshot;
        protected System.Byte[] m_Bytes;
        protected System.UInt64 m_StartAddress = System.UInt64.MaxValue;
        protected System.UInt64 m_EndAddress = System.UInt64.MaxValue;
        protected System.Int32 m_RecursionGuard;
        protected System.Text.StringBuilder m_StringBuilder = new System.Text.StringBuilder(128);
        protected System.Security.Cryptography.MD5 m_Hasher;

        protected AbstractMemoryReader(PackedMemorySnapshot snapshot)
        {
            m_Snapshot = snapshot;
        }

        protected abstract int TryBeginRead(System.UInt64 address);

        public System.SByte ReadSByte(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.SByte);

            var value = (System.SByte)m_Bytes[offset];
            return value;
        }

        public System.Byte ReadByte(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Byte);

            var value = m_Bytes[offset];
            return value;
        }

        public System.Char ReadChar(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Char);

            var value = System.BitConverter.ToChar(m_Bytes, offset);
            return value;
        }

        public System.Boolean ReadBoolean(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Boolean);

            var value = System.BitConverter.ToBoolean(m_Bytes, offset);
            return value;
        }

        public System.Single ReadSingle(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Single);

            var value = System.BitConverter.ToSingle(m_Bytes, offset);
            return value;
        }

        public UnityEngine.Quaternion ReadQuaternion(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(Quaternion);

            var sizeOfSingle = m_Snapshot.managedTypes[m_Snapshot.coreTypes.systemSingle].size;
            var value = new Quaternion()
            {
                x = ReadSingle(address + (uint)(sizeOfSingle * 0)),
                y = ReadSingle(address + (uint)(sizeOfSingle * 1)),
                z = ReadSingle(address + (uint)(sizeOfSingle * 2)),
                w = ReadSingle(address + (uint)(sizeOfSingle * 3))
            };

            return value;
        }

        public UnityEngine.Matrix4x4 ReadMatrix4x4(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(Matrix4x4);

            var value = new Matrix4x4();

            var sizeOfSingle = m_Snapshot.managedTypes[m_Snapshot.coreTypes.systemSingle].size;
            var element = 0;
            for (var y = 0; y < 4; ++y)
            {
                for (var x = 0; x < 4; ++x)
                {
                    value[y, x] = ReadSingle(address + (uint)(sizeOfSingle * element));
                    element++;
                }
            }

            return value;
        }

        public System.Double ReadDouble(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Double);

            var value = System.BitConverter.ToDouble(m_Bytes, offset);
            return value;
        }

        public System.Decimal ReadDecimal(System.UInt64 address)
        {
            var offset = TryBeginRead(address);
            if (offset < 0)
                return default(System.Decimal);


            const int SignMask = unchecked((int)0x80000000);
            const int ScaleMask = 0x00FF0000;
