using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    internal static class Utility {
        public static object UnwrapPSObject(object obj) {
            PSObject psObject = obj as PSObject;
            if(psObject!=null) {
                object baseObject = psObject.BaseObject;
                if(!(
                    baseObject is PSCustomObject||
                    baseObject is string||
                    baseObject is int||
                    baseObject is long||
                    baseObject is double||
                    baseObject is decimal
                )) {
                    obj=baseObject;
                }
            }
            return obj;
        }
        public static object UnwrapPSObjects(object obj) {
            obj=UnwrapPSObject(obj);
            IEnumerable enumerable = GetEnumerable(obj);
            return enumerable==null ? obj : UnwrapPSObjects(enumerable);
        }
        private static IEnumerable UnwrapPSObjects(IEnumerable obj) {
            Stack<IEnumerator> stack = new Stack<IEnumerator>();
            try {
                stack.Push(obj.GetEnumerator());
                while(stack.Count>0) {
                    while(stack.Peek().MoveNext()) {
                        object current = UnwrapPSObject(stack.Peek().Current);
                        IEnumerable enumerable = GetEnumerable(current);
                        if(enumerable==null) {
                            yield return current;
                        } else {
                            stack.Push(enumerable.GetEnumerator());
                        }
                    }
                    (stack.Pop() as IDisposable)?.Dispose();
                }
            } finally {
                while(stack.Count>0) {
                    (stack.Pop() as IDisposable)?.Dispose();
                }
            }
        }
        private static IEnumerable GetEnumerable(object obj) => obj is string||obj is XObject||obj is XStreamingElement ? null : obj as IEnumerable;
    }
}
