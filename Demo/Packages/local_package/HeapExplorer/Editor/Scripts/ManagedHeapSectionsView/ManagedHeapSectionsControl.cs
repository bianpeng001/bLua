﻿//
using UnityEngine;
using UnityEditor.IMGUI.Controls;

namespace HeapExplorer
{
    public class ManagedHeapSectionsControl : AbstractTreeView
    {
        public System.Action<PackedMemorySection?> onSelectionChange;

        public int count
        {
            get
            {
                if (rootItem == null || !rootItem.hasChildren)
                    return 0;

                return rootItem.children.Count;
            }
        }

        PackedMemorySnapshot m_Snapshot;
        int m_UniqueId = 1;

        enum Column
        {
            Address,
            Size,
#if HEAPEXPLORER_DISPLAY_REFS
            Refs,
#endif
        }

        public ManagedHeapSectionsControl(HeapExplorerWindow window, string editorPrefsKey, TreeViewState state)
            : base(window, editorPrefsKey, state, new MultiColumnHeader(
                new MultiColumnHeaderState(new[]
                {
                new MultiColumnHeaderState.Column() { headerContent = new GUIContent("Address"), width = 300, autoResize = true },
                new MultiColumnHeaderState.Column() { headerContent = new GUIContent("Size"), width = 120, autoResize = true },
#if HEAPEXPLORER_DISPLAY_REFS
                    new MultiColumnHeaderState.Column() { headerContent = new GUIContent("Refs"), width = 120, autoResize = true },
#endif
                })))
        {
            extraSpaceBeforeIconAndLabel = 4;
            columnIndexForTreeFoldouts = 0;
            multiColumnHeader.canSort = true;

            Reload();
        }

        public void Clear()
        {
            m_Snapshot = null;

            Reload();
        }

        protected override void OnSelectionChanged(TreeViewItem selectedItem)
        {
            base.OnSelectionChanged(selectedItem);

            if (onSelectionChange == null)
                return;

            var item = selectedItem as HeapSectionItem;
            if (item == null)
            {
                onSelectionChange.Invoke(null);
                return;
            }

            var section = m_Snapshot.managedHeapSections[item.arrayIndex];
            onSelectionChange.Invoke(section);
        }

        public TreeViewItem BuildTree(PackedMemorySnapshot snapshot, PackedMemorySection[] sections)
        {
            m_Snapshot = snapshot;
            m_UniqueId = 1;

            var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
            if (m_Snapshot == null)
            {
                root.AddChild(new TreeViewItem { id = 1, depth = -1, displayName = "" });
                return root;
            }

            for (int n = 0, nend = sections.Length; n < nend; ++n)
            {
                if (window.isClosing) // the window is closing
                    break;

                var section = sections[n];

                var item = new HeapSectionItem()
                {
                    id = m_UniqueId++,
                    depth = root.depth + 1,
                };

                item.Initialize(this, m_Snapshot, section.arrayIndex);
                root.AddChild(item);
            }

            return root;
        }

        protected override int OnSortItem(TreeViewItem aa, TreeViewItem bb)
        {
            var sortingColumn = multiColumnHeader.sortedColumnIndex;
            var ascending = multiColumnHeader.IsSortedAscending(sortingColumn);

            var itemA = (ascending ? aa : bb) as AbstractItem;
            var itemB = (ascending ? bb : aa) as AbstractItem;

            switch ((Column)sortingColumn)
            {
                case Column.Size:
                    return itemA.size.CompareTo(itemB.size);

                case Column.Address:
                    return itemA.address.CompareTo(itemB.address);

#if HEAPEXPLORER_DISPLAY_REFS
                case Column.Refs:
                    return itemA.refs.CompareTo(itemB.refs);
#endif
            }

            return 0;
        }


        class AbstractItem : AbstractTreeViewItem
        {
            public System.UInt64 address;
            public ulong size;
#if HEAPEXPLORER_DISPLAY_REFS
            public int refs;
#endif
            protected ManagedHeapSectionsControl m_Owner;

            public override void GetItemSearchString(string[] target, out int count, out string type, out string label)
            {
                base.GetItemSearchString(target, out count, out type, out label);

                target[count++] = displayName;
                target[count++] = string.Format(StringFormat.Address, address);
            }

            public override void OnGUI(Rect position, int column)
            {
                switch ((Column)column)
                {
                    case Column.Address:
                        HeEditorGUI.Address(position, address);
                        break;

                    case Column.Size:
                        HeEditorGUI.Size(position, (long)size);
                        break;

#if HEAPEXPLORER_DISPLAY_REFS
                    case Column.Refs:
                        GUI.Label(position, refs.ToString());
                        break;
#endif
                }
            }
        }


        class HeapSectionItem : AbstractItem
        {
            public int arrayIndex;
            PackedMemorySnapshot m_Snapshot;

            public void Initialize(ManagedHeapSectionsControl owner, PackedMemorySnapshot snapshot, int memorySegmentIndex)
            {
                m_Owner = owner;
                m_Snapshot = snapshot;
                arrayIndex = memorySegmentIndex;

                displayName = "MemorySection";
                address = m_Snapshot.managedHeapSections[arrayIndex].startAddress;
                if (m_Snapshot.managedHeapSections[arrayIndex].bytes != null)
                {
                    size = (ulong)m_Snapshot.managedHeapSections[arrayIndex].bytes.LongLength;

#if HEAPEXPLORER_DISPLAY_REFS
                    m_Snapshot.GetConnectionsCount(m_Snapshot.managedHeapSections[arrayIndex], out refs);
#endif
                }
            }

            public override void OnGUI(Rect position, int column)
            {
                if (column == 0)
                {
                    if (HeEditorGUI.CsButton(HeEditorGUI.SpaceL(ref position, position.height)))
                    {
                        MemoryWindow.Inspect(m_Snapshot, address, size);
                    }
                }

                base.OnGUI(position, column);
            }
        }

    }
}
