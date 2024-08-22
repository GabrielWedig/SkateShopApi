using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SkateShop.Domain;
using SkateShop.Domain.Notifications;

namespace SkateShop.Api.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                var errorCode = _notificationContext.ErrorCode;
                var notifications = _notificationContext.Notifications;

                context.HttpContext.Response.StatusCode = errorCode;
                context.HttpContext.Response.ContentType = "application/json";

                var error = new ErrorResponse("Ocorreu um erro.", errorCode, notifications);
                var serializedError = JsonConvert.SerializeObject(error);

                await context.HttpContext.Response.WriteAsync(serializedError);
                return;
            }

            await next();
        }
    }
}
