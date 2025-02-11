using System;

namespace MahAppBase
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class HandleExceptionAttribute : Attribute { }
}
