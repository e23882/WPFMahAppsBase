using System;
using Castle.DynamicProxy;

namespace MahAppBase.Utility
{
    public class TryCatchInterceptor : IInterceptor
    {
        #region MemberFunction
        public void Intercept(IInvocation invocation)
        {
            try
            {
                var hasTryCatch = Attribute.IsDefined(invocation.MethodInvocationTarget, typeof(HandleExceptionAttribute));

                if (hasTryCatch)
                {
                    try
                    {
                        Common.Log($"Executing function {invocation.Method.Name}()");
                        invocation.Proceed();
                        Common.Log($"{invocation.Method.Name}() execution completed");
                    }
                    catch (Exception ex)
                    {
                        Common.Log($"執行方法: {invocation.Method.Name} 發生例外 : {ex.Message}\r\n{ex.StackTrace}", LogType.Error);
                        Common.Notify($"{invocation.Method.Name} 發生例外", "發生例外啦，但被catch住了", Notifications.Wpf.NotificationType.Error);
                    }
                }
                else
                    invocation.Proceed();
            }
            catch (Exception ex)
            {
                Common.Log($"執行方法: {invocation.Method.Name} 發生例外 : {ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
        }
        #endregion
    }
}
