using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    internal static class Utility {
        public static object UnwrapPSObject(object obj) {
            PSObject psObject = obj as PSObject;
            if(psObject==null) {
                return obj;
            } else {
                object baseObject = psObject.BaseObject;
                return baseObject is PSCustomObject||
                       baseObject is string||
                       baseObject is int||
                       baseObject is long||
                       baseObject is double||
                       baseObject is decimal ? obj : baseObject;
            }
        }
        public static object UnwrapPSObjects(object obj) {
            obj=UnwrapPSObject(obj);
            return ShouldEnumerate(obj) ? UnwrapPSObjects((IEnumerable)obj) : obj;
        }
        private static IEnumerable UnwrapPSObjects(IEnumerable obj) {
            Stack<IEnumerator> stack = new Stack<IEnumerator>();
            try {
                stack.Push(obj.GetEnumerator());
                while(stack.Count>0) {
                    while(stack.Peek().MoveNext()) {
                        object current = UnwrapPSObject(stack.Peek().Current);
                        if(ShouldEnumerate(current)) {
                            stack.Push(((IEnumerable)current).GetEnumerator());
                        } else {
                            yield return current;
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
        private static bool ShouldEnumerate(object value) {
            return !(value is string||
                     value is XObject||
                     value is XStreamingElement)&&value is IEnumerable;
        }
    }
}
