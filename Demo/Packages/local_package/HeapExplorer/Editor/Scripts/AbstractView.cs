//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq.Expressions;

namespace HeapExplorer
{
    abstract public class HeapExplorerView
    {
        public GUIContent titleContent
        {
            get;
            set;
        }

        public int viewMenuOrder
        {
            get;
            set;
        }

        public HeapExplorerWindow window
        {
            get;
            internal set;
        }

        public bool isVisible
        {
            get;
            private set;
        }

        public PackedMemorySnapshot snapshot
        {
            get;
            private set;
        }

        public string editorPrefsKey
        {
            get;
            set;
        }

        List<HeapExplorerView> m_Views = new List<HeapExplorerView>();

        protected string GetPrefsKey(Expression<Func<object>> exp)
        {
            var body = exp.Body as MemberExpression;
            if (body == null)
            {
                var ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return string.Format("HeapExplorer.{0}.{1}", editorPrefsKey, body.Member.Name);
        }

        public HeapExplorerView()
        {
            editorPrefsKey = GetType().Name;
            viewMenuOrder = int.MaxValue - 1;
        }

        public virtual void Awake()
        {
            titleContent = new GUIContent(ObjectNames.NicifyVariableName(GetType().Name));
        }

        public virtual void OnDestroy()
        {
            foreach (var v in m_Views)
                v.OnDestroy();

            m_Views = null;
            snapshot = null;
        }

        internal void EvictHeap()
        {
            snapshot = null;
        }

        public void Show(PackedMemorySnapshot heap)
        {
            if (snapshot != heap)
            {
                if (snapshot != null && isVisible)
                    Hide(); // Hide normally implements to save the layout of various UI elements

                snapshot = heap;
                OnCreate();
            }

            OnShow();

            foreach (var v in m_Views)
                v.Show(heap);

            isVisible = true;
            Repaint();
        }

        public void Hide()
        {
            OnHide();

            foreach (var v in m_Views)
                v.Hide();

            isVisible = false;
            Repaint();
        }

        public virtual int CanProcessCommand(GotoCommand command)
        {
            return 0;
        }

        public virtual void RestoreCommand(GotoCommand command)
        {
        }

        public virtual GotoCommand GetRestoreCommand()
        {
            return new GotoCommand();
        }

        public virtual void OnGUI()
        {
        }

        public virtual void OnToolbarGUI()
        {
        }

        protected virtual void OnCreate()
        {
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        protected void Goto(GotoCommand command)
        {
            window.OnGoto(command);
        }

        protected void Repaint()
        {
            window.Repaint();
        }

        protected void ScheduleJob(AbstractThreadJob job)
        {
            window.ScheduleJob(job);
        }

        protected T CreateView<T>() where T : HeapExplorerView, new()
        {
            var view = new T();
            view.window = window;
            view.Awake();
            m_Views.Add(view);
            return view;
        }
    }
}
