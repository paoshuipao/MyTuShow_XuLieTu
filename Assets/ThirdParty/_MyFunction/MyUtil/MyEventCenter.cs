using System;
using System.Collections.Generic;
using PSPUtil.StaticUtil;

namespace PSPUtil
{
    public delegate void Callback();
    public delegate void Callback<T>(T arg1);
    public delegate void Callback<T, U>(T arg1, U arg2);
    public delegate void Callback<T, U, V>(T arg1, U arg2, V arg3);
    public delegate void Callback<T, U, V, X>(T arg1, U arg2, V arg3, X arg4);

    public static class MyEventCenter
    {

        public static void AddListener(E_GameEvent eventType, Callback handler)
        {
            OnListenerAdding(eventType, handler);
            eventK_ActionV[eventType] = (Callback)eventK_ActionV[eventType] + handler;
        }

        public static void AddListener<T>(E_GameEvent eventType, Callback<T> handler)
        {
            OnListenerAdding(eventType, handler);
            eventK_ActionV[eventType] = (Callback<T>)eventK_ActionV[eventType] + handler;
        }

        public static void AddListener<T, U>(E_GameEvent eventType, Callback<T, U> handler)
        {
            OnListenerAdding(eventType, handler);
            eventK_ActionV[eventType] = (Callback<T, U>)eventK_ActionV[eventType] + handler;
        }

        public static void AddListener<T, U, V>(E_GameEvent eventType, Callback<T, U, V> handler)
        {
            OnListenerAdding(eventType, handler);
            eventK_ActionV[eventType] = (Callback<T, U, V>)eventK_ActionV[eventType] + handler;
        }

        public static void AddListener<T, U, V, X>(E_GameEvent eventType, Callback<T, U, V, X> handler)
        {
            OnListenerAdding(eventType, handler);
            eventK_ActionV[eventType] = (Callback<T, U, V, X>)eventK_ActionV[eventType] + handler;
        }

        //————————————————————————————————————
        public static void RemoveListener(E_GameEvent eventType, Callback handler)
        {
            OnListenerRemoving(eventType, handler);
            // ReSharper disable once DelegateSubtraction
            eventK_ActionV[eventType] = (Callback)eventK_ActionV[eventType] - handler;
            OnListenerRemoved(eventType);
        }
        public static void RemoveListener<T>(E_GameEvent eventType, Callback<T> handler)
        {
            OnListenerRemoving(eventType, handler);
            // ReSharper disable once DelegateSubtraction
            eventK_ActionV[eventType] = (Callback<T>)eventK_ActionV[eventType] - handler;
            OnListenerRemoved(eventType);
        }

        public static void RemoveListener<T, U>(E_GameEvent eventType, Callback<T, U> handler)
        {
            OnListenerRemoving(eventType, handler);
            // ReSharper disable once DelegateSubtraction
            eventK_ActionV[eventType] = (Callback<T, U>)eventK_ActionV[eventType] - handler;
            OnListenerRemoved(eventType);
        }

        public static void RemoveListener<T, U, V>(E_GameEvent eventType, Callback<T, U, V> handler)
        {
            OnListenerRemoving(eventType, handler);
            // ReSharper disable once DelegateSubtraction
            eventK_ActionV[eventType] = (Callback<T, U, V>)eventK_ActionV[eventType] - handler;
            OnListenerRemoved(eventType);
        }

        public static void RemoveListener<T, U, V, X>(E_GameEvent eventType, Callback<T, U, V, X> handler)
        {
            OnListenerRemoving(eventType, handler);
            // ReSharper disable once DelegateSubtraction
            eventK_ActionV[eventType] = (Callback<T, U, V, X>)eventK_ActionV[eventType] - handler;
            OnListenerRemoved(eventType);
        }



        //————————————————————————————————————

        public static void SendEvent(E_GameEvent eventType)
        {
            Delegate d;
            if (eventK_ActionV.TryGetValue(eventType, out d))
            {
                Callback callback = d as Callback;

                if (callback != null)
                {
                    callback();
                }
                else
                {
                    throw new Exception(string.Format("发送消息:{0}，接收者参数与发送者的参数不同 ", eventType));
                }
            }
        }

        public static void SendEvent<T>(E_GameEvent eventType, T arg1)
        {
            Delegate d;
            if (eventK_ActionV.TryGetValue(eventType, out d))
            {
                Callback<T> callback = d as Callback<T>;

                if (callback != null)
                {
                    callback(arg1);
                }
                else
                {
                    throw new Exception(string.Format("发送消息:{0}，接收者参数与发送者的参数不同 ", eventType));
                }
            }
        }

        public static void SendEvent<T, U>(E_GameEvent eventType, T arg1, U arg2)
        {
            Delegate d;
            if (eventK_ActionV.TryGetValue(eventType, out d))
            {
                Callback<T, U> callback = d as Callback<T, U>;

                if (callback != null)
                {
                    callback(arg1, arg2);
                }
                else
                {
                    throw new Exception(string.Format("发送消息:{0}，接收者参数与发送者的参数不同 ", eventType));
                }
            }
        }

        public static void SendEvent<T, U, V>(E_GameEvent eventType, T arg1, U arg2, V arg3)
        {
            Delegate d;
            if (eventK_ActionV.TryGetValue(eventType, out d))
            {
                Callback<T, U, V> callback = d as Callback<T, U, V>;

                if (callback != null)
                {
                    callback(arg1, arg2, arg3);
                }
                else
                {
                    throw new Exception(string.Format("发送消息:{0}，接收者参数与发送者的参数不同 ", eventType));
                }
            }
        }


        public static void SendEvent<T, U, V, X>(E_GameEvent eventType, T arg1, U arg2, V arg3, X arg4)
        {
            Delegate d;
            if (eventK_ActionV.TryGetValue(eventType, out d))
            {
                Callback<T, U, V, X> callback = d as Callback<T, U, V, X>;

                if (callback != null)
                {
                    callback(arg1, arg2, arg3, arg4);
                }
                else
                {
                    throw new Exception(string.Format("发送消息:{0}，接收者参数与发送者的参数不同 ", eventType));
                }
            }
        }

        public static void SendEvent(CommonEventBean commonBean)
        {
            SendEvent(commonBean.EventId, commonBean);
        }


        #region 私有


        private static readonly Dictionary<E_GameEvent, Delegate> eventK_ActionV = new Dictionary<E_GameEvent, Delegate>();


        private static void OnListenerAdding(E_GameEvent eventType, Delegate listenerBeingAdded)
        {

            if (!eventK_ActionV.ContainsKey(eventType))
            {
                eventK_ActionV.Add(eventType, null);
            }

            Delegate d = eventK_ActionV[eventType];
            if (d != null && d.GetType() != listenerBeingAdded.GetType())
            {
                throw new Exception(string.Format("事件 —{0}—， 不一致的监听器，当前要添加的是 —{1}— ，之前的是 —{2}—", eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
            }
        }

        private static void OnListenerRemoving(E_GameEvent eventType, Delegate listenerBeingRemoved)
        {
            if (eventK_ActionV.ContainsKey(eventType))
            {
                Delegate d = eventK_ActionV[eventType];

                if (d == null)
                {
                    MyLog.Red("移除的事件为空 —— " + eventType);
                }
                else if (d.GetType() != listenerBeingRemoved.GetType())
                {
                    throw new Exception(string.Format("事件 —{0}—， 不一致的监听器，当前移除的是 —{1}— ，之前的是 —{2}—", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
                }
            }
            else
            {
                MyLog.Red("都没注册进来，移除个蛋");
            }
        }


        private static void OnListenerRemoved(E_GameEvent eventType)
        {
            if (eventK_ActionV[eventType] == null)
            {
                eventK_ActionV.Remove(eventType);
            }
        }


        #endregion


    }

    public class CommonEventBean
    {
        public E_GameEvent EventId { get; private set; }
        private readonly Dictionary<string, object> paramList = new Dictionary<string, object>();

        public CommonEventBean(E_GameEvent id)
        {
            EventId = id;
        }

        public void AddParam(string name, object value)
        {
            paramList[name] = value;
        }

        public object GetParam(string name)
        {
            if (paramList.ContainsKey(name))
            {
                return paramList[name];
            }
            return null;
        }


    }

}
